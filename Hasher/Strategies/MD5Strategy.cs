using System.Security.Cryptography;

namespace Hasher.Strategies
{
    public class MD5Strategy : CryptographicHasher<MD5>
    {
        public override MD5 GetHasher() => MD5.Create();
    }

}