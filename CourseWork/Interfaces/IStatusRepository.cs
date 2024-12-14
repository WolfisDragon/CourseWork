using CourseWork.Models;

namespace CourseWork.Interfaces;

public interface IStatusRepository
{
    Task<List<Status>> GetAllAsync();
    Task<Status> GetByIdAsync(int id);
    Task<Status> CreateAsync(Status status);
}