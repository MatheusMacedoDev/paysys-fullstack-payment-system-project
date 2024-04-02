using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("common_users")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(CommonUserCPF), IsUnique = true)]
public class CommonUser : Notifiable<Notification>
{
    [Key]
    [Column("common_user_id")]
    public Guid CommonUserId { get; private set; }

    public Name? CommonUserName { get; private set; }

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

    protected CommonUser()
    {
    }

    public CommonUser(string commonUserName, string commonUserCPF, Guid userId)
    {
        CommonUserId = Guid.NewGuid();

        CommonUserName = new Name(commonUserName);
        ChangeCommonUserCPF(commonUserCPF);

        UserId = userId;
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
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new ArgumentException("The sender have not enough money to make this transfer.");
        }

    }

    public void IncreaseMoney(double amount)
    {
        Balance += amount;
    }
}

