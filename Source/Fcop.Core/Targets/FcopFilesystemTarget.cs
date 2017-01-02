using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Targets
{
    public class FcopFilesystemTarget : TargetBase, ITarget
    {
        public string Description
        {
            get
            {
                return "Copy files to a different folder";
            }
        }

        public Image Icon
        {
            get
            {
                return null;
            }
        }

        public string Name
        {
            get
            {
                return "Local Filesystem";
            }
        }

        public void AfterScan()
        {
            
        }

        public void AfterScan(List<ICommand> Commands)
        {
        }
    }
}
