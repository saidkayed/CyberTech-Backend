using CyberTech_Backend.Controllers.DTO;
using CyberTech_Backend.Data;
using CyberTech_Backend.Helper;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyberTech_Backend.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly CyberTech_APIContext _context;

    public PlayerRepository(CyberTech_APIContext context)
    {
        _context = context;
    }

    public async Task<Player> CreatePlayer(PlayerLoginDTO player)
    {
       var HashedPassword = PasswordHelper.GeneratePasswordHash(player.Password);

        Player p = new Player
        {
            Email = player.Email,
            PasswordHash = HashedPassword,
            Username = player.Username

        };

        _context.Player.Add(p);
        await _context.SaveChangesAsync();

        return p;
    }
    public async Task DeletePlayer(int id)
    {
        var player = await _context.Player.FindAsync(id);

        if (player != null)
        {
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
    public Task<List<Player>> GetAllPlayers()
    {
        //return all player with only email
        return _context.Player.Select(p => new Player
        {
            Email = p.Email,
        }).ToListAsync();
    }
    public async Task<Player> GetPlayerById(int id)
    {
        return await _context.Player.FindAsync(id);
    }
}
