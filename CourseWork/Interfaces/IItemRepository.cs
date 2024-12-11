using CourseWork.Models;

namespace CourseWork.Interfaces;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(int id);
    Task<Item> CreateAsync(Item item);
}