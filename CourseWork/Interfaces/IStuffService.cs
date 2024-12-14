using CourseWork.Dto;
using CourseWork.Models;

namespace CourseWork.Interfaces;

public interface IStuffService
{
    Task<List<StuffDto.StuffDtoRead>> GetAllAsync();
    Task<StuffDto.StuffDtoRead> GetByIdAsync(int id);
    Task<StuffDto.StuffDtoRead> CreateAsync(StuffDto.StuffDtoCreate createDto);
}