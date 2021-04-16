using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class ChoiceManager
    {
        static DBManager dBManager = new DBManager();

        public static ChoiceList questionChoices(int QID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["QID"] = QID
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("questionChoices",ParamList));
            }
            catch
            {

            }
            return new ChoiceList();
        }

       

        #region Mapping Functions
        internal static ChoiceList DataTableToTitleList(DataTable Dt)
        {
            ChoiceList choices = new ChoiceList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    choices.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return choices;
        }

        internal static Choice DataRowToTitle(DataRow Dr)
        {
            Choice ch = new Choice();
            try
            {
                if (int.TryParse(Dr["Q_Id"].ToString(), out int TempInt))
                    ch.Q_Id = TempInt;

                ch.Choice1 = Dr["Choice"]?.ToString();
                ch.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return ch;
        }
        #endregion

    }
}

