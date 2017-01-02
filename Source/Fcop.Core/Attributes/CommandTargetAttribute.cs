using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true)]
    public class CommandTargetAttribute : Attribute
    {


        public bool Any { get; private set; }

        public List<string> Namespaces { get; private set; }

        public CommandTargetAttribute(params string[] Namespaces)
        {
            this.Namespaces = Namespaces.ToList();
        }

        public CommandTargetAttribute(bool Any)
        {
            this.Any = Any;
        }
    }
}
