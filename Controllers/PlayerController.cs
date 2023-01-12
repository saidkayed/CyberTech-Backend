using CyberTech_Backend.Controllers.DTO;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerController(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    [HttpGet]
    [Route("/Players")]
    public async Task<ActionResult<List<Player>>> GetAllPlayers()
    {
        var players = await _playerRepository.GetAllPlayers();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayerById(int id)
    {
        var player = await _playerRepository.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }
        return Ok(player);
    }

    [HttpPost]
    [Route("/CreatePlayer")]
    public async Task<ActionResult<Player>> CreatePlayer(PlayerLoginDTO player)
    {
        var newPlayer = await _playerRepository.CreatePlayer(player);
        return CreatedAtAction(nameof(GetPlayerById), new { id = newPlayer.Id }, newPlayer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlayer(int id)
    {
        var player = await _playerRepository.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }
        await _playerRepository.DeletePlayer(id);
        return NoContent();
    }
}
