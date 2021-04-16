using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
   public class Choice:EntityBase
    {
        string choice;
        public string Choice1
        {
            get => choice;
            set { choice = value; }
        
        }

        int q_Id;
        public int Q_Id
        {
            get => q_Id;
            set { q_Id = value; }
        }
    }
}
