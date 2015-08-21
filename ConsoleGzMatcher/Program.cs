using System;
using System.Collections.Generic;
using GzMatcher.Core;

namespace GzMatcher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Consider using map approach and create Mathcer property inside a File.
            var matchersMap = new Dictionary<string,IHeaderMatcher> {
                { UnknownHeaderMatcher.FullName, new FirstLine3IntegersTypedMatcher() },
                { UnknownHeaderMatcher.FullName, new FirstLineJustIntegersMatcher() },
                { UnknownHeaderMatcher.FullName, new JustVowelsMatcher() },
                { UnknownHeaderMatcher.FullName, new UnknownHeaderMatcher() } };

            var matchers = new IHeaderMatcher[] {
                new FirstLine3IntegersTypedMatcher(),
                new FirstLineJustIntegersMatcher(),
                new JustVowelsMatcher(),
                new UnknownHeaderMatcher() };
            var processor = new DirectoryProcessor(new FileMatcher(matchers));
            foreach (var path in args)
            {
                System.Console.WriteLine("Start processing '{0}'..", path);
                processor.Process(path);
                System.Console.WriteLine("Directory processing finished.");
                System.Console.WriteLine();
            }

            System.Console.WriteLine("Press any key to exit..");
            System.Console.Read();
        }
    }
}
