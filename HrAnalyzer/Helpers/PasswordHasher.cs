using System.Security.Cryptography;
using System.Text;

namespace HrAnalyzer.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashedBytes = sha256.ComputeHash(passwordBytes);

        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
}