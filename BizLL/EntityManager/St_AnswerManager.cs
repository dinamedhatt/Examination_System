using BizLL.Entities;
using BizLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BizLL.EntityManager
{


    public static class St_AnswerManager 
    {
        static DBManager dBManager = new DBManager();


        public static bool ExamGeneration(int StudentID, int CrsID )
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["SID"] = StudentID,
                    ["CID"] = CrsID
                };

                if (dBManager.ExecuteNonQuery("ExamGeneration", ParamList) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        public static bool answerQuestion(int QID, int SID, int CID, string Ans)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["QID"] = QID,
                    ["SID"] = SID,
                    ["CID"] = CID,
                    ["Ans"] = Ans
                };

                if (dBManager.ExecuteNonQuery("answerQuestion", ParamList) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        public static bool AnswerCorrection(int SID, int CID)
        {
            try
            {
                Dictionary<string, object> ParamList = new Dictionary<string, object>()
                {
                    ["SID"] = SID,
                    ["CID"] = CID
                };

                if (dBManager.ExecuteNonQuery("AnswerCorrection",ParamList) > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }


        #region Mapping Functions
        internal static St_AnswerList DataTableToTitleList(DataTable Dt)
        {
            St_AnswerList answers = new St_AnswerList();
            try
            {
                foreach (DataRow item in Dt.Rows)
                {
                    answers.Add(DataRowToTitle(item));
                }
            }
            catch
            {

            }
            return answers;
        }

        internal static St_Answer DataRowToTitle(DataRow Dr)
        {
            St_Answer ans = new St_Answer();
            try
            {
                int TempInt;

                if (int.TryParse(Dr["Exam_Id"]?.ToString() ?? "15", out TempInt))
                    ans.Exam_Id = TempInt;

                if (int.TryParse(Dr["St_Id"]?.ToString(), out TempInt))
                    ans.St_Id = TempInt;

                if (int.TryParse(Dr["Q_Id"]?.ToString(), out TempInt))
                    ans.Q_Id = TempInt;

                ans.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return ans;
        }
        #endregion

    }
}
