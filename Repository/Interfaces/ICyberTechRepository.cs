using CyberTech_Backend.Models;

namespace CyberTech_Backend.Repository.Interfaces;

public interface ICyberTechRepository
{
    public Task<List<CyberTech>> GetAllCyberTechs();
    public Task<CyberTech> GetCyberTechById(int id);
    public Task<CyberTech> CreateCyberTech(CyberTech cyberTech);
    public Task DeleteCyberTech(int id);
}
