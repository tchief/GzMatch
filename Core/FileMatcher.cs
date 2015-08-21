using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace GzMatcher.Core
{
    public class FileMatcher
    {
        private const int MaxLineToReadCount = 50;
        private readonly IReadOnlyCollection<IHeaderMatcher> _matchers;
        public FileMatcher(IEnumerable<IHeaderMatcher> matchers)
        {
            _matchers = new ReadOnlyCollection<IHeaderMatcher>(matchers.ToList());
        }

        public MatchedPair Match(File file)
        {
            var header = ReadHeader(file);
            foreach (var matcher in _matchers)
            {
                if (matcher.IsMatched(header))
                {
                    return new MatchedPair(matcher, file);
                }
            }

            // TODO: Consider change this to return smth instead of using UnknownHeaderMatcher.
            throw new InvalidOperationException();
        }

        private IEnumerable<string> ReadHeader(File file)
        {
            int linesRead = 0;
            using (FileStream reader = System.IO.File.OpenRead(file.Path))
            using (GZipStream zippedStream = new GZipStream(reader, CompressionMode.Decompress, true))
            using (StreamReader unzippedStream = new StreamReader(zippedStream))
            {
                while (!unzippedStream.EndOfStream && linesRead++ <= MaxLineToReadCount)
                    file.Header.Add(unzippedStream.ReadLine());
            }

            return file.Header;
        }
    }
}
