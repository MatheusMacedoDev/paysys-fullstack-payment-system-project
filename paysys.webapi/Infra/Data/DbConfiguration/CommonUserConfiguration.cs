using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class CommonUserConfiguration : IEntityTypeConfiguration<CommonUser>
{
    public void Configure(EntityTypeBuilder<CommonUser> builder)
    {
        builder.OwnsOne(e => e.CommonUserName)
            .Property(p => p.NameText)
            .HasColumnName("common_user_name")
            .IsRequired(true);
    }
}
