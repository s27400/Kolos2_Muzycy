using Kolos2_Muzycy.DTOs;

namespace Kolos2_Muzycy.Repositories;

public interface IMusicRepository
{
    public Task<bool> checkIfMusicianExists(int id, CancellationToken token);
    public Task<IEnumerable<MuzykZUtworami>> GetMusicianWithTracks(int id, CancellationToken token);
}