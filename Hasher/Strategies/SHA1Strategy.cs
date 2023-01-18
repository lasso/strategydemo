using System.Security.Cryptography;

namespace Hasher.Strategies
{
    public class SHA1Strategy : CryptographicHasher<SHA1>, IHasherStrategy
    {
        public override SHA1 GetHasher() => SHA1.Create();
    }
}