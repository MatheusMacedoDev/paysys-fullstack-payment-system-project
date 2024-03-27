using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("users")]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User : Notifiable<Notification>
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

    public User(string userName, string email, string phoneNumber, byte[] hash, byte[] salt, Guid userTypeId)
    {
        UserId = Guid.NewGuid();

        ChangeUserName(userName);
        ChangeEmail(email);
        PhoneNumber = phoneNumber;
        Hash = hash;
        Salt = salt;

        var currentDateTime = DateTime.UtcNow;

        CreatedOn = currentDateTime;
        LastUpdatedOn = currentDateTime;

        UserTypeId = userTypeId;
    }

    private void ChangeUserName(string userName)
    {
        userName = userName.Trim();

        AddNotifications(new Contract<User>()
            .IsNotNullOrEmpty(userName, "UserName", "O nome de usuário não deve ser nulo ou vazio")
            .IsGreaterThan(userName, 5, "UserName", "O nome de usuário deve conter mais de cinco carácteres")
            .Matches(userName, "[a-zA-Z]+", "UserName", "O nome de usuário deve conter letras")
        );

        if (IsValid)
            UserName = userName;
    }

    private void ChangeEmail(string email)
    {
        email = email.Trim();

        AddNotifications(new Contract<User>()
            .IsNotNullOrEmpty(email, "Email", "O e-mail não deve ser nulo ou vazio")
            .IsEmail(email, "Email", "O e-mail digitado não é válido")
        );

        if (IsValid)
            Email = email;
    }
}
