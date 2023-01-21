using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CyberTech_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoveController : ControllerBase
{
    private readonly IMoveRepository _moveRepository;

    public MoveController(IMoveRepository moveRepository)
    {
        _moveRepository = moveRepository;
    }

    [HttpGet]
    [Route("/Moves")]
    public async Task<ActionResult<List<Move>>> GetAllMoves()
    {
        var moves = await _moveRepository.GetAllMoves();
        return Ok(moves);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Move>> GetMoveById(int id)
    {

        var move = await _moveRepository.GetMoveById(id);

        if (move == null)
        {
            return NotFound();
        }

        return Ok(move);
    }

    [HttpPost, Authorize(Roles = "Admin")]
    [Route("/CreateMove")]
    public async Task<ActionResult<Move>> CreateMove([FromBody] Move move)
    {
        var newMove = await _moveRepository.CreateMove(move);
        return CreatedAtAction(nameof(GetMoveById), new { id = newMove.Id }, newMove);
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteMove(int id)
    {
        await _moveRepository.DeleteMove(id);
        return NoContent();
    }
}
