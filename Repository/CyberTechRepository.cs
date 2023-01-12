using CyberTech_Backend.Data;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CyberTech_Backend.Repository;

public class CyberTechRepository : ICyberTechRepository
{

    private readonly CyberTech_APIContext _context;

    public CyberTechRepository(CyberTech_APIContext context)
    {
        _context = context;
    }

    public async Task<CyberTech> CreateCyberTech(CyberTech cyberTech)
    {

        var type = await _context.Type.FindAsync(cyberTech.Type.Id);
        var moves = await _context.Move.Where(m => cyberTech.Moves.Contains(m)).ToListAsync();
        if (type == null || moves.IsNullOrEmpty())
        {
            throw new Exception("Invalid Type or Move");
        }
        cyberTech.Type = type;
        cyberTech.Moves = moves;
        _context.CyberTech.Add(cyberTech);
        await _context.SaveChangesAsync();
        return cyberTech;

    }
    public async Task DeleteCyberTech(int id)
    {
        var cyberTech = await _context.CyberTech.FindAsync(id);

        if (cyberTech != null)
        {
            _context.CyberTech.Remove(cyberTech);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<CyberTech>> GetAllCyberTechs()
    {
        return await _context.CyberTech.ToListAsync();
    }
    public async Task<CyberTech> GetCyberTechById(int id)
    {
        return await _context.CyberTech.FindAsync(id);
    }
}
