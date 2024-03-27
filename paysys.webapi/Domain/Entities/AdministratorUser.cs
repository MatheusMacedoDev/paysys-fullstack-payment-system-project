using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("administrator_users")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(AdministratorCPF), IsUnique = true)]
public class AdministratorUser : Notifiable<Notification>
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

    public AdministratorUser(string administratorName, string administratorCPF, Guid userId)
    {
        AdministratorId = Guid.NewGuid();
        ChangeAdministratorName(administratorName);
        AdministratorCPF = administratorCPF;

        UserId = userId;
    }

    private void ChangeAdministratorName(string administratorName)
    {
        administratorName = administratorName.Trim();

        AddNotifications(new Contract<AdministratorUser>()
            .IsNotNullOrEmpty(administratorName, "AdministratorName", "O nome do administrador não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(administratorName, 8, "AdministratorName", "O nome do administrador deve ter mais que oito letras")
            .Matches(administratorName, @"^[A-Z][a-z]+([ ][A-Z][a-z]+)+$", "AdministratorName", "O nome conforme descrito é inválido")
        );

        AdministratorName = administratorName;
    }
}
