using CourseWork.Dto;
using CourseWork.Interfaces.Cabinets;
using CourseWork.Models;
using CourseWork.Repository;

namespace CourseWork.Services;

public class CabinetService : ICabinetService
{
    private readonly CabinetRepository _repository;

    public CabinetService(CabinetRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CabinetDto.CabinetDtoRead>> GetAllAsync()
    {
        var cabinets = await _repository.GetAllAsync();

        return cabinets.Select(c => new CabinetDto.CabinetDtoRead
        {
            Id = c.Id,
            Number = c.Number
        }).ToList();
    }

    public async Task<CabinetDto.CabinetDtoRead> GetByIdAsync(int id)
    {
        var cabinet = await _repository.GetByIdAsync(id);
        if (cabinet == null) return null;

        return new CabinetDto.CabinetDtoRead
        {
            Id = cabinet.Id,
            Number = cabinet.Number
        };
    }

    public async Task<CabinetDto.CabinetDtoRead> CreateAsync(CabinetDto.CabinetDtoCreate cabinetDto)
    {
        var cabinet = new Cabinet
        {
            Number = cabinetDto.Number
        };
        var createdCabinet = await _repository.CreateCabinetAsync(cabinet);

        return new CabinetDto.CabinetDtoRead
        {
            Id = createdCabinet.Id,
            Number = createdCabinet.Number
        };
    }
}