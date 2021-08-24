using System;
using System.Security.Cryptography;
using System.Text;

namespace dots_server_v2
{
    public static class Helpers
    {
        public static string GetHash(string str)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(bytes);
        }
    }
}