using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class Instructor : EntityBase
    {
        int ins_Id;
        public int Ins_Id
        {
            get => ins_Id;
            set { ins_Id = value; }
        }


        string ins_name;
        public string Ins_name
        {
            get => ins_name;
           
        }

        Nullable<decimal> salary;
        public Nullable<decimal> Salary
        {
            get => salary;
            
        }

        string ins_Password;
        public string Ins_Password
        {
            get => ins_Password;
            set { ins_Password = value; }
        }

        int? dept_id;
        public int? Dept_id
        {
            get => dept_id;
            
        }


        int? mgr_id;
        public int? Mgr_id
        {
            get => mgr_id;
          
        }

    }
}
