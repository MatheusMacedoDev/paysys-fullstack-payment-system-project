using System.ComponentModel.DataAnnotations;

namespace paysys.webapi.Domain.Entities;

public class UserType
{
    [Key]
    public Guid UserTypeId { get; private set; }

    public String? TypeName { get; private set; }
}
