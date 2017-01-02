using Fcop.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Commands
{
    [CommandTarget(Any: true)]
    public class WebRequestCommand : ICommand
    {
        public string Description
        {
            get
            {
                return "Invoke a WebRequest";
            }
        }

        public bool IsFileCommand
        {
            get
            {
                // We just want to do this once, not for every file
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "Invoke WebRequest";
            }
        }

        public void ExecuteCommand(CommandArguments Args)
        {
            
        }
    }
}
