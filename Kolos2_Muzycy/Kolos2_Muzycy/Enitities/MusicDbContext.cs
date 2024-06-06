using Kolos2_Muzycy.Enitities.Configs;
using Microsoft.EntityFrameworkCore;

namespace Kolos2_Muzycy.Enitities;

public class MusicDbContext : DbContext
{
    public virtual DbSet<Album> Albumy { get; set; }
    public virtual DbSet<Utwor> Utwory { get; set; }
    public virtual DbSet<Muzyk> Muzycy { get; set; }
    public virtual DbSet<Wytwornia> Wytwornie { get; set; }

    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WytworniaEfConfig).Assembly);
    }
    
}