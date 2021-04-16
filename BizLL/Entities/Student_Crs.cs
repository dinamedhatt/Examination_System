using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Student_Crs : EntityBase
    {
         int st_Id;
        public int St_Id
        {
            get => st_Id;
            set { st_Id = value; }
        }

        int crs_Id;
        public int Crs_Id
        {
            get => crs_Id;
            set { crs_Id = value; }
        }

        int? crs_Grade;

        public int? Crs_Grade
        {
            get => crs_Grade;
            set { crs_Grade = value; }
        }

       

    }
}

