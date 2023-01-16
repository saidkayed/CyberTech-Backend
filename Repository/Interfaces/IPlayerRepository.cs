using CyberTech_Backend.Controllers.DTO;
using CyberTech_Backend.Models;

namespace CyberTech_Backend.Repository.Interfaces;

public interface IPlayerRepository
{
    public Task<List<Player>> GetAllPlayers();
    public Task<Player> GetPlayerById(int id);
    public Task<Player> CreatePlayer(PlayerLoginDTO playerLogin);
    public Task DeletePlayer(int id);

    public Task<Player> GetPlayerByEmail(string email);
    
    public Task<Player> GetPlayerByUsername(string username);
}
