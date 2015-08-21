using System.Collections.Generic;

namespace GzMatcher.Core
{
    public class UnknownHeaderMatcher : IHeaderMatcher
    {
        public static string FullName = "Unknown";
        public string Name { get { return FullName; } }
        public bool IsMatched(IEnumerable<string> header)
        {
            return true;
        }
    }
}
