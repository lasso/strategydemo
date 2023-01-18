using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hasher
{
    public abstract class CryptographicHasher<T> where T : System.Security.Cryptography.HashAlgorithm
    {
        protected readonly List<FileInfo> _files = new List<FileInfo>();

        public void AddFile(FileInfo file) => _files.Add(file);

        public IReadOnlyList<HasherResult> GetHashes()
        {
            var hasher = GetHasher();

            return _files.Select(file => {
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