using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class ExamManager 
    {
        static DBManager dBManager = new DBManager();

        public static ExamList examTable()
        {
            try
            {
                return DataTableToTitleList(
                dBManager.ExecuteDataTable("examTable"));
            }
            catch { }
            return new ExamList();
        }


        public static ExamList getExamDuration(int CID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["CID"] = CID,
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("getExamDuration",ParamList));
            }
            catch { }
            return new ExamList();
        }


        public static bool ExamCreate ( int duration , int courseId )
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["examDuration"] = duration,
                    ["CrsID"] = courseId
                   

                };

                if (dBManager.ExecuteNonQuery("ExamCreate", ParamList) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }


        #region Mapping Functions
        internal static ExamList DataTableToTitleList(DataTable Dt)
        {
           ExamList exams = new ExamList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    exams.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return exams;
        }

        internal static Exam DataRowToTitle(DataRow Dr)
        {
            Exam ex = new Exam();
            try
            {
                int TempInt; 
               
                if (int.TryParse(Dr["Ex_duration"]?.ToString() ?? "15", out TempInt))
                    ex.Ex_duration = TempInt;

                if (int.TryParse(Dr["Crs_Id"].ToString() , out TempInt))
                    ex.Crs_Id = TempInt;

                ex.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return ex;
        }
        #endregion

    }
}
