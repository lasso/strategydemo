using System.Collections.Generic;
using System.IO;

namespace Hasher.Strategies
{
    public interface IHasherStrategy
    {
        void AddFile(FileInfo file);

        IReadOnlyList<HasherResult> GetHashes();
    }
}