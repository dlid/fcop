using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Fcop.Core.Entities
{
    public class FcopDefinition
    {
        public FcopDefinition() {
            Commands = new List<ICommand>();
        }

        public string Source { get; set; }

        [XmlIgnore]
        public ITarget Target { get; set; }

        public List<ICommand> Commands { get; set; }


        public string Serialize()
        {
            var sb = new StringBuilder();

            using (var tw = new StringWriter(sb))
            {
                using (var doc = XmlWriter.Create(tw))
                {
                    doc.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");
                    doc.WriteStartElement("FtpChangedFilesOnlyPlease");

                    doc.WriteStartElement("Target");
                    //doc.WriteAttributeString("Type", this.Target.GetType().FullName);
                    doc.WriteEndElement();

                    doc.WriteEndElement();
                }
            }

            return sb.ToString();

        }

    }

    public class FcopShallowDefinition
    {


    }

    

}
