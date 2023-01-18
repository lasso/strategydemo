using System.Security.Cryptography;

namespace Hasher.Strategies
{
    public class MD5Strategy : CryptographicHasher<MD5>, IHasherStrategy
    {
        public override MD5 GetHasher() => MD5.Create();
    }

}