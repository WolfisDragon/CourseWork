using CourseWork.Dto;
using CourseWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/cabinet/[controller]")]
public class CabinetController : ControllerBase
{
    private readonly ICabinetService _cabinetService;

    public CabinetController(ICabinetService cardService)
    {
        _cabinetService = cardService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CabinetDto.CabinetDtoRead>>> GetAll()
    {
        var cabinets = await _cabinetService.GetAllAsync();
        return Ok(cabinets);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CabinetDto.CabinetDtoRead>> GetById(int id)
    {
        var cabinet = await _cabinetService.GetByIdAsync(id);

        if (cabinet == null)
        {
            return NotFound();
        }

        return Ok(cabinet);
    }

    [HttpPost]
    public async Task<ActionResult<CabinetDto.CabinetDtoRead>> Create(CabinetDto.CabinetDtoCreate cabinetDto)
    {
        if (cabinetDto == null)
        {
            return BadRequest();
        }

        var createdCabinet = await _cabinetService.CreateAsync(cabinetDto);

        return CreatedAtAction(nameof(GetById), new { id = createdCabinet.Id }, createdCabinet);
    }
}