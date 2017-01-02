using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fcop.Core
{
    public interface ICommand
    {

        void ExecuteCommand(CommandArguments Args);
        
        [XmlIgnore]
        string Name { get; }

        [XmlIgnore]
        string Description { get; }

    }

}
