using CourseWork.Dto;
using CourseWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/status/[controller]")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
    {
        _statusService = statusService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<StatusDto.StatusDtoRead>>> GetAll()
    {
        var statuses = await _statusService.GetAllAsync();
        return Ok(statuses);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<StatusDto.StatusDtoRead>> GetById(int id)
    {
        var status = await _statusService.GetByIdAsync(id);

        if (status == null)
        {
            return NotFound();
        }

        return Ok(status);
    }

    [HttpPost]
    public async Task<ActionResult<StatusDto.StatusDtoRead>> Create(StatusDto.StatusDtoCreate statusDto)
    {
        if (statusDto == null)
        {
            return BadRequest();
        }

        var createdStatus = await _statusService.CreateAsync(statusDto);

        return CreatedAtAction(nameof(GetById), new { id = createdStatus.Id }, createdStatus);
    }
    
}