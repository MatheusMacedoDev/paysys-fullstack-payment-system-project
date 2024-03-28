using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("shopkeepers")]
[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(ShopkeeperCNJP), IsUnique = true)]
public class Shopkeeper
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

        FancyName = fancyName;
        CompanyName = companyName;
        ShopkeeperCNJP = shopkeeperCNJP;

        Balance = 0;

        UserId = userId;
    }

    public void IncreaseMoney(double amount)
    {
        Balance += amount;
    }
}

