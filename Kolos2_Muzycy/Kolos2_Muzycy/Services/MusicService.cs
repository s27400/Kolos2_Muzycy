using Kolos2_Muzycy.DTOs;
using Kolos2_Muzycy.Repositories;

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
}