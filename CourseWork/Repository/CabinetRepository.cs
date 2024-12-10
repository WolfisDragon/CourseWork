using CourseWork.Data;
using CourseWork.Interfaces.Cabinets;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Repository;

public class CabinetRepository : ICabinetRepository
{
    private readonly CourseworkContext _context;

    public CabinetRepository(CourseworkContext context)
    {
        _context = context;
    }
    
    public async Task<List<Cabinet>> GetAllAsync()
    {
        return await _context.Cabinets.ToListAsync();
    }

    public async Task<Cabinet> GetByIdAsync(int id)
    {
        return await _context.Cabinets.FindAsync(id);
    }

    public async Task<Cabinet> CreateCabinetAsync(Cabinet cabinet)
    {
        _context.Cabinets.Add(cabinet);
        await _context.SaveChangesAsync();
        return cabinet;
    }
}