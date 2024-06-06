using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_Muzycy.Enitities.Configs;

public class WytworniaEfConfig : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder.HasKey(c => c.IdWytwornia).HasName("IdWytwornia");
        builder.Property(c => c.IdWytwornia).UseIdentityColumn();

        builder.Property(c => c.Nazwa).IsRequired().HasMaxLength(50);
        
        builder.ToTable("Wytwornia");

        Wytwornia[] wytwornias =
        {
            new Wytwornia()
            {
                IdWytwornia = 1, Nazwa = "Jasie"
            },
            new Wytwornia()
            {
                IdWytwornia = 2, Nazwa = "Muchy"
            }
        };

        builder.HasData(wytwornias);
    }
}