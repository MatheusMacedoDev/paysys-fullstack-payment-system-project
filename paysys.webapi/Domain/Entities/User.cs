using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; private set; }

    public UserName? UserName { get; private set; }
    public Email? Email { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public Password? Password { get; private set; }

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

    protected User()
    {
    }

    public User(string userName, string email, string phoneNumber, string password, Guid userTypeId, ICryptographyStrategy cryptographyStrategy)
    {
        UserId = Guid.NewGuid();

        UserName = new UserName(userName);
        Email = new Email(email);
        PhoneNumber = new PhoneNumber(phoneNumber);
        Password = new Password(password, cryptographyStrategy);

        var currentDateTime = DateTime.UtcNow;

        CreatedOn = currentDateTime;
        LastUpdatedOn = currentDateTime;

        UserTypeId = userTypeId;
    }
}
