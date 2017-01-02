using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public class CommandArguments
    {
        public string SourcePath;

        public string TargetPath;

        public bool IsUpdatedFile;

        public bool IsNewFile;

        public bool IsDeleteFile;

        /// <summary>
        /// The current Fcop Target
        /// </summary>
        public ITarget Target { get; }


    }
}
