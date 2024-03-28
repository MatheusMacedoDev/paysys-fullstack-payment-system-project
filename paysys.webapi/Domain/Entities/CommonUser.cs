using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("common_users")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(CommonUserCPF), IsUnique = true)]
public class CommonUser : Notifiable<Notification>
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

    public CommonUser(string commonUserName, string commonUserCPF, Guid userId)
    {
        CommonUserId = Guid.NewGuid();

        ChangeCommonUserName(commonUserName);
        ChangeCommonUserCPF(commonUserCPF);

        UserId = userId;
    }

    private void ChangeCommonUserName(string commonUserName)
    {
        commonUserName = commonUserName.Trim();

        AddNotifications(new Contract<CommonUser>()
            .IsNotNullOrEmpty(commonUserName, "CommonUserName", "O nome do usuário comum não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(commonUserName, 8, "CommonUserName", "O nome do usuário comum deve ter mais que oito letras")
            .Matches(commonUserName, @"^[A-Z][a-z]+(\s[A-Z][a-z]+)+$", "CommonUserName", "O nome conforme descrito é inválido")
        );

        CommonUserName = commonUserName;
    }

    private void ChangeCommonUserCPF(string commonUserCPF)
    {
        commonUserCPF = commonUserCPF.Trim();

        AddNotifications(new Contract<CommonUser>()
            .IsNotNullOrEmpty(commonUserCPF, "CommonUserCPF", "O CPF do usuário comum não deve ser nulo ou vazio")
            .Matches(commonUserCPF, @"^\d{11}$", "CommonUserCPF", "O CPF conforme descrito é inválido")
        );

        CommonUserCPF = commonUserCPF;
    }

    public void DecreaseMoney(double amount)
    {
        Balance -= amount;
    }

    public void IncreaseMoney(double amount)
    {
        Balance += amount;
    }
}

