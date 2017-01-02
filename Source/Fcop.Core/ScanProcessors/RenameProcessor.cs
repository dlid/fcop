using Fcop.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.ScanProcessors
{
    public class RenameProcessor : IScanProcessor
    {
        public string Description
        {
            get
            {
                return "Rename matching file(s)";
            }
        }

        public string Name
        {
            get
            {
                return "Rename";
            }
        }

        public void ProcessFile(FileScanEvent Event)
        {
           
        }
    }

}
