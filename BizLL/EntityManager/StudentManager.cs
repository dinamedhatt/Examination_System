using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class StudentManager
    {
        static DBManager dBManager = new DBManager();
        public static bool StudentLogin(int StudentID, string StudentPW)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["ID"] = StudentID,
                    ["PW"] = StudentPW

                };

                if (Convert.ToInt32(dBManager.ExecuteScaler("StudentLogin", ParamList)) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }


        #region Mapping Functions
        internal static StudentList DataTableToTitleList(DataTable Dt)
        {
            StudentList students = new StudentList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    students.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return students;
        }

        internal static Student DataRowToTitle(DataRow Dr)
        {
            Student std = new Student();
            try
            {

                if (int.TryParse(Dr["St_Id"]?.ToString() ?? "0", out int TempInt))
                    std.St_Id = TempInt;

                std.Password = Dr["Password"]?.ToString() ?? "NA";

                std.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return std;
        }
        #endregion

    }
}

