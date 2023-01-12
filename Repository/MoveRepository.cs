using CyberTech_Backend.Data;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyberTech_Backend.Repository;

public class MoveRepository : IMoveRepository
{
    private readonly CyberTech_APIContext _context;

    public MoveRepository(CyberTech_APIContext context)
    {
        _context = context;
    }

    public async Task<Move> CreateMove(Move move)
    {
        _context.Add(move);
        await _context.SaveChangesAsync();
        return move;
        
    }
    public async Task DeleteMove(int id)
    {
        var move = await _context.Move.FindAsync(id);
        
        if (move != null)
        {
            _context.Move.Remove(move);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Move>> GetAllMoves()
    {
        return await _context.Move.ToListAsync();

    }
    public async Task<Move> GetMoveById(int id)
    {
        return await _context.Move.FindAsync(id);
    }
}
