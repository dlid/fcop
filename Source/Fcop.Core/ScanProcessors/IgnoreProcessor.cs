using Fcop.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.ScanProcessors
{
    public class IgnoreProcessor : IScanProcessor
    {
        public string Description
        {
            get
            {
                return "Ignore matching file(s)";
            }
        }

        public string Name
        {
            get
            {
                return "Ignore file(s)";
            }
        }

        public void ProcessFile(FileScanEvent Event)
        {
           
        }
    }

}
