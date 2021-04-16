using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class Student_CrsManager
    {
        static DBManager dBManager = new DBManager();

        public static Student_CrsList getCrsGrade(int SID, int CID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["SID"] = SID,
                    ["CID"] = CID
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("getCrsGrade", ParamList));
            }
            catch
            {

            }
            return new Student_CrsList();
        }

        #region Mapping Functions
        internal static Student_CrsList DataTableToTitleList(DataTable Dt)
        {
            Student_CrsList stdCourses = new Student_CrsList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    stdCourses.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return stdCourses;
        }

        internal static Student_Crs DataRowToTitle(DataRow Dr)
        {
            Student_Crs stdCrs = new Student_Crs();
            try
            {
                int TempInt;
                //if (int.TryParse(Dr["St_Id"].ToString(), out TempInt))
                //    stdCrs.St_Id = TempInt;

                //if (int.TryParse(Dr["Crs_Id"].ToString(), out TempInt))
                //    stdCrs.Crs_Id = TempInt;

                if (int.TryParse(Dr["Crs_Grade"]?.ToString(), out TempInt))
                    stdCrs.Crs_Grade = TempInt;

                stdCrs.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return stdCrs;
        }
        #endregion

    }
}

