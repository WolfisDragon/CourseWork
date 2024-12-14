using CourseWork.Data;
using CourseWork.Interfaces;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Repository;

public class StuffRepository : IStuffRepository
{
    private readonly CourseworkContext _context;

    public StuffRepository(CourseworkContext context)
    {
        _context = context;
    }

    public async Task<List<Stuff>> GetAllAsync()
    {
        return await _context.Stuffs
            .Include(c => c.Cabinet)
            .Include(c => c.Item)
            .Include(c => c.Status)
            .ToListAsync();
    }

    public async Task<Stuff> GetByIdAsync(int id)
    {
        return await _context.Stuffs
            .Include(c => c.Cabinet)
            .Include(c => c.Item)
            .Include(c => c.Status)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Stuff> CreateAsync(Stuff stuff)
    {
        _context.Add(stuff);
        await _context.SaveChangesAsync();
        return stuff;
    }
}