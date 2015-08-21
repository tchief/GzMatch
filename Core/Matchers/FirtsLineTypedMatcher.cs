using System;
using System.Collections.Generic;
using System.Linq;

namespace GzMatcher.Core
{
    public abstract class FirtsLineTypedMatcher : IHeaderMatcher
    {
        private readonly char[] Separators = new char[] { ' ', '\t' };

        public abstract string Name { get; }
        public abstract List<Type> Types { get; }
        public bool IsMatched(IEnumerable<string> header)
        {
            var firstLine = header.First().Split(Separators);
            for (int i = 0; i < firstLine.Length; i++)
            {
                try
                {
                    var result = Convert.ChangeType(firstLine[i], Types[i]);
                }
                // TODO: Catch needed eceptions only.
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}
