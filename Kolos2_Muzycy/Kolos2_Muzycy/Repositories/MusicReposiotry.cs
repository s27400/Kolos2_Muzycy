using Kolos2_Muzycy.DTOs;
using Kolos2_Muzycy.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Kolos2_Muzycy.Repositories;

public class MusicReposiotry : IMusicRepository
{
    private readonly MusicDbContext _context;

    public MusicReposiotry(MusicDbContext context)
    {
        _context = context;
    }

    public async Task<bool> checkIfMusicianExists(int id, CancellationToken token)
    {
        var checker = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.IdMuzyk == id, token);

        if (checker == null)
        {
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<MuzykZUtworami>> GetMusicianWithTracks(int id, CancellationToken token)
    {
        var musician = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.IdMuzyk == id, token);

        MuzykZUtworami res = new MuzykZUtworami();

        res.IdMuzyk = musician.IdMuzyk;
        res.Imie = musician.Imie;
        res.Nazwisko = musician.Nazwisko;
        res.Pseudonim = musician.Pseudonim;

        var list = _context.Muzycy
            .Include(m => m.UtworyMuzyk)
            .ThenInclude(um => um.Muzycy);

        var toDTO = await list.Where(x => x.IdMuzyk == id)
            .Select(music => new MuzykZUtworami()
            {
                IdMuzyk = music.IdMuzyk,
                Imie = music.Imie,
                Nazwisko = musician.Nazwisko,
                Pseudonim = music.Pseudonim,
                Utwory = music.UtworyMuzyk.Select(
                    t => new UtworDTO()
                    {
                        CzasTrwania = t.CzasTrwania,
                        IdUtwor = t.IdUtwor,
                        NazwaUtworu = t.NazwaUtworu
                    }).ToList()
            }).ToListAsync(token);


        return toDTO;

    }
}