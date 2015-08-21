using System.Collections.Generic;
using System.Linq;

namespace GzMatcher.Core
{
    public class FirstLineJustIntegersMatcher : IHeaderMatcher
    {
        public string Name { get { return "FirstLineJustIntegers"; } }
        public bool IsMatched(IEnumerable<string> header)
        {
            int outValue;
            return header.First().Split(' ').All(i => int.TryParse(i, out outValue));
        }
    }
}
