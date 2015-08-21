using System.Collections.Generic;

namespace GzMatcher.Core
{
    public interface IHeaderMatcher
    {
        string Name { get; }
        bool IsMatched(IEnumerable<string> lines);
    }
}
