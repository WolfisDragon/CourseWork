using CourseWork.Dto;
using CourseWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/item/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ItemDto.ItemDtoRead>>> GetAll()
    {
        var items = await _itemService.GetAllAsync();
        return Ok(items);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto.ItemDtoRead>> GetById(int id)
    {
        var item = await _itemService.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }
    
    [HttpPost]
    public async Task<ActionResult<ItemDto.ItemDtoRead>> Create(ItemDto.ItemDtoCreate itemDto)
    {
        if (itemDto == null)
        {
            return BadRequest();
        }

        var createdItem = await _itemService.CreateAsync(itemDto);

        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }
}