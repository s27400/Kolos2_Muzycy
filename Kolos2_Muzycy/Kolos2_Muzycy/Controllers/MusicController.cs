using Kolos2_Muzycy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2_Muzycy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly IMusicService _musicService;

    public MusicController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMusicianWithAllTracks(int id, CancellationToken token)
    {
        bool verify = await _musicService.checker(id, token);

        if (verify)
        {
            return Ok(await _musicService.GetMusician(id, token));
        }

        return NotFound($"Muzyk z id: {id} nie istnieje");
    }
}