using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_categories")]
[Index(nameof(TransferCategoryName), IsUnique = true)]
public class TransferCategory : Notifiable<Notification>
{
    [Key]
    [Column("transfer_category_id")]
    public Guid TransferCategoryId { get; set; }

    [Required]
    [Column("transfer_category_name")]
    public string? TransferCategoryName { get; private set; }

    public TransferCategory(string transferCategoryName)
    {
        TransferCategoryId = Guid.NewGuid();

        ChangeTransferCategoryName(transferCategoryName);
    }

    private void ChangeTransferCategoryName(string categoryName)
    {
        categoryName = StringFormatter.BasicClear(categoryName);

        AddNotifications(new Contract<TransferStatus>()
            .IsNotNullOrEmpty(categoryName, "TransferCategoryName", "O nome da categoria da transferência não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(categoryName, 4, "TransferCategoryName", "O nome da categoria da transferência deve conter mais de quatro caracteres")
            .Matches(categoryName, @"^(\s?[A-Z][a-z]+\s?)+$", "TransferCategoryName", "Nome da categoria da transferência inválido")
        );

        TransferCategoryName = categoryName;
    }
}
