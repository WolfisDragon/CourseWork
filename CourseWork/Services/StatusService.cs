using CourseWork.Dto;
using CourseWork.Interfaces;
using CourseWork.Models;

namespace CourseWork.Services;

public class StatusService : IStatusService
{
    private IStatusRepository _repository;

    public StatusService(IStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StatusDto.StatusDtoRead>> GetAllAsync()
    {
        var statuses = await _repository.GetAllAsync();
        
        return statuses.Select(s => new StatusDto.StatusDtoRead
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
    }

    public async Task<StatusDto.StatusDtoRead> GetByIdAsync(int id)
    {
        var status = await _repository.GetByIdAsync(id);
        if (status == null) return null;
        
        return new StatusDto.StatusDtoRead
        {
            Id = status.Id,
            Name = status.Name
        };
    }

    public async Task<StatusDto.StatusDtoRead> CreateAsync(StatusDto.StatusDtoCreate createDto)
    {
        var status = new Status
        {
            Name = createDto.Name
        };

        var createdStatus = await _repository.CreateAsync(status);

        return new StatusDto.StatusDtoRead
        {
            Id = createdStatus.Id,
            Name = createdStatus.Name
        };
    }
}