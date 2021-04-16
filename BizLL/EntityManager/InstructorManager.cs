using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class InstructorManager
    {
        static DBManager dBManager = new DBManager();
        public static bool InstructorLogin(int insID, string insPW)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["ID"] = insID,
                    ["PW"] = insPW

                };

                if (Convert.ToInt32(dBManager.ExecuteScaler("InstructorLogin", ParamList)) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }


        #region Mapping Functions
        internal static InstructorList DataTableToTitleList(DataTable Dt)
        {
            InstructorList instructors = new InstructorList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    instructors.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return instructors;
        }

        internal static Instructor DataRowToTitle(DataRow Dr)
        {
            Instructor inst = new Instructor();
            try
            {

                if (int.TryParse(Dr["Ins_Id"]?.ToString() ?? "0", out int TempInt))
                    inst.Ins_Id = TempInt;

                inst.Ins_Password = Dr["Ins_Password"]?.ToString() ?? "NA";

                inst.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return inst;
        }
        #endregion

    }
}

