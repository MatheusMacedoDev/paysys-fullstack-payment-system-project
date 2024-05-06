using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(user => user.UserName, ownedBuilder =>
        {
            ownedBuilder.Property(userName => userName.NameText)
                .HasColumnName("user_name")
                .IsRequired();

            ownedBuilder.HasIndex(userName => userName.NameText)
                .IsUnique();
        });

        builder.OwnsOne(user => user.Email, ownedBuilder =>
        {
            ownedBuilder.Property(email => email.EmailText)
                .HasColumnName("email")
                .IsRequired();

            ownedBuilder.HasIndex(email => email.EmailText)
                .IsUnique();
        });

        builder.OwnsOne(user => user.PhoneNumber)
            .Property(phoneNumber => phoneNumber.PhoneNumberText)
            .HasColumnName("phone_number")
            .HasColumnType("CHAR(11)")
            .IsRequired();

        builder.OwnsOne(user => user.Password)
            .Property(password => password.Hash)
            .HasColumnName("password_hash")
            .HasColumnType("BYTEA")
            .IsRequired();

        builder.OwnsOne(user => user.Password)
            .Property(password => password.Salt)
            .HasColumnName("password_salt")
            .HasColumnType("BYTEA")
            .IsRequired();
    }
}
