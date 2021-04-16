using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Question:EntityBase
    {
         int q_Id;
        public int Q_Id
        {
            get => q_Id;
            set{ q_Id = value;}
        }


        int? q_Grade;

        public int? Q_Grade
        {
            get => q_Grade;

        }

        string q_Ans;
        public string Q_Ans
        {
            get => q_Ans;
            set { q_Ans = value; }
        }

        string q_Type;
        public string Q_Type
        {
            get => q_Type;
            
        }

        string q_Desc;
        public  string Q_Desc
        {
            get => q_Desc;
            set { q_Desc = value; }
        }

    }
}
