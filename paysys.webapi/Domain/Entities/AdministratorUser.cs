using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("administrator_users")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(AdministratorCPF), IsUnique = true)]
public class AdministratorUser
{
    [Key]
    [Column("administrator_id")]
    public Guid AdministratorId { get; private set; }

    [Required]
    [Column("administrator_name")]
    public string? AdministratorName { get; private set; }

    [Required]
    [Column("administrator_cpf", TypeName = "CHAR(11)")]
    public string? AdministratorCPF { get; private set; }

    // User Reference

    [Required]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    private AdministratorUser()
    {
    }

    public static AdministratorUser Create(string administratorName, string administratorCPF, Guid userId)
    {
        var administrator = new AdministratorUser();

        administrator.AdministratorId = Guid.NewGuid();
        administrator.AdministratorName = administratorName;
        administrator.AdministratorCPF = administratorCPF;

        administrator.UserId = userId;

        return administrator;
    }
}
