using System.Collections.Generic;
using System.IO;

namespace Hasher.Strategies
{
    public interface IHasherStrategy
    {
        IReadOnlyList<HasherResult> GetHashes(IEnumerable<FileInfo> files);
    }
}