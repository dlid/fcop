using Fcop.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Commands
{
    [CommandTarget(Any: true)]
    public class IgnoreFileCommand : FileCommandBase, ICommand
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
                return "File rename";
            }
        }

        public void ExecuteCommand(CommandArguments Args)
        {
            Args.TargetPath = "mhm";
        }
    }

}
