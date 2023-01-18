using System.IO;

namespace Hasher
{
    public record HasherResult(FileInfo File, string Hash);
}