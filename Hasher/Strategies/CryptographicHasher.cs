using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hasher.Strategies
{
    public abstract class CryptographicHasher<T> : IHasherStrategy where T : System.Security.Cryptography.HashAlgorithm
    {
        public IReadOnlyList<HasherResult> GetHashes(IEnumerable<FileInfo> files)
        {
            var hasher = GetHasher();

            return files.Select(file => {
                using (var stream = file.OpenRead())
                {
                    return new HasherResult(
                        file,
                        BitConverter.ToString(hasher.ComputeHash(stream)).Replace("-", string.Empty).ToLower()
                    );
                }
            }).ToArray();
        }

        public abstract T GetHasher();
    }
}