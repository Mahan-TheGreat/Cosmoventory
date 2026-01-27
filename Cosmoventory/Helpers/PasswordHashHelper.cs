using Cosmoventory.Models;
using Microsoft.AspNetCore.Identity;

namespace Cosmoventory.Helpers;
public class PasswordHashHelper
{
    private static readonly PasswordHasher<User> Hasher = new();

    public static string Hash(string plainPassword)
        => Hasher.HashPassword(null!, plainPassword);

    public static bool Verify(string hashedPassword, string plainPassword)
        => Hasher.VerifyHashedPassword(null!, hashedPassword, plainPassword)
        == PasswordVerificationResult.Success;
}
