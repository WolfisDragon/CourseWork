using CourseWork.Models;

namespace CourseWork.Interfaces;

public interface IStuffRepository
{
    Task<List<Stuff>> GetAllAsync();
    Task<Stuff> GetByIdAsync(int id);
    Task<Stuff> CreateAsync(Stuff stuff);
}