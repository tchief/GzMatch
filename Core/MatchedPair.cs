namespace GzMatcher.Core
{
    public class MatchedPair
    {
        public MatchedPair(IHeaderMatcher matcher, File file)
        {
            Matcher = matcher;
            File = file;
        }

        public IHeaderMatcher Matcher { get; private set; }
        public File File { get; private set; }
    }
}
