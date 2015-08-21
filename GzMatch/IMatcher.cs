using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzMatch
{
    public abstract class FormatMatcher
    {
        public bool IsMatched(List<string> header);
        public string Name { get; }
    }

    public class UnknownFormatMatcher : FormatMatcher
    {
        public bool IsMatched(List<string> header)
        {
            return true;
        }

        public string Name { get { return "Unknown"; } }
    }

    public class Format1Matcher : FormatMatcher
    {
        public bool IsMatched(List<string> header)
        {
            int outValue;
            return int.TryParse(header.First().Split(' ').First(), out outValue);
        }

        public string Name { get { return "Int 1st"; } }
    }



    public class File
    {
        private readonly List<string> _header = new List<string>();
        public File(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            ////_header.AddRange
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public IReadOnlyCollection<string> Header { get {return _header.AsReadOnly(); }
    }

    public class MatchedPair
    {
        public MatchedPair(FormatMatcher format, File file)
        {
            Format = format;
            File = file;
        }

        public FormatMatcher Format { get; private set; }
        public File File { get; private set; }
    }

    public interface IMatcher
    {
        public FormatMatcher Match(File file);
    }

    public class Format {}
    public interface IMatcher2
    {
        public MatchedPair Match(File file);
    }
}
