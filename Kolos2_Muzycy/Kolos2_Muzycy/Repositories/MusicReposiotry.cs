using System.Diagnostics;
using Kolos2_Muzycy.DTOs;
using Kolos2_Muzycy.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public async Task<string> AddMusician(ToAddDTO dto, CancellationToken token)
    {
        await _context.Muzycy.AddAsync(new Muzyk()
        {
            Imie = dto.Imie,
            Nazwisko = dto.Nazwisko,
            Pseudonim = dto.Pseudonim
        }, token);

        await _context.SaveChangesAsync(token);
        return "Added musucian";
    }

    public async Task<int> GetNewMusicianId(ToAddDTO dto, CancellationToken token)
    {
        var res = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.Imie == dto.Imie && x.Nazwisko == dto.Nazwisko, token);

        return res.IdMuzyk;
    }

    public async Task<int> CheckIfTrackExist(ToAddDTO dto, CancellationToken token)
    {
        var checker = await _context.Utwory
            .FirstOrDefaultAsync(x => x.IdUtwor == dto.IdUtworu);

        if (checker != null)
        {
            return checker.IdUtwor;
        }

        return 0;
    }

    public async Task<string> AddTrack(ToAddDTO dto, CancellationToken token)
    {
            await _context.Utwory.AddAsync(new Utwor()
            {
                CzasTrwania = dto.CzasTrwania,
                NazwaUtworu = dto.NazwaUtworu,
                IdAlbum = dto.IdAlbum
            }, token);
            await _context.SaveChangesAsync(token);
            return "Dodalem utwor";
    }

    public async Task<int> GetNewTrackId(ToAddDTO dto, CancellationToken token)
    {
        var res = await _context.Utwory
            .FirstOrDefaultAsync(x => x.NazwaUtworu == dto.NazwaUtworu && x.IdAlbum == dto.IdAlbum, token);
        return res.IdUtwor;
    }

    public async Task<string> AddTrackToMusician(int idMuzyk, int idUtwor, CancellationToken token)
    {
        Muzyk muzyk = await _context.Muzycy.SingleAsync(x => x.IdMuzyk == idMuzyk, token);
        Utwor utwor = await _context.Utwory.SingleAsync(x => x.IdUtwor == idUtwor, token);
        
        muzyk.UtworyMuzyk.Add(utwor);
        
        await _context.SaveChangesAsync(token);
        return "Dodalem muzyka do utwor";
    }

}