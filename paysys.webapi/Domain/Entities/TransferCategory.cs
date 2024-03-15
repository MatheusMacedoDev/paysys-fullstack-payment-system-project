using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_categories")]
public class TransferCategory
{
    [Key]
    [Column("transfer_category_id")]
    public Guid TransferCategoryId { get; set; }

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
