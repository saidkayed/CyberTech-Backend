using CyberTech_Backend.Models;

namespace CyberTech_Backend.Repository.Interfaces;

public interface IMoveRepository
{
    public Task<List<Move>> GetAllMoves();
    public Task<Move> GetMoveById(int id);
    public Task<Move> CreateMove(Move move);
    public Task DeleteMove(int id);
}
