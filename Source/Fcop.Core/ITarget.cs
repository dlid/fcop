﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public interface ITarget
    {
        string Name { get; }
        string Description { get; }
        Image Icon {get;}

        void AfterScan(List<ICommand> Commands);

    }
}
