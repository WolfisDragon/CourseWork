using CourseWork.Dto;
using CourseWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/stuff/[controller]")]
public class StuffController : ControllerBase
{
    private readonly IStuffService _stuffService;

    public StuffController(IStuffService stuffService)
    {
        _stuffService = stuffService;
    }

    [HttpGet]
    public async Task<ActionResult<List<StuffDto.StuffDtoRead>>> GetAll()
    {
        var stuffs = await _stuffService.GetAllAsync();
        return Ok(stuffs);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StuffDto.StuffDtoRead>> GetById(int id)
    {
        var stuff = await _stuffService.GetByIdAsync(id);

        if (stuff == null)
        {
            return NotFound();
        }

        return Ok(stuff);
    }

    [HttpPost]
    public async Task<ActionResult<StuffDto.StuffDtoRead>> Create(StuffDto.StuffDtoCreate stuffDto)
    {
        if (stuffDto == null)
        {
            return BadRequest();
        }

        var createdStuff = await _stuffService.CreateAsync(stuffDto);

        return CreatedAtAction(nameof(GetById), new { id = createdStuff.Id }, createdStuff);
    }
}