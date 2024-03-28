using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("shopkeepers")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(ShopkeeperCNJP), IsUnique = true)]
public class Shopkeeper : Notifiable<Notification>
{
    [Key]
    [Column("shopkeeper_id")]
    public Guid ShopkeeperId { get; private set; }

    [Required]
    [Column("fancy_name")]
    public string? FancyName { get; private set; }

    [Required]
    [Column("company_name")]
    public string? CompanyName { get; private set; }


    [Required]
    [Column("shopkeeper_cnpj", TypeName = "CHAR(14)")]
    public string? ShopkeeperCNJP { get; private set; }

    [Required]
    [Column("balance", TypeName = "MONEY")]
    public double Balance { get; private set; }

    // User Reference

    [Required]
    [Column("user_id")]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    public Shopkeeper(string fancyName, string companyName, string shopkeeperCNJP, Guid userId)
    {
        ShopkeeperId = Guid.NewGuid();

        ChangeFancyName(fancyName);
        CompanyName = companyName;
        ShopkeeperCNJP = shopkeeperCNJP;

        Balance = 0;

        UserId = userId;
    }

    private void ChangeFancyName(string fancyName)
    {
        fancyName = fancyName.Trim();

        AddNotifications(new Contract<Shopkeeper>()
            .IsNotNullOrEmpty(fancyName, "FancyName", "O nome fantasia não pode ser nulo ou vazio")
            .Matches(fancyName, @"^(\s?[A-Z][a-zA-Z]+\s?)+$", "FancyName", "Nome fantasia inválido")
        );

        FancyName = fancyName;
    }

    public void IncreaseMoney(double amount)
    {
        Balance += amount;
    }
}

