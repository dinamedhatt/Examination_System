using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Student : EntityBase
    {
        int st_Id;
        public  int St_Id
        {
            get => st_Id;

            set { st_Id = value; }
        }


        string st_Fname;
        public string St_Fname
        {
            get => st_Fname;

        }


        string st_Lname;
        public string St_Lname
        {
            get => st_Lname;
            
        }

        string st_Address;
        public string St_Address
        {
            get => st_Address;
          
        }

        int? st_Age;
        public int? St_Age
        {
            get => st_Age;
            
        }


        int? dept_id;
        public int? Dept_id
        {
            get => dept_id;
        }
        public string Password { get; set; }

    }
}
