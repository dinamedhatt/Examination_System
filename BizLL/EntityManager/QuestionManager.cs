using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{
    public static class QuestionManager
    {
        static DBManager dBManager = new DBManager();

        public static QuestionList getQuestionList(int SID, int CID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["SID"] = SID,
                    ["CID"] = CID
                };

                return DataTableToTitleList(
                dBManager.ExecuteDataTable("getQuestionList", ParamList));
            }
            catch
            {

            }
            return new QuestionList();
        }



        #region Mapping Functions
        internal static QuestionList DataTableToTitleList(DataTable Dt)
        {
            QuestionList questions = new QuestionList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    questions.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return questions;
        }

        internal static Question DataRowToTitle(DataRow Dr)
        {
            Question ques = new Question();
            try
            {
                if (int.TryParse(Dr["Q_Id"].ToString(), out int TempInt))
                    ques.Q_Id = TempInt;

                ques.Q_Desc = Dr["Q_Desc"]?.ToString();
                ques.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return ques;
        }
        #endregion

    }
}

