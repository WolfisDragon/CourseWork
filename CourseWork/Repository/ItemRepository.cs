using CourseWork.Data;
using CourseWork.Interfaces;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Repository;

public class ItemRepository : IItemRepository
{
    private readonly CourseworkContext _context;

    public ItemRepository(CourseworkContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetAllAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> GetByIdAsync(int id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task<Item> CreateAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
}