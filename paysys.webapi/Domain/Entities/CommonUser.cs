using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("common_users")]
[Index(nameof(UserId), IsUnique = true)]
public class CommonUser
{
    [Key]
    [Column("common_user_id")]
    public Guid CommonUserId { get; private set; }

    [Required]
    [Column("common_user_name")]
    public string? CommonUserName { get; private set; }

    [Required]
    [Column("common_user_cpf", TypeName = "CHAR(11)")]
    public string? CommonUserCPF { get; private set; }

    [Required]
    [Column("balance", TypeName = "MONEY")]
    public double Balance { get; private set; }

    // User Reference

    [Required]
    [Column("user_id")]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    private CommonUser()
    {
    }

    public static CommonUser Create(string commonUserName, string commonUserCPF, Guid userId)
    {
        var commonUser = new CommonUser();

        commonUser.CommonUserId = Guid.NewGuid();
        commonUser.CommonUserName = commonUserName;
        commonUser.CommonUserCPF = commonUserCPF;

        commonUser.UserId = userId;

        return commonUser;
    }
}

