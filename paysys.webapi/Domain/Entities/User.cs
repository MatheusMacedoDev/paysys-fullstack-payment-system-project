using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.Entities;

[Table("Users")]
public class User
{
    [Key]
    public Guid UserId { get; private set; }

    [Required]
    public string? UserName { get; private set; }

    [Required]
    public string? Email { get; private set; }

    [Required]
    [Column(TypeName = "CHAR(11)")]
    public string? PhoneNumber { get; private set; }

    [Required]
    [Column(TypeName = "BYTEA")]
    public byte[]? Hash { get; private set; }

    [Required]
    [Column(TypeName = "BYTEA")]
    public byte[]? Salt { get; private set; }

    [Required]
    public DateTime CreatedOn { get; private set; }

    [Required]
    public DateTime LastUpdatedOn { get; private set; }

    // User Type Reference

    [Required]
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

        var currentDateTime = DateTime.Now;

        newUser.CreatedOn = currentDateTime;
        newUser.LastUpdatedOn = currentDateTime;

        newUser.UserTypeId = userTypeId;

        return newUser;
    }
}
