using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;

namespace paysys.webapi.Domain.Entities;

[Table("user_types")]
[Index(nameof(TypeName), IsUnique = true)]
public class UserType : Notifiable<Notification>
{
    [Key]
    [Column("user_type_id")]
    public Guid UserTypeId { get; private set; }

    [Column("user_type_name")]
    public String? TypeName { get; private set; }

    public UserType(string typeName)
    {
        UserTypeId = Guid.NewGuid();

        ChangeTypeName(typeName);
    }

    public void ChangeTypeName(string newTypeName)
    {
        var formatedTypeName = FormatTypeName(newTypeName);

        AddNotifications(new Contract<UserType>()
            .IsNotNullOrEmpty(formatedTypeName, "TypeName", "O nome do tipo de usuário não pode ser nulo ou vazio")
            .IsGreaterOrEqualsThan(formatedTypeName, 4, "TypeName", "O nome do tipo de usuário deve conter mais fe quatro caracteres")
            .Matches(formatedTypeName, @"^(\s?[A-Z][a-z]+\s?)+$", "TypeName", "Nome de tipo de usuário inválido")
        );

        TypeName = formatedTypeName;
    }

    private string FormatTypeName(string name)
    {
        var lowerCaseName = name.ToLower();
        var pascalCaseName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lowerCaseName);

        return pascalCaseName;
    }
}
