using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("administrator_users")]
[Index(nameof(UserId), IsUnique = true)]
public class AdministratorUser
{
    [Key]
    [Column("administrator_id")]
    public Guid AdministratorId { get; private set; }

    public Name? AdministratorName { get; private set; }
    public CPF? AdministratorCPF { get; private set; }

    // User Reference

    [Required]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    protected AdministratorUser()
    {
    }

    public AdministratorUser(string administratorName, string administratorCPF, Guid userId)
    {
        AdministratorId = Guid.NewGuid();

        AdministratorName = new Name(administratorName);
        AdministratorCPF = new CPF(administratorCPF);

        UserId = userId;
    }
}
