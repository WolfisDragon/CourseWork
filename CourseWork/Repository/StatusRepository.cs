using CourseWork.Data;
using CourseWork.Interfaces;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Repository;

public class StatusRepository : IStatusRepository
{
    private readonly CourseworkContext _context;

    public StatusRepository(CourseworkContext context)
    {
        _context = context;
    }

    public async Task<List<Status>> GetAllAsync()
    {
        return await _context.Statuses.ToListAsync();
    }

    public async Task<Status> GetByIdAsync(int id)
    {
        return await _context.Statuses.FindAsync(id);
    }

    public async Task<Status> CreateAsync(Status status)
    {
        _context.Statuses.Add(status);
        await _context.SaveChangesAsync();
        return status;
    }
}