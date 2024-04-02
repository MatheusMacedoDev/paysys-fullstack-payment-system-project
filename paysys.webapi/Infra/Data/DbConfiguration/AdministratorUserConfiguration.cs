using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class AdministratorUserConfiguration : IEntityTypeConfiguration<AdministratorUser>
{
    public void Configure(EntityTypeBuilder<AdministratorUser> builder)
    {
        builder.OwnsOne(e => e.AdministratorName)
            .Property(p => p.NameText)
            .HasColumnName("administrator_name")
            .IsRequired(true);

        builder.OwnsOne(e => e.AdministratorCPF)
            .Property(p => p.CPFText)
            .HasColumnName("administrator_cpf")
            .HasColumnType("CHAR(11)")
            .IsRequired(true);
    }
}
