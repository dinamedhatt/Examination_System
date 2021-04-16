using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Exam:EntityBase
    {
        int ex_duration;
        public int Ex_duration
        {
            get => ex_duration;
            set
            {
                if (value != ex_duration) 
                {
                    ex_duration = value;
                    this.State = EntityState.Added;
                }
                else
                {
                    ex_duration = value;
                    this.State = EntityState.Modified;
                }
            }
        }

        int exam_Id;
        public int Exam_Id
        {
            get => exam_Id;
           set { exam_Id = value; }
        }

        DateTime? ex_startTime;
        public DateTime? Ex_startTime
        {
            get => ex_startTime;
            set {
                if ((value != ex_startTime) && (ex_startTime is null))
                {
                    ex_startTime = value;
                    this.State = EntityState.Added;
                }
                else
                {
                    ex_startTime = value;
                    this.State = EntityState.Modified;
                }
            }
        }


        int crs_Id;
        public int Crs_Id
        {
            get => crs_Id;
            set { crs_Id = value; }
            
        }

    }
}
