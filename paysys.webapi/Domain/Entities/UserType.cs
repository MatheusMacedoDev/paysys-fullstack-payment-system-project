using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.Entities;

[Table("UserTypes")]
public class UserType
{
    [Key]
    public Guid UserTypeId { get; private set; }

    public String? TypeName { get; private set; }
}
