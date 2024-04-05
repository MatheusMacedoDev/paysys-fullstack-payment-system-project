using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Domain.ValueObjects;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.Entities;

[Table("user_types")]
public class UserType
{
    [Key]
    [Column("user_type_id")]
    public Guid UserTypeId { get; private set; }

    public Name? TypeName { get; private set; }

    public UserType(string typeName)
    {
        UserTypeId = Guid.NewGuid();

        TypeName = new Name(
            nameText: StringFormatter.FormatToTitle(typeName),
            maxCharacters: 4
        );
    }
}
