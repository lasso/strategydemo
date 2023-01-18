using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hasher.Strategies
{
    public class AttributesStrategy : IHasherStrategy
    {
        public IReadOnlyList<HasherResult> GetHashes(IEnumerable<FileInfo> files)
        {
            return files.Select(file => {
                var builder = new StringBuilder();
                long seconds = (long)file.LastWriteTimeUtc.Subtract(DateTime.UnixEpoch).TotalSeconds;
                builder.Append(seconds);
                builder.Append(':');
                builder.Append(file.Length);
                var bytes = Encoding.ASCII.GetBytes(builder.ToString());
                var hash = BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
                return new HasherResult(file, hash);
            }).ToArray();
        }
    }
}