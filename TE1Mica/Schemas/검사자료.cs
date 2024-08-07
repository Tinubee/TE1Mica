using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TE1.Schemas
{
    public class 검사자료 : BindingList<검사정보>
    {
        public delegate void 검사진행알림(검사정보 검사);
        public event 검사진행알림 검사완료알림;
        //public event 검사진행알림 수동검사알림;

        [JsonIgnore]
        public static TranslationAttribute 로그영역 = new TranslationAttribute("Inspection", "검사내역");
        [JsonIgnore]
        private TranslationAttribute 저장오류 = new TranslationAttribute("An error occurred while saving the data.", "자료 저장중 오류가 발생하였습니다.");
        [JsonIgnore]
        private 검사자료테이블 테이블 = null;


        public void Init()
        {
            this.AllowEdit = true;
            this.AllowRemove = true;
            this.테이블 = new 검사자료테이블();
            this.Load();
            Global.환경설정.모델변경알림 += 모델변경알림;
            모델변경알림(Global.환경설정.선택모델);
        }

        public Boolean Close()
        {
            if (this.테이블 == null) return true;
            this.테이블.Save();
            this.테이블.자료정리(Global.환경설정.결과보관);
            return true;
        }

        public void Save() => this.테이블.Save();
        public void Load() => this.Load(DateTime.Today, DateTime.Today);
        public void Load(DateTime 시작, DateTime 종료)
        {
            this.Clear();
            this.RaiseListChangedEvents = false;
            List<검사정보> 자료 = this.테이블.Select(시작, 종료);
            자료.ForEach(검사 => Add(검사));
            this.RaiseListChangedEvents = true;
            this.ResetBindings();
        }

        public List<검사정보> GetData(DateTime 시작, DateTime 종료, 모델구분 모델) => this.테이블.Select(시작, 종료, 모델);
        public 검사정보 GetItem(DateTime 일시, 모델구분 모델) => this.테이블.Select(일시, 모델);

        private void 모델변경알림(모델구분 모델) 
        {
            this.수동좌측 = new 검사정보() { 모델 = 모델, 시트 = 시트구분.좌측, 검사내역 = new 측정자료(모델, 시트구분.좌측) };
            this.수동우측 = new 검사정보() { 모델 = 모델, 시트 = 시트구분.우측, 검사내역 = new 측정자료(모델, 시트구분.우측) };
        }

        private void 자료추가(검사정보 검사)
        {
            this.Insert(0, 검사);
            if (Global.장치상태.자동수동)
                this.테이블.Add(검사);
            // 저장은 State 에서
        }

        public void 검사항목제거(List<검사정보> 자료) => this.테이블.Remove(자료);
        
        
        public Boolean 결과삭제(검사정보 정보)
        {
            this.Remove(정보);
            return this.테이블.Delete(정보) > 0;
        }


       

        #region 검사로직
        public 검사정보 수동좌측 = null;
        public 검사정보 수동우측 = null;
        public 검사정보 좌측검사 = null;
        public 검사정보 우측검사 = null;
        public 시트구분 검사시트(카메라구분 카메라)
        {
            if ((Int32)카메라 < (Int32)카메라구분.Cam05) return 시트구분.좌측;
            return 시트구분.우측;
        }
        public 검사정보 현재검사찾기(카메라구분 카메라) => 현재검사찾기(검사시트(카메라));
        public 검사정보 현재검사찾기(시트구분 시트)
        {
            if (!Global.장치상태.자동수동)
            {
                검사정보 검사 = 시트 == 시트구분.좌측 ? 수동좌측 : 수동우측;
                검사.일시 = DateTime.Now;
                검사.모델 = Global.환경설정.선택모델;
                검사.시트 = 시트;
                return 검사;
            }

            if (시트 == 시트구분.좌측)
            {
                if (좌측검사 == null)
                {
                    좌측검사 = 검사정보.신규검사(시트);
                    자료추가(좌측검사);
                }
                return 좌측검사;
            }
            if (시트 == 시트구분.우측)
            {
                if (우측검사 == null)
                {
                    우측검사 = 검사정보.신규검사(시트);
                    자료추가(우측검사);
                }
                return 우측검사;
            }
            return null;
        }

        // 수동체크
        public void 검사완료체크(카메라구분 카메라, 검사정보 검사)
        {
            if (검사 == null || Global.장치상태.자동수동) return;
            if (검사.검사내역.Count < 4) return;
            검사결과계산(검사);
        }

        public void 검사결과계산(검사정보 검사)
        {
            Boolean 결과 = 검사.결과계산();
            if (Global.장치상태.자동수동)
            {
                if      (검사.시트 == 시트구분.좌측) 좌측검사 = null;
                else if (검사.시트 == 시트구분.우측) 우측검사 = null;
                this.ResetItem(검사);
            }
            this.검사완료알림?.Invoke(검사);
        }

        public void ResetItem(검사정보 검사)
        {
            if (검사 == null) return;
            this.ResetItem(this.IndexOf(검사));
        }
        #endregion
    }
}
