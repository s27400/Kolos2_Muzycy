using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_Muzycy.Enitities.Configs;

public class MuzykEfConfig : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        builder.HasKey(c => c.IdMuzyk).HasName("IdMuzyk");
        builder.Property(c => c.IdMuzyk).UseIdentityColumn();

        builder.Property(c => c.Imie).IsRequired().HasMaxLength(30);
        builder.Property(c => c.Nazwisko).IsRequired().HasMaxLength(40);
        builder.Property(c => c.Pseudonim).HasMaxLength(50);

        builder.HasMany(t => t.UtworyMuzyk)
            .WithMany(t => t.Muzycy)
            .UsingEntity<Dictionary<string, object>>(
                "WykonawcaUtworu",
                j => j.HasOne<Utwor>().WithMany().HasForeignKey("IdUtwor"),
                j => j.HasOne<Muzyk>().WithMany().HasForeignKey("IdMuzyk")).HasData(
                new { IdUtwor = 1, IdMuzyk = 1 },
                new { IdUtwor = 1, IdMuzyk = 2 },
                new { IdUtwor = 2, IdMuzyk = 1 },
                new { IdUtwor = 3, IdMuzyk = 2 });

        builder.ToTable("Muzyk");

        Muzyk[] muzyks =
        {
            new Muzyk()
            {
                IdMuzyk = 1, Imie = "Adam", Nazwisko = "Nowak", Pseudonim = "Adasio200"
            },
            new Muzyk()
            {
                IdMuzyk = 2, Imie = "Adrianna", Nazwisko = "Malinowska"
            }
        };

        builder.HasData(muzyks);
    }
}