using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Utils;

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
        var formatedTypeName = StringFormatter.FormatToTitle(newTypeName);

        AddNotifications(new Contract<UserType>()
            .IsNotNullOrEmpty(formatedTypeName, "TypeName", "O nome do tipo de usuário não pode ser nulo ou vazio")
            .IsGreaterOrEqualsThan(formatedTypeName, 4, "TypeName", "O nome do tipo de usuário deve conter mais fe quatro caracteres")
            .Matches(formatedTypeName, @"^(\s?[A-Z][a-z]+\s?)+$", "TypeName", "Nome de tipo de usuário inválido")
        );

        TypeName = formatedTypeName;
    }
}
