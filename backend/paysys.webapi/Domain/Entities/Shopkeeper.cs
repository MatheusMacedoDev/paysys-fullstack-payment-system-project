using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("shopkeepers")]
[Index(nameof(UserId), IsUnique = true)]
public class Shopkeeper
{
    [Key]
    [Column("shopkeeper_id")]
    public Guid ShopkeeperId { get; private set; }

    public CorporateName? FancyName { get; private set; }
    public CorporateName? CompanyName { get; private set; }

    public CNPJ? ShopkeeperCNJP { get; private set; }

    [Required]
    [Column("balance", TypeName = "MONEY")]
    public double Balance { get; private set; }

    // User Reference

    [Required]
    [Column("user_id")]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; private set; }

    protected Shopkeeper()
    {
    }

    public Shopkeeper(string fancyName, string companyName, string shopkeeperCNJP, Guid userId)
    {
        ShopkeeperId = Guid.NewGuid();

        FancyName = new CorporateName(fancyName);
        CompanyName = new CorporateName(companyName);
        ShopkeeperCNJP = new CNPJ(shopkeeperCNJP);

        Balance = 0;

        UserId = userId;
    }

    public void IncreaseMoney(double amount)
    {
        Balance += amount;
    }
}

