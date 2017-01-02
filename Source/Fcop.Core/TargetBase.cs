using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public abstract class TargetBase
    {
        public TargetBase()
        {
            this.Properties = new PropertyBag();
        }

        public PropertyBag Properties { get; set; }


    }
}
