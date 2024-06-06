namespace Kolos2_Muzycy.Enitities;

public class Album
{
    public int IdAlbum { get; set; }
    public string NazwaAlbumu { get; set; }
    public DateTime DataWydania { get; set; }
    public int IdWytwornia { get; set; }
    public virtual Wytwornia NavigationWytwornia { get; set; }
    public virtual ICollection<Utwor> UtworyAlbum { get; set; } = new List<Utwor>();
}