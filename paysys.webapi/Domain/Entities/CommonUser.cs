using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("CommonUsers")]
[Index(nameof(UserId), IsUnique = true)]
public class CommonUser
{
    [Key]
    public Guid CommonUserId { get; private set; }

    [Required]
    public string? CommonUserName { get; private set; }

    [Required]
    [Column(TypeName = "CHAR(11)")]
    public string? CommonUserCPF { get; private set; }

    // User Reference

    [Required]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    private CommonUser()
    {
    }

    public static CommonUser Create(string commonUserName, string commonUserCPF, Guid userId)
    {
        var commonUser = new CommonUser();

        commonUser.CommonUserName = commonUserName;
        commonUser.CommonUserCPF = commonUserCPF;

        commonUser.UserId = userId;

        return commonUser;
    }
}

