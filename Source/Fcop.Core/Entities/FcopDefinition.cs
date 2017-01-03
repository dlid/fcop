using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Fcop.Core.Extensions;

namespace Fcop.Core.Entities
{
    public class FcopDefinition
    {

        private string _filename = string.Empty;

        public FcopDefinition() {
            Commands = new List<ICommand>();
        }

        public string Source { get; set; }

        [XmlIgnore]
        public ITarget Target { get; set; }

        public List<ICommand> Commands { get; set; }

        public void Save(string Filename = null)
        {

            if (string.IsNullOrEmpty(Filename) && string.IsNullOrEmpty(_filename))
                throw new Exception("No filename specified");

            if (string.IsNullOrEmpty(Filename))
                Filename = _filename;
            else 
                _filename = Filename;

            var d = Serialize();
            File.WriteAllText( Filename, d );
        }

        public string Serialize()
        {
            var sb = new StringBuilder();

            using (var tw = new StringWriter(sb))
            {
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = " "
                };

                using (var doc = XmlWriter.Create(tw, settings))
                {
                    doc.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");
                    doc.WriteStartElement("FtpChangesOnlyPlease");

                    if (!string.IsNullOrEmpty(this.Source))
                    {
                        doc.WriteStartElement("Source");
                        doc.WriteAttributeString("Relative", GetRelativePath(this.Source, Path.GetDirectoryName(_filename) ));
                        doc.WriteRaw(this.Source);
                        doc.WriteEndElement();
                    }

                    if (this.Target != null)
                    {
                        
                        
                        doc.WriteStartElement("Target");
                        doc.WriteAttributeString("Type", this.Target.GetType().FullName);

                        var props = (Target as TargetBase).Properties;
                        doc.WriteStartElement("Properties");
                        foreach (var prop in props.Keys)
                        {
                            var o = props.ReadProperty(prop);
                            if (o != null)
                            {
                                doc.WriteStartElement("Property");
                                doc.WriteAttributeString("Name", prop);
                                doc.WriteAttributeString("Type", o.GetType().FullName);
                                doc.WriteCData(o.Serialize(true));
                                doc.WriteEndElement();
                            }
                        }
                        doc.WriteEndElement();

                        doc.WriteEndElement();
                    }

                    doc.WriteEndElement();
                }
            }

            return sb.ToString();

        }

        string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

    }

    public class FcopShallowDefinition
    {


    }

    

}
