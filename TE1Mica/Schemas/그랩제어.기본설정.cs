using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using MvCamCtrl.NET;
using MvCamCtrl.NET.CameraParams;
using Newtonsoft.Json;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Cognex.VisionPro.Implementation;




namespace TE1.Schemas
{
    public enum 회전구분
    {
        None,
        Rotate90Deg,
        Rotate180Deg,
        Rotate270Deg,
        Flip,
        FlipAndRotate90Deg,
        FlipAndRotate180Deg,
        FlipAndRotate270Deg
    }

    public class 그랩장치 : IDisposable
    {
        [JsonProperty("Camera"), Translation("Camera", "카메라")]
        public virtual 카메라구분 구분 { get; set; } = 카메라구분.None;
        [JsonProperty("Serial"), Translation("Serial", "Serial")]
        public virtual String 코드 { get; set; } = String.Empty;
        [JsonIgnore, Translation("Name", "명칭")]
        public virtual String 명칭 { get; set; } = String.Empty;
        [JsonProperty("Description"), Translation("Description", "설명")]
        public virtual String 설명 { get; set; } = String.Empty;
        [JsonProperty("IpAddress"), Translation("IP", "IP")]
        public virtual String 주소 { get; set; } = String.Empty;
        [JsonProperty("Width"), Description("Width"), Translation("Width", "가로")]
        public virtual Int32 가로 { get; set; } = 0;
        [JsonProperty("Height"), Description("Height"), Translation("Height", "세로")]
        public virtual Int32 세로 { get; set; } = 0;
        [JsonProperty("Exposure"), Description("Exposure"), Translation("Exposure(µs)", "노출(µs)")]
        public virtual Single 노출 { get; set; } = 5000;
        [JsonProperty("CalibX"), Description("CalibX(µm)"), Translation("CalibX(µm)", "CalibX(µm)")]
        public virtual Double 교정X { get; set; } = 0;
        [JsonProperty("CalibY"), Description("CalibY(µm)"), Translation("CalibY(µm)", "CalibY(µm)")]
        public virtual Double 교정Y { get; set; } = 0;
        [JsonProperty("Rotate"), Description("Rotation"), Translation("Rotation", "회전")]
        public virtual 회전구분 회전 { get; set; } = 회전구분.None;

        [JsonIgnore, Description("State"), Translation("State", "상태")]
        public virtual Boolean 상태 { get; set; } = false;
        [JsonIgnore]
        internal virtual MatType ImageType => MatType.CV_8UC1;
        [JsonIgnore]
        internal virtual Boolean UseMemoryCopy => false;
        [JsonIgnore]
        internal Int32 ImageWidth = 0;
        [JsonIgnore]
        internal Int32 ImageHeight = 0;
        [JsonIgnore]
        internal Object BufferLock = new Object();
        [JsonIgnore]
        internal UInt32 BufferSize = 0;
        [JsonIgnore]
        internal IntPtr BufferAddress = IntPtr.Zero;
        [JsonIgnore]
        internal Queue<Mat> Images = new Queue<Mat>();
        [JsonIgnore]
        internal Mat Image => Images.LastOrDefault<Mat>();

        [JsonIgnore]
        public Boolean 연속촬영여부 = false;

        [JsonIgnore]
        public const String 로그영역 = "Camera";

        public void Dispose()
        {
            while (Images.Count > 3)
                Dispose(Images.Dequeue());
        }
        internal void Dispose(Mat image)
        {
            if (image == null || image.IsDisposed) return;
            image.Dispose();
        }

        public virtual void Set(그랩장치 장치)
        {
            if (장치 == null) return;
            코드 = 장치.코드;
            설명 = 장치.설명;
            노출 = 장치.노출;
            교정X = 장치.교정X;
            교정Y = 장치.교정Y;
            회전 = 장치.회전;
            //원점XP = 장치.원점XP;
            //원점YP = 장치.원점YP;
            //원점XM = 장치.원점XM;
            //원점YM = 장치.원점YM;
        }
        public virtual Boolean Init() => false;
        public virtual Boolean Active() => false;
        public virtual Boolean Stop() => false;
        public virtual Boolean Close()
        {
            while (Images.Count > 0)
                Dispose(Images.Dequeue());
            return true;
        }
        public virtual Boolean Trig() => false;
        public virtual void TurnOn() => Global.조명제어.TurnOn(구분);
        public virtual void TurnOff() => Global.조명제어.TurnOff(구분);

