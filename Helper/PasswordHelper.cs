namespace CyberTech_Backend.Helper;

using DevOne.Security.Cryptography.BCrypt;

public static class PasswordHelper
{
    public static string GeneratePasswordHash(string password)
    {
        return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
    }

    public static bool VerifyPassword(string password, string storedPasswordHash)
    {
        return BCryptHelper.CheckPassword(password, storedPasswordHash);
    }
}

