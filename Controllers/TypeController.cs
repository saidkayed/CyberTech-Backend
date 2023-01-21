using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyberTech_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TypeController : ControllerBase
{


    private readonly ITypeRepository _typeRepository;

    public TypeController(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    [HttpGet]
    [Route("/Types")]
    public async Task<ActionResult<List<Models.Type>>> GetAllTypes()
    {
        var types = await _typeRepository.GetAllTypes();
        return Ok(types);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Type>> GetTypeById(int id)
    {

        var type = await _typeRepository.GetTypeById(id);

        if (type == null)
        {
            return NotFound();
        }

        return Ok(type);
    }

    [HttpPost, Authorize(Roles = "Admin")]
    [Route("/CreateType")]
    public async Task<ActionResult<Models.Type>> CreateType([FromBody] Models.Type type)
    {
        var newType = await _typeRepository.CreateType(type);
        return CreatedAtAction(nameof(GetTypeById), new { id = newType.Id }, newType);
    }
    
    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteType(int id)
    {
        await _typeRepository.DeleteType(id);
        return NoContent();
    }


}
