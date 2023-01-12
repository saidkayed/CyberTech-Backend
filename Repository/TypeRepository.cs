using CyberTech_Backend.Data;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CyberTech_Backend.Repository;

public class TypeRepository : ITypeRepository
{
    private readonly CyberTech_APIContext _context;

    public TypeRepository(CyberTech_APIContext context)
    {
        _context = context;
    }

    public async Task<Models.Type> CreateType(Models.Type type)
    {
        _context.Type.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }
    public async Task DeleteType(int id)
    {
        var type = await _context.Type.FindAsync(id);

        if (type != null)
        {
            _context.Type.Remove(type);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Models.Type>> GetAllTypes()
    {
        return await _context.Type.ToListAsync();
    }
    public async Task<Models.Type> GetTypeById(int id)
    {
        return await _context.Type.FindAsync(id);
    }
}
