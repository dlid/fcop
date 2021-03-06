﻿using Fcop.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core.Commands
{
    [CommandTarget("Fcop.Core.Targets.FcopFTPTarget")]
    public class FTPUploadCommand : FileCommandBase, ICommand
    {

        public string Description
        {
            get
            {
                return "Upload or delete a file from FTP server";
            }
        }

        public string Name
        {
            get
            {
                return "FTP Transfer";
            }
        }

        public void ExecuteCommand(CommandArguments Args)
        {

            if (Args.IsNewFile || Args.IsUpdatedFile)
            {

            } else if (Args.IsDeleteFile)
            {

            }
        }
    }

}
