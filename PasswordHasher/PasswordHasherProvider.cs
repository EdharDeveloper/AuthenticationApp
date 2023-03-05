using System.Reflection;
using System.Text;
using System.Security.Cryptography;

namespace PasswordHasher
{
    public static class PasswordHasherProvider
    {
        public static string GetHash(string password)
        {
            byte[] source;
            byte[] hash;
            source = ASCIIEncoding.ASCII.GetBytes(password);
            hash = new MD5CryptoServiceProvider().ComputeHash(source);
            return ByteArrayToString(hash);
        }
        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        public static bool PasswordsComparer(string source, string input)
        {
            return source == input;
        }
    }
}