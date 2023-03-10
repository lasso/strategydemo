using System.Security.Cryptography;

namespace Hasher.Strategies
{
    public class SHA256Strategy : CryptographicHasher<SHA256>
    {
        public override SHA256 GetHasher() => SHA256.Create();
    }
}