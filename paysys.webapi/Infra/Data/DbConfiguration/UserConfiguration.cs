using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(e => e.Password)
            .Property(p => p.Hash)
            .HasColumnName("password_hash")
            .HasColumnType("BYTEA")
            .IsRequired(true);

        builder.OwnsOne(e => e.Password)
            .Property(p => p.Salt)
            .HasColumnName("password_salt")
            .HasColumnType("BYTEA")
            .IsRequired(true);
    }
}
