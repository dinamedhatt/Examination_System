using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Course : EntityBase
    {
        string crs_Name;
        public string Crs_Name 
        {
            get => crs_Name;
            set { crs_Name = value; }
        }

        int crs_Id;
        public int Crs_Id
        {
            get => crs_Id;
           set { crs_Id = value; }
        }
        int? crs_Duration;
        public int? Crs_Duration 
        {
            get => crs_Duration;

        }
    }
}
