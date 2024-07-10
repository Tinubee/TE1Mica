﻿using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using TE1.Schemas;
using System;
using static TE1.UI.Controls.Config;

namespace TE1.UI.Controls
{
    public partial class DeviceSettings : XtraUserControl
    {
        public DeviceSettings()
        {
            InitializeComponent();
        }

        //private LocalizationConfig 번역 = new LocalizationConfig();

        public void Init()
        {
            this.Bind환경설정.DataSource = Global.환경설정;
            this.e카메라.Init();
            this.e기본설정.Init();
            this.e사진저장.Init();
            this.e유저관리.Init();
        }

        public void Close()
        {
            this.e카메라.Close();
            this.e기본설정.Close();
            this.e사진저장.Close();
            this.e유저관리.Close();
        }
    }
}
