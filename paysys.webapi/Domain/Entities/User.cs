using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("users")]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; private set; }

    [Required]
    [Column("user_name")]
    public string? UserName { get; private set; }

    [Required]
    [Column("email")]
    public string? Email { get; private set; }

    [Required]
    [Column("phone_number", TypeName = "CHAR(11)")]
    public string? PhoneNumber { get; private set; }

    [Required]
    [Column("hash", TypeName = "BYTEA")]
    public byte[]? Hash { get; private set; }

    [Required]
    [Column("salt", TypeName = "BYTEA")]
    public byte[]? Salt { get; private set; }

    [Required]
    [Column("created_on")]
    public DateTime CreatedOn { get; private set; }

    [Required]
    [Column("last_updated_on")]
    public DateTime LastUpdatedOn { get; private set; }

    // User Type Reference

    [Required]
    [Column("user_type_id")]
    public Guid UserTypeId { get; private set; }

    [ForeignKey(nameof(UserTypeId))]
    public UserType? UserType { get; private set; }

    private User()
    {
    }

    public static User Create(string userName, string email, string phoneNumber, byte[] hash, byte[] salt, Guid userTypeId)
    {
        User newUser = new User();

        newUser.UserId = Guid.NewGuid();

        newUser.UserName = userName;
        newUser.Email = email;
        newUser.PhoneNumber = phoneNumber;
        newUser.Hash = hash;
        newUser.Salt = salt;

        var currentDateTime = DateTime.UtcNow;

        newUser.CreatedOn = currentDateTime;
        newUser.LastUpdatedOn = currentDateTime;

        newUser.UserTypeId = userTypeId;

        return newUser;
    }
}
