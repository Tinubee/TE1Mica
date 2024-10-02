using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvUtils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace TE1.Schemas
{
    public class 검사자료테이블 : Data.BaseTable
    {
        private TranslationAttribute 로그영역 = new TranslationAttribute("Inspection Data", "검사자료");
        private TranslationAttribute 삭제오류 = new TranslationAttribute("An error occurred while deleting data.", "자료 삭제중 오류가 발생하였습니다.");
        private DbSet<검사정보> 검사정보 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<검사정보>().HasKey(e => new { e.일시 });
            //modelBuilder.Entity<검사정보>().Property(e => new { e.일시 });
            modelBuilder.Entity<검사정보>().Property(e => e.모델).HasConversion(new EnumToNumberConverter<모델구분, Int32>());
            modelBuilder.Entity<검사정보>().Property(e => e.시트).HasConversion(new EnumToNumberConverter<시트구분, Int32>());
            base.OnModelCreating(modelBuilder);
        }

        public void Add(검사정보 정보) => this.검사정보.Add(정보);
        public void Remove(List<검사정보> 자료) => this.검사정보.RemoveRange(자료);

        public void Save()
        {
            try
            { 
                this.SaveChanges();
                Debug.WriteLine("검사자료 Save 완료.", "자료저장");
            }
            catch (Exception ex) { Debug.WriteLine(ex.ToString(), "자료저장"); }
        }

        public void SaveAsync()
        {
            try { this.SaveChangesAsync(); }
            catch (Exception ex) { Debug.WriteLine(ex.ToString(), "자료저장"); }
        }

        public 검사정보 Select(DateTime 일시, 모델구분 모델 = 모델구분.None) => this.Select(일시, 일시, 모델).FirstOrDefault();
        public List<검사정보> Select(DateTime 시작, DateTime 종료, 모델구분 모델 = 모델구분.None)
        {
            IQueryable<검사정보> query1 =
                from l in 검사정보
                where l.일시 >= 시작 && l.일시 <= 종료
                where (모델 == 모델구분.None || l.모델 == 모델)
                orderby l.일시 descending
                select l;
            List<검사정보> 자료 = query1.AsNoTracking().ToList();
            if (자료 == null || 자료.Count < 1) return new List<검사정보>();
            return 자료;
        }

        public Int32 Delete(검사정보 정보)
        {
            String Sql = $"DELETE FROM inspd WHERE idwdt = @idwdt";
            try
            {
                int AffectedRows = 0;
                using (NpgsqlCommand cmd = new NpgsqlCommand(Sql, this.DbConn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@idwdt", 정보.일시));
                    if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                    AffectedRows = cmd.ExecuteNonQuery();
                    //Debug.WriteLine(Utils.FormatDate(정보.일시, "{0:yyyy-MM-dd HH:mm:ss.ffffff}"), "검사일시");
                    Debug.WriteLine(AffectedRows, "AffectedRows");
                    cmd.Connection.Close();
                }
                return AffectedRows;
            }
            catch (Exception ex)
            {
                Global.오류로그(로그영역.GetString(), Localization.삭제.GetString(), $"{삭제오류.GetString()}\r\n{ex.Message}", true);
            }
            return 0;
        }

        public Int32 자료정리(Int32 일수)
        {
            DateTime 일자 = DateTime.Today.AddDays(-일수);
            String day = Utils.FormatDate(일자, "{0:yyyy-MM-dd}");
            String sql = $"DELETE FROM inspd WHERE idwdt < DATE('{day}');";
            try
            {
                int AffectedRows = 0;
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, this.DbConn))
                {
                    if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                    AffectedRows = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                return AffectedRows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Global.오류로그(로그영역.GetString(), "Remove Datas", ex.Message, false);
            }
            return -1;
        }
    }
}
