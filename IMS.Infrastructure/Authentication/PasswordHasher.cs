using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace IMS.Infrastructure.Authentication
//{
//    internal class PasswordHasher
//    {
//    }
//}

using System.Security.Cryptography;

namespace IMS.Infrastructure.Authentication;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        using var sha = SHA256.Create();

        var bytes = Encoding.UTF8.GetBytes(password);

        var hash = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}