using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_categories")]
[Index(nameof(TransferCategoryName), IsUnique = true)]
public class TransferCategory
{
    [Key]
    [Column("transfer_category_id")]
    public Guid TransferCategoryId { get; set; }

    [Required]
    [Column("transfer_category_name")]
    public string? TransferCategoryName { get; private set; }

    private TransferCategory()
    {
    }

    public static TransferCategory Create(string categoryName)
    {
        var category = new TransferCategory();

        category.TransferCategoryId = Guid.NewGuid();
        category.TransferCategoryName = categoryName;

        return category;
    }
}
