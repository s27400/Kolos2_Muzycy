namespace Kolos2_Muzycy.DTOs;

public class MuzykZUtworami
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string? Pseudonim { get; set; }
    public IEnumerable<UtworDTO> Utwory { get; set; }
}