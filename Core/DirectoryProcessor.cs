using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzMatcher.Core
{
    public class DirectoryProcessor : IDirectoryProcessor
    {
        private const string FileSearchPattern = "*.tar.gz";
        private const string MatchedLineFormat = "{0}, {1}";
        private const string UnmatchedOutputFileName = "unmatched.txt";
        private const string MatchedOutputFileName = "matched.txt";

        private readonly FileMatcher _fileMatcher;
        public DirectoryProcessor(FileMatcher fileMatcher)
        {
            _fileMatcher = fileMatcher;
        }

        public void Process(string path)
        {
            // TODO: Consider PFX via EnumerateFiles.
            var pairs = Directory
                .GetFiles(path, FileSearchPattern, SearchOption.TopDirectoryOnly)
                .Select(filePath => new File(filePath))
                .Select(file => _fileMatcher.Match(file));

            var unmatchedFileNames = pairs.Where(p => p.Matcher is UnknownHeaderMatcher).Select(p => p.File.Name);
            var matchedFiles = pairs.Where(p => !(p.Matcher is UnknownHeaderMatcher));

            ProcessUnmatchedFiles(path, unmatchedFileNames);
            ProcessMatchedFiles(path, matchedFiles);
        }

        private static void ProcessUnmatchedFiles(string path, IEnumerable<string> fileNames)
        {
            System.IO.File.WriteAllLines(System.IO.Path.Combine(path, UnmatchedOutputFileName), fileNames);
        }

        private static void ProcessMatchedFiles(string path, IEnumerable<MatchedPair> matches)
        {
            var lines = matches.Select(m => string.Format(MatchedLineFormat, m.File.Name, m.Matcher.Name));
            System.IO.File.WriteAllLines(System.IO.Path.Combine(path, MatchedOutputFileName), lines);
        }
    }
}
