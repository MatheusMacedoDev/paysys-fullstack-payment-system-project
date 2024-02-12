using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("CommonUsers")]
[Index(nameof(UserId), IsUnique = true)]
public class CommonUser
{
    [Key]
    public Guid CommonUserId { get; set; }

    [Required]
    public string? CommonUserName { get; set; }

    [Required]
    [Column(TypeName = "CHAR(11)")]
    public string? CommonUserCPF { get; set; }

    // User Reference

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

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

