using System;
using System.Collections.Generic;
using System.Text;

namespace BizLL.Entities
{
    public class EntityBase
    {
        public EntityState State { get; set; } = EntityState.UnChanged;
    }
}
