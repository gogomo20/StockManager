using System.Security.Cryptography;
using System.Text;

namespace StockManager.Aplication.Utils
{
    public static class StringUtils
    {
        public static string GetMD5Hash(string pass)
        {
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] stringByte = Encoding.UTF8.GetBytes(pass);
                byte[] hashBystes = md5.ComputeHash(stringByte);
                return Convert.ToHexString(hashBystes);
            }
        }
    }
}
