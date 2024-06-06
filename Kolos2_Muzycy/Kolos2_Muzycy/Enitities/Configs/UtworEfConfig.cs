using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_Muzycy.Enitities.Configs;

public class UtworEfConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.HasKey(c => c.IdUtwor).HasName("IdUtwor");
        builder.Property(c => c.IdUtwor).UseIdentityColumn();

        builder.HasOne(t => t.NavigationAlbum)
            .WithMany(ct => ct.UtworyAlbum)
            .HasForeignKey(ct => ct.IdUtwor)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.NazwaUtworu).IsRequired().HasMaxLength(30);
        builder.Property(t => t.CzasTrwania).IsRequired();

        builder.ToTable("Utwor");

        Utwor[] utwors =
        {
            new Utwor()
            {
                IdUtwor = 1, NazwaUtworu = "al1na1", CzasTrwania = 2.2F, IdAlbum = 1
            },
            new Utwor()
            {
                IdUtwor = 2, NazwaUtworu = "al1na2", CzasTrwania = 3.30F, IdAlbum = 1
            },
            new Utwor()
            {
                IdUtwor = 3, NazwaUtworu = "al12na1", CzasTrwania = 5.50F, IdAlbum = 2
            }
        };

        builder.HasData(utwors);
    }
}