using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_categories")]
public class TransferCategory
{
    [Key]
    [Column("transfer_category_id")]
    public Guid TransferCategoryId { get; set; }

    public Name? TransferCategoryName { get; private set; }

    public TransferCategory(string transferCategoryName)
    {
        TransferCategoryId = Guid.NewGuid();

        TransferCategoryName = new Name(
            nameText: transferCategoryName,
            maxCharacters: 4
        );
    }
}
