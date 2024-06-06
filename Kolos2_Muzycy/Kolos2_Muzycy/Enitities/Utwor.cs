namespace Kolos2_Muzycy.Enitities;

public class Utwor
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public float CzasTrwania { get; set; }
    public int IdAlbum { get; set; }
    public virtual Album NavigationAlbum { get; set; }
    public virtual ICollection<Muzyk> Muzycy { get; set; } = new List<Muzyk>();
}