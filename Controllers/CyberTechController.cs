using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CyberTechController : ControllerBase
{
    private readonly ICyberTechRepository _cyberTechRepository;

    public CyberTechController(ICyberTechRepository cyberTechRepository)
    {
        _cyberTechRepository = cyberTechRepository;
    }

    [HttpGet]
    [Route("/CyberTechs")]
    public async Task<ActionResult<List<CyberTech>>> GetAllCyberTechs()
    {
        var cyberTechs = await _cyberTechRepository.GetAllCyberTechs();
        return Ok(cyberTechs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CyberTech>> GetCyberTechById(int id)
    {

        var cyberTech = await _cyberTechRepository.GetCyberTechById(id);

        if (cyberTech == null)
        {
            return NotFound();
        }

        return Ok(cyberTech);
    }

    [HttpPost]
    [Route("/CreateCyberTech")]
    public async Task<ActionResult<CyberTech>> CreateCyberTech([FromBody] CyberTech cyberTech)
    {
        var newCyberTech = await _cyberTechRepository.CreateCyberTech(cyberTech);
        return CreatedAtAction(nameof(GetCyberTechById), new { id = newCyberTech.Id }, newCyberTech);
    }




}
