using CourseWork.Dto;

namespace CourseWork.Interfaces;

public interface IItemService
{
    Task<List<ItemDto.ItemDtoRead>> GetAllAsync();
    Task<ItemDto.ItemDtoRead> GetByIdAsync(int id);
    Task<ItemDto.ItemDtoRead> CreateAsync(ItemDto.ItemDtoCreate createDto);
}