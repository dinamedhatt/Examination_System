using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class CourseManager
    {
        static DBManager dBManager = new DBManager();

        public static CourseList InstructorCrs(int insID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["InsID"] = insID
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("InstructorCrs", ParamList));
            }
            catch
            {

            }
            return new CourseList();
        }

        public static CourseList studentCourses(int SID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["StID"] = SID
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("studentCourses", ParamList));
            }
            catch
            {

            }
            return new CourseList();
        }

        #region Mapping Functions
        internal static CourseList DataTableToTitleList(DataTable Dt)
        {
            CourseList courses = new CourseList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    courses.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return courses;
        }

        internal static Course DataRowToTitle(DataRow Dr)
        {
            Course crs = new Course();
            try
            {
                if (int.TryParse(Dr["Crs_Id"]?.ToString(), out int TempInt))
                    crs.Crs_Id = TempInt;

                crs.Crs_Name = Dr["Crs_Name"]?.ToString() ?? "NA";
                crs.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return crs;
        }
        #endregion

    }
}

