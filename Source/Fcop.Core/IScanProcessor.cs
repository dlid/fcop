using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fcop.Core
{
    public interface IScanProcessor
    {

        string Name { get; }


        string Description { get; }

        void ProcessFile(FileScanEvent Event);
    }

    public class FileScanEvent
    {
        /// <summary>
        /// Set to True to exclude this file and stop processing further EventProcessors for this file
        /// </summary>
        public bool SkipFile { get; set; }
    }

}
