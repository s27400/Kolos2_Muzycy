using System.ComponentModel.DataAnnotations;

namespace Kolos2_Muzycy.DTOs;

public class ToAddDTO
{
    [Required]
    [MaxLength(30)]
    public string Imie { get; set; }
    [Required]
    [MaxLength(40)]
    public string Nazwisko { get; set; }
    [MaxLength(50)]
    public string Pseudonim { get; set; }

    public int IdUtworu { get; set; } = 0;
    [MaxLength(30)]
    public string NazwaUtworu { get; set; }
    public float CzasTrwania { get; set; }
    public int IdAlbum { get; set; }
    
}