using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("Shopkeepers")]
[Index(nameof(UserId), IsUnique = true)]
public class Shopkeeper
{
    [Key]
    public Guid ShopkeeperId { get; private set; }

    [Required]
    public string? FancyName { get; private set; }

    [Required]
    public string? CompanyName { get; private set; }


    [Required]
    [Column(TypeName = "CHAR(14)")]
    public string? ShopkeeperCNJP { get; private set; }

    [Required]
    [Column(TypeName = "MONEY")]
    public double Balance { get; private set; }

    // User Reference

    [Required]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    private Shopkeeper()
    {
    }

    public static Shopkeeper Create(string fancyName, string companyName, string shopkeeperCNJP, Guid userId)
    {
        var shopkeeper = new Shopkeeper();

        shopkeeper.FancyName = fancyName;
        shopkeeper.CompanyName = companyName;
        shopkeeper.ShopkeeperCNJP = shopkeeperCNJP;
        shopkeeper.Balance = 0;

        shopkeeper.UserId = userId;

        return shopkeeper;
    }
}

