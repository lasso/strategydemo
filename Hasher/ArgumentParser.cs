using System;
using System.IO;
using Hasher.Strategies;

namespace Hasher
{
    public class ArgumentParser
    {
        private string[] _args;

        public ArgumentParser(string[] args)
        {
            _args = args;
        }

        public bool TryParse(out IHasherStrategy? strategy, out Exception? exception)
        {
            strategy = null;
            exception = null;

            if (_args.Length < 2)
            {
                exception = new ArgumentException("Invalid number of parameters");
                return false;
            }

            if (Enum.TryParse<HashAlgorithm>(_args[0], true, out var algorithm))
            {
                strategy = GetStrategy(algorithm);

                if (strategy == null) { // Valid algorithm but no matching strategy
                    exception = new ArgumentException($"No strategy for algorithm {algorithm} implemented.");
                    return false;
                }
            }
            else {
                exception = new ArgumentException($"Invalid hash algorithm {algorithm}.");
                return false;
            }

            var numFiles = 0;

            // Treat the rest of the arguments as file paths
            for (var i = 1; i < _args.Length; i++)
            {
                var fileInfo = new FileInfo(_args[i]);

                if (fileInfo.Exists)
                {
                    numFiles++;
                    strategy.AddFile(fileInfo);
                }
            }

            if (numFiles == 0)
            {
                exception = new ArgumentException("No valid files specified");
                return false;
            }

            return true;
        }

        private IHasherStrategy? GetStrategy(HashAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithm.MD5:
                    return new MD5Strategy();
                case HashAlgorithm.SHA1:
                    return new SHA1Strategy();
                case HashAlgorithm.SHA256:
                    return new SHA256Strategy();
                default:
                    return null;
            }
        }
    }
}