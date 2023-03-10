using System;
using System.Linq;

namespace Hasher
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var argumentParser = new ArgumentParser(args);

            if (argumentParser.TryParse(out var result, out var exception))
            {
                var hashResults = result.strategy.GetHashes(result.files);

                foreach (var hashResult in hashResults)
                {
                    Console.Out.WriteLine(
                        string.Format(
                            "{0} => {1}",
                            FormatFileName(hashResult.File.FullName),
                            hashResult.Hash
                        )
                    );
                }

                return 0;
            }
            else {
                Console.Error.WriteLine(exception?.Message ?? "Unknown error");
                return 1;
            }
        }

        private static string FormatFileName(string input)
        {
            if (input.Length < 40)
                return input.PadLeft(40);

            if (input.Length > 40)
            {
                var lastChars = input.TakeLast(37);
                for (var i = 0; i < 3; i++)
                    lastChars = lastChars.Prepend('.');
                return new string(lastChars.ToArray());
            }

            return input;
        }
    }
}