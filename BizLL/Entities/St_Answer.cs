using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
   public class St_Answer:EntityBase
    {
        string st_Ans;
        public string St_Ans
        {
            get => st_Ans;
            set {
                if ((value != st_Ans) && (st_Ans is null))
                {
                    st_Ans = value;
                    this.State = EntityState.Added;
                }
                else
                {
                    st_Ans = value;
                    this.State = EntityState.Modified;
                }
            }
        }

        int q_Id;
        public int Q_Id
        {
            get => q_Id;
            set { q_Id = value; }
        }

        int st_Id;
        public int St_Id
        {
            get => st_Id;
            set { st_Id = value; }
        }

        int exam_Id;
        public int Exam_Id
        {
            get => exam_Id;
            set { exam_Id = value; }
        }

        int ans_Grade;
        public int Ans_Grade
        {
            get => ans_Grade;
          
        }
    }
}
