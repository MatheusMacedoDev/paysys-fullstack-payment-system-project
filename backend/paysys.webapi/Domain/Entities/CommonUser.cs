using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("common_users")]
[Index(nameof(UserId), IsUnique = true)]
public class CommonUser
{
    [Key]
    [Column("common_user_id")]
    public Guid CommonUserId { get; private set; }

    public Name? CommonUserName { get; private set; }
    public CPF? CommonUserCPF { get; private set; }

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
        CommonUserCPF = new CPF(commonUserCPF);

        UserId = userId;
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

