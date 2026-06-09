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

    // WARNING: In a real app, keep this 32-character key securely in environment variables!
    private static readonly string SecretKey = "A1b2C3d4E5f6G7h8I9j0K1l2M3n4O5p6";

    // 1. ENCRYPT (Turn Admin@123 into a safe string)
    public static string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(SecretKey);
        aes.GenerateIV(); // Unique initialization vector for safety

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        // Combine IV and Encrypted data so we can decrypt it later
        var result = new byte[aes.IV.Length + encryptedBytes.Length];
        Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
        Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

        return Convert.ToBase64String(result);
    }

    // 2. DECRYPT (Turn the safe string BACK into Admin@123)
    public static string Decrypt(string cipherText)
    {
        var fullCipher = Convert.FromBase64String(cipherText);
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(SecretKey);

        var iv = new byte[aes.BlockSize / 8];
        var cipherBytes = new byte[fullCipher.Length - iv.Length];

        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

        using var decryptor = aes.CreateDecryptor(aes.Key, iv);
        var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}