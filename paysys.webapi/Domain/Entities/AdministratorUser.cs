using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("administrator_users")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(AdministratorCPF), IsUnique = true)]
public class AdministratorUser : Notifiable<Notification>
{
    [Key]
    [Column("administrator_id")]
    public Guid AdministratorId { get; private set; }

    public Name? AdministratorName { get; private set; }

    [Required]
    [Column("administrator_cpf", TypeName = "CHAR(11)")]
    public string? AdministratorCPF { get; private set; }

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
        ChangeAdministratorCPF(administratorCPF);

        UserId = userId;
    }

    private void ChangeAdministratorCPF(string administratorCPF)
    {
        administratorCPF = administratorCPF.Trim();

        AddNotifications(new Contract<AdministratorUser>()
            .IsNotNullOrEmpty(administratorCPF, "AdministratorCPF", "O CPF do administrador não deve ser nulo ou vazio")
            .Matches(administratorCPF, @"^\d{11}$", "AdministratorCPF", "O CPF conforme descrito é inválido")
        );

        AdministratorCPF = administratorCPF;
    }
}
