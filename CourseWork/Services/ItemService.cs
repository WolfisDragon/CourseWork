using CourseWork.Dto;
using CourseWork.Interfaces;
using CourseWork.Models;

namespace CourseWork.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ItemDto.ItemDtoRead>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items.Select(i => new ItemDto.ItemDtoRead
        {
            Id = i.Id,
            Name = i.Name
        }).ToList();
    }

    public async Task<ItemDto.ItemDtoRead> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return null;

        return new ItemDto.ItemDtoRead
        {
            Id = item.Id,
            Name = item.Name
        };
    }

    public async Task<ItemDto.ItemDtoRead> CreateAsync(ItemDto.ItemDtoCreate createDto)
    {
        var item = new Item
        {
            Name = createDto.Name
        };
        var createdItem = await _repository.CreateAsync(item);

        return new ItemDto.ItemDtoRead
        {
            Id = createdItem.Id,
            Name = createdItem.Name
        };
    }
}