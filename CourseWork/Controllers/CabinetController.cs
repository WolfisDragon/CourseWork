using CourseWork.Dto;
using CourseWork.Interfaces.Cabinets;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/cabinet/[controller]")]
public class CabinetController : ControllerBase
{
    private readonly ICabinetService _cardService;

    public CabinetController(ICabinetService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CabinetDto.CabinetDtoRead>>> GetAll()
    {
        var cabinets = await _cardService.GetAllAsync();
        return Ok(cabinets);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CabinetDto.CabinetDtoRead>> GetById(int id)
    {
        var cabinet = await _cardService.GetByIdAsync(id);

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

        var createdCabinet = await _cardService.CreateAsync(cabinetDto);

        return CreatedAtAction(nameof(GetById), new { id = createdCabinet.Id }, createdCabinet);
    }
}