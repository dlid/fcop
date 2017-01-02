using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Targets
{
    public class FcopFTPTarget : ITarget
    {
        public string Description
        {
            get
            {
                return "Send files via FTP";
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
                return "FTP";
            }
        }

        public string FtpFolder { get;set; }

        public string FtpHost { get; set; }

        public int FtpPort { get; set; }

        public string FtpUsername { get; set; }

        public void AfterScan(List<ICommand> Commands)
        {
            // Filescan is complete and we have a list of commands
            // Let's connect to the FTP server to see if we need to create any new folders as well
            // eller?
        }
        
    }
}
