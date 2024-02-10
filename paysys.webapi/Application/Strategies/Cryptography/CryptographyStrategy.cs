using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace paysys.webapi.Application.Strategies.Cryptography;

public class CryptographyStrategy : ICryptographyStrategy
{
    // Salt Parameters
    private const int SaltSize = 16;

    // Password
    private const int DegreeOfParalelism = 1;
    private const int Iterations = 2;
    private const int MemorySize = 1024 * 20;
    private const int HashSize = 32;

    public byte[] MakeHashedPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

        argon2.Salt = salt;
        argon2.DegreeOfParallelism = DegreeOfParalelism;
        argon2.Iterations = Iterations;
        argon2.MemorySize = MemorySize;

        return argon2.GetBytes(HashSize);
    }

    public byte[] MakeSalt()
    {
        byte[] buffer = RandomNumberGenerator.GetBytes(SaltSize);

        return buffer;
    }

    public bool VerifyHashedPassword(string passwordInTest, byte[] passwordHash, byte[] passwordSalt)
    {
        byte[] hashedPasswordInTest = MakeHashedPassword(passwordInTest, passwordSalt);
        return passwordHash.SequenceEqual(hashedPasswordInTest);
    }
}
