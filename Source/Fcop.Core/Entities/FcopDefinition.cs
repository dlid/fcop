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


        public void Serialize()
        {
            var sb = new StringBuilder();

            using (var tw = new StringWriter(sb))
            {
                using (var doc = XmlWriter.Create(tw))
                {
                    doc.WriteStartElement("x");

                    doc.WriteEndElement();
                }
            }

        }

    }
}
