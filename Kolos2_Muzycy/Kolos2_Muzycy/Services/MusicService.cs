using Kolos2_Muzycy.DTOs;
using Kolos2_Muzycy.Repositories;
using Microsoft.Data.SqlClient;

namespace Kolos2_Muzycy.Services;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;

    public MusicService(IMusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }

    public async Task<bool> checker(int id, CancellationToken token)
    {
        return await _musicRepository.checkIfMusicianExists(id, token);
    }

    public async Task<IEnumerable<MuzykZUtworami>> GetMusician(int id, CancellationToken token)
    {
        return await _musicRepository.GetMusicianWithTracks(id, token);
    }

    public async Task<string> AddMusicianWithTrack(ToAddDTO dto, CancellationToken token)
    {
        string resMusician = await _musicRepository.AddMusician(dto, token);
        if (dto.IdUtworu == 0)
        {
            return resMusician;
        }
        else
        {
            int MuzykId = await _musicRepository.GetNewMusicianId(dto, token);
            int UtworId = await _musicRepository.CheckIfTrackExist(dto, token);
            if (UtworId == 0)
            {
                string resTrack = await _musicRepository.AddTrack(dto, token);
                UtworId = await _musicRepository.GetNewTrackId(dto, token);
            }

            await _musicRepository.AddTrackToMusician(MuzykId, UtworId, token);
            return "Dodalem muzyka do utworu";
        }
    }
}