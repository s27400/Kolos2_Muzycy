using Kolos2_Muzycy.DTOs;

namespace Kolos2_Muzycy.Services;

public interface IMusicService
{
    public Task<bool> checker(int id, CancellationToken token);
    public Task<IEnumerable<MuzykZUtworami>> GetMusician(int id, CancellationToken token);
    public Task<string> AddMusicianWithTrack(ToAddDTO dto, CancellationToken token);
}