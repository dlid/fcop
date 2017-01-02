using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fcop.Core
{
    public abstract class FileCommandBase
    {
        string SourcePath { get; set; }
        string TargetPath { get; set; }

        bool Deep { get; }

        List<FilenamePattern> Ignore { get; set; }

        List<FileRename> Rename { get; set; }
    }

    public class FileRename {
        public string FilePath { get; set; }
        public string NewFilename { get; set; }

    }

    public class FilenamePattern
    {
        public string Pattern { get; set; }
        public FilenamePatternMatchType Type { get; set; }
        public bool Invert { get; set; }
        public bool Comment { get; set; }
    }

    public enum FilenamePatternMatchType
    {
        Contains,
        StartsWith,
        EndsWith,
        Regex
    }
}
