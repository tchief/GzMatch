using System.Collections.Generic;

namespace GzMatcher.Core
{
    // TODO: Consider renaming this to use System.IO indirectly where needed.
    // TODO: Consider not having Header inside here.
    public class File
    {
        private readonly List<string> _header = new List<string>();
        public File(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public List<string> Header { get { return _header; } }
    }
}