        #region 이미지그랩
        internal void InitBuffers(Int32 width, Int32 height)
        {
            if (width == 0 || height == 0) return;
            Int32 channels = ImageType == MatType.CV_8UC3 ? 3 : 1;
            Int32 imageSize = width * height * channels;
            if (BufferAddress != IntPtr.Zero && imageSize == BufferSize) return;
            ImageWidth = width; ImageHeight = height;
            if (BufferAddress != IntPtr.Zero)
            {
                Marshal.Release(BufferAddress);
                BufferAddress = IntPtr.Zero;
                BufferSize = 0;
            }

            BufferAddress = Marshal.AllocHGlobal(imageSize);
            if (BufferAddress == IntPtr.Zero) return;
            BufferSize = (UInt32)imageSize;
            Debug.WriteLine(구분.ToString(), "InitBuffers");
        }

        internal void CopyMemory(IntPtr surfaceAddr, Int32 width, Int32 height)
        {
            // 메모리 복사
            lock (BufferLock)
            {
                try
                {
                    InitBuffers(width, height);
                    Common.CopyMemory(BufferAddress, surfaceAddr, BufferSize);
                }
                catch (Exception e)
                {
                    Global.오류로그(로그영역, "Acquisition", $"[{구분.ToString()}] {e.Message}", true);
                }
            }
        }

        internal void AcquisitionFinished(IntPtr surfaceAddr, Int32 width, Int32 height)
        {
            if (surfaceAddr == IntPtr.Zero) { AcquisitionFinished("Failed."); return; }
            try
            {
                if (UseMemoryCopy) CopyMemory(surfaceAddr, width, height);
                else
                {
                    BufferAddress = surfaceAddr;
                    ImageWidth = width;
                    ImageHeight = height;
                }
                Global.그랩제어.그랩완료(this);
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "Acquisition", $"[{구분}] {ex.Message}", true);
            }
        }

        internal void AcquisitionFinished(String error) =>
            Global.오류로그(로그영역, "Acquisition", $"[{구분.ToString()}] {error}", true);
        internal void AcquisitionFinished(Mat image)
        {
            if (image == null) { AcquisitionFinished("Failed."); return; }
            Images.Enqueue(image);
            Dispose();
            Global.그랩제어.그랩완료(this);
        }

        public ICogImage CogImage()
        {
            try
            {
                if (Image != null) return Common.ToCogImage(Image);
                if (BufferAddress == IntPtr.Zero) return null;
                //using (CogImage8Root cogImage8Root = new CogImage8Root())
                {
                    CogImage8Root cogImage8Root = new CogImage8Root();
                    CogImage8Grey image = new CogImage8Grey();
                    cogImage8Root.Initialize(ImageWidth, ImageHeight, BufferAddress, ImageWidth, null);
                    image.SetRoot(cogImage8Root);
                    
                    if(this.회전 == 회전구분.None) return image;
                    
                    return RotateImage(image, (CogIPOneImageFlipRotateOperationConstants)this.회전);
                }
            }
            catch (Exception e)
            {
                Global.오류로그(로그영역, "Acquisition", $"[{구분.ToString()}] {e.Message}", true);
            }
            return null;
        }


        // 이미지를 회전시키는 함수
        public ICogImage RotateImage(ICogImage inputImage, CogIPOneImageFlipRotateOperationConstants rotate)
        {
            // IPOneImageTool 객체 생성
            CogIPOneImageTool ipOneImageTool = new CogIPOneImageTool();

            // 입력 이미지 설정
            ipOneImageTool.InputImage = inputImage;

            // 회전 변환 설정
            CogIPOneImageFlipRotate rotateTool = new CogIPOneImageFlipRotate();
            rotateTool.OperationInPixelSpace = rotate;
            
            // 회전 도구를 이미지 프로세싱 도구에 추가
            ipOneImageTool.Operators.Add(rotateTool);

            // 도구 실행
            ipOneImageTool.Run();

            // 결과 이미지 반환
            return ipOneImageTool.OutputImage;
        }

