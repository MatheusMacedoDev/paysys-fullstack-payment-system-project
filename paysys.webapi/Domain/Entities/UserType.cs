using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace paysys.webapi.Domain.Entities;

[Table("UserTypes")]
public class UserType
{
    [Key]
    public Guid UserTypeId { get; private set; }

    public String? TypeName { get; private set; }

    private UserType()
    {
    }

    public static UserType Create(string typeName)
    {
        var userType = new UserType();

        userType.UserTypeId = Guid.NewGuid();

        userType.TypeName = FormatTypeName(typeName);

        return userType;
    }

    private static string FormatTypeName(string name)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
    }
}
