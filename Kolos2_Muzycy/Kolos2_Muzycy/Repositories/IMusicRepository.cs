using Kolos2_Muzycy.DTOs;

namespace Kolos2_Muzycy.Repositories;

public interface IMusicRepository
{
    public Task<bool> checkIfMusicianExists(int id, CancellationToken token);
    public Task<IEnumerable<MuzykZUtworami>> GetMusicianWithTracks(int id, CancellationToken token);
    public Task<string> AddMusician(ToAddDTO dto, CancellationToken token);
    public Task<int> GetNewMusicianId(ToAddDTO dto, CancellationToken token);
    public Task<int> CheckIfTrackExist(ToAddDTO dto, CancellationToken token);
    public Task<string> AddTrack(ToAddDTO dto, CancellationToken token);
    public Task<int> GetNewTrackId(ToAddDTO dto, CancellationToken token);
    public Task<string> AddTrackToMusician(int idMuzyk, int idUtwor, CancellationToken token);




}