using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2_Muzycy.Enitities.Configs;

public class AlbumEfConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(c => c.IdAlbum).HasName("IdAlbum");
        builder.Property(c => c.IdAlbum).UseIdentityColumn();

        builder.HasOne(t => t.NavigationWytwornia)
            .WithMany(ct => ct.Albumy)
            .HasForeignKey(ct => ct.IdWytwornia)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.NazwaAlbumu).IsRequired().HasMaxLength(30);
        builder.Property(t => t.DataWydania).IsRequired();

        builder.ToTable("Album");

        Album[] albums =
        {
            new Album()
            {
                IdAlbum = 1, NazwaAlbumu = "album1", DataWydania = DateTime.Today, IdWytwornia = 1
            },
            new Album()
            {
                IdAlbum = 2, NazwaAlbumu = "album2", DataWydania = DateTime.Today.AddDays(10), IdWytwornia = 1
            },
            new Album()
            {
                IdAlbum = 3, NazwaAlbumu = "album3", DataWydania = DateTime.Today.AddMonths(3), IdWytwornia = 2

            }
        };

        builder.HasData(albums);

    }
}