        public Mat MatImage()
        {
            if (Image != null) return Image;
            if (BufferAddress == IntPtr.Zero) return null;
            return new Mat(ImageHeight, ImageWidth, ImageType, BufferAddress);
        }
        #endregion
    }

    public class HikeGigE : 그랩장치
    {
        internal override Boolean UseMemoryCopy => false;
        [JsonIgnore]
        private CCamera Camera = null;
        [JsonIgnore]
        private CCameraInfo Device;
        [JsonIgnore]
        private cbOutputExdelegate ImageCallBackDelegate;
        [JsonIgnore]
        public Int32 OffsetX { get; set; } = 0;
        [JsonIgnore]
        public Int32 OffsetY { get; set; } = 0;
        [JsonIgnore]
        public Boolean ReverseX { get; set; } = false;
        [JsonIgnore]
        public Boolean ReverseY { get; set; } = false;

        public Boolean Init(CGigECameraInfo info)
        {
            try
            {
                Camera = new CCamera();
                Device = info;
                ImageCallBackDelegate = new cbOutputExdelegate(ImageCallBack);

                명칭 = info.chManufacturerName + " " + info.chModelName;
                UInt32 ip1 = (info.nCurrentIp & 0xff000000) >> 24;
                UInt32 ip2 = (info.nCurrentIp & 0x00ff0000) >> 16;
                UInt32 ip3 = (info.nCurrentIp & 0x0000ff00) >> 8;
                UInt32 ip4 = info.nCurrentIp & 0x000000ff;
                주소 = $"{ip1}.{ip2}.{ip3}.{ip4}";
                상태 = Init();
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역, "초기화", $"초기화 오류: {ex.Message}", true);
                상태 = false;
            }

            Debug.WriteLine($"{명칭}, {코드}, {주소}, {상태}");
            return 상태;
        }

        public override Boolean Init()
        {
            Int32 nRet = Camera.CreateHandle(ref Device);
            if (!그랩제어.Validate($"[{구분}] 카메라 초기화에 실패하였습니다.", nRet, true)) return false;
            nRet = Camera.OpenDevice();
            if (!그랩제어.Validate($"[{구분}] 카메라 연결 실패!", nRet, true)) return false;

            if (가로 > 0) Camera.SetIntValue("Width", 가로);
            if (세로 > 0) Camera.SetIntValue("Height", 세로);
            if (노출 > 0) Camera.SetFloatValue("ExposureTime", 노출);
            if (OffsetX > 0) Camera.SetIntValue("OffsetX", OffsetX);
            if (OffsetY > 0) Camera.SetIntValue("OffsetY", OffsetY);

            Camera.SetBoolValue("ReverseX", ReverseX);
            Camera.SetBoolValue("ReverseY", ReverseY);
            Camera.SetEnumValue("TriggerMode", (UInt16)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            Camera.SetEnumValue("TriggerSource", (UInt16)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
            그랩제어.Validate("RegisterImageCallBackEx", Camera.RegisterImageCallBackEx(ImageCallBackDelegate, IntPtr.Zero), false);
            Global.정보로그(로그영역, "카메라 연결", $"[{구분}] 카메라 연결 성공!", false);
            return Active();
        }

        public override Boolean Active()
        {
            Camera.ClearImageBuffer();
            return 그랩제어.Validate($"{구분} Active", Camera.StartGrabbing(), true);
        }

        public override Boolean Close()
        {
            base.Close();
            if (Camera == null || !상태) return true;
            return 그랩제어.Validate($"{구분} Close", Camera.CloseDevice(), false);
        }

        public override Boolean Stop() =>
            그랩제어.Validate($"{구분} Stop", Camera.StopGrabbing(), false);

        public override Boolean Trig() =>
            그랩제어.Validate($"{구분} TriggerSoftware", Camera.SetCommandValue("TriggerSoftware"), true);

        private void ImageCallBack(IntPtr surfaceAddr, ref MV_FRAME_OUT_INFO_EX frameInfo, IntPtr user)
        {
            AcquisitionFinished(surfaceAddr, frameInfo.nWidth, frameInfo.nHeight);
            //AcquisitionFinished(new Mat(frameInfo.nHeight, frameInfo.nWidth, MatType.CV_8UC1, surfaceAddr));
        }
    }

    public class ImageDevice : 그랩장치
    {
        internal override Boolean UseMemoryCopy => false;
        public override Boolean Init() => true;
        public override Boolean Active() => true;
        public override Boolean Close() => true;
        public override Boolean Stop() => true;
        public override Boolean Trig() => true;
    }
}
