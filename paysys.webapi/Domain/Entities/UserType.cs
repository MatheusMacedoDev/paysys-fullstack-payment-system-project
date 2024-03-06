using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace paysys.webapi.Domain.Entities;

[Table("user_types")]
public class UserType
{
    [Key]
    [Column("user_type_id")]
    public Guid UserTypeId { get; private set; }

    [Column("user_type_name")]
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

    public void SetTypeName(string newTypeName)
    {
        var formatedTypeName = FormatTypeName(newTypeName);
        TypeName = formatedTypeName;
    }

    private static string FormatTypeName(string name)
    {
        var lowerCaseName = name.ToLower();
        var pascalCaseName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lowerCaseName);

        return pascalCaseName;
    }
}
