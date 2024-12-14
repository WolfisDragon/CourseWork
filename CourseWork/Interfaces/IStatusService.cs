using CourseWork.Dto;

namespace CourseWork.Interfaces;

public interface IStatusService
{
    Task<List<StatusDto.StatusDtoRead>> GetAllAsync();
    Task<StatusDto.StatusDtoRead> GetByIdAsync(int id);
    Task<StatusDto.StatusDtoRead> CreateAsync(StatusDto.StatusDtoCreate createDto);
}