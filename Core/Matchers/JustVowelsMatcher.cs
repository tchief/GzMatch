using System.Collections.Generic;
using System.Linq;

namespace GzMatcher.Core
{
    public class JustVowelsMatcher : IHeaderMatcher
    {
        // TODO: Consider extracting separators logic.
        private readonly char[] Separators = { ' ', '\t' };
        public string Name { get { return "JustVowels"; } }
        public bool IsMatched(IEnumerable<string> header)
        {
            foreach (var line in header)
            {
                if (line.Split(Separators).Any(s => !IsJustVowels(s)))
                    return false;
            }

            return true;
        }

        // TODO: Move to extensions.
        private readonly char[] _vowels = { 'a', 'e', 'y', 'u', 'i', 'o' };
        private bool IsJustVowels(string s)
        {
            foreach (var c in s)
            {
                if (!_vowels.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
