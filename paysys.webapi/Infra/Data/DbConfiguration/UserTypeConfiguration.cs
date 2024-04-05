using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.OwnsOne(userType => userType.TypeName, ownedBuilder =>
        {
            ownedBuilder.Property(typeName => typeName.NameText)
                .HasColumnName("user_type_name")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired(true);

            ownedBuilder.HasIndex(typeName => typeName.NameText)
                .IsUnique();
        });
    }
}
