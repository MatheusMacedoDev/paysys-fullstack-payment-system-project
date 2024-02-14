using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("AdministratorUsers")]
[Index(nameof(UserId), IsUnique = true)]
public class AdministratorUser
{
    [Key]
    public Guid AdministratorId { get; private set; }

    [Required]
    public string? AdministratorName { get; private set; }

    [Required]
    [Column(TypeName = "CHAR(11)")]
    public string? AdministratorCPF { get; private set; }

    // User Reference

    [Required]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    private AdministratorUser()
    {
    }

    public static AdministratorUser Create(string administratorName, string administratorCPF, Guid userId)
    {
        var administrator = new AdministratorUser();

        administrator.AdministratorName = administratorName;
        administrator.AdministratorCPF = administratorCPF;

        administrator.UserId = userId;

        return administrator;
    }
}
