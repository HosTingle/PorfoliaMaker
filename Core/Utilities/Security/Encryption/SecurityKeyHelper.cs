using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(securityKey);

            // Anahtar boyutunu kontrol et ve gerekiyorsa uzat
            if (keyBytes.Length < 64)  // 64 bytes = 512 bits
            {
                var newKey = new byte[64];
                Array.Copy(keyBytes, newKey, keyBytes.Length);  // Eski anahtarı kopyalar, geri kalan kısmı sıfırlarla doldurur
                keyBytes = newKey;
            }

            return new SymmetricSecurityKey(keyBytes);
        }
    }
}
