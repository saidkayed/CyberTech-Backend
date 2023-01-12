namespace CyberTech_Backend.Repository.Interfaces;
using CyberTech_Backend.Models;
public interface ITypeRepository
{
    public Task<List<Type>> GetAllTypes();
    public Task<Type> GetTypeById(int id);
    public Task<Type> CreateType(Type type);
    public Task DeleteType(int id);
}
