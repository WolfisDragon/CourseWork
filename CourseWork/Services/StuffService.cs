using CourseWork.Dto;
using CourseWork.Interfaces;
using CourseWork.Models;

namespace CourseWork.Services;

public class StuffService : IStuffService
{
    private IStuffRepository _repository;

    public StuffService(IStuffRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StuffDto.StuffDtoRead>> GetAllAsync()
    {
        var stuffs = await _repository.GetAllAsync();

        return stuffs.Select(s => new StuffDto.StuffDtoRead
        {
            Id = s.Id,
            CabinetNumber = s.Cabinet.Number,
            ItemName = s.Item.Name,
            StatusName = s.Status.Name
        }).ToList();

    }

    public async Task<StuffDto.StuffDtoRead> GetByIdAsync(int id)
    {
        var stuff = await _repository.GetByIdAsync(id);

        return new StuffDto.StuffDtoRead
        {
            Id = stuff.Id,
            CabinetNumber = stuff.Cabinet.Number,
            ItemName = stuff.Item.Name,
            StatusName = stuff.Status.Name
        };
    }

    public async Task<StuffDto.StuffDtoRead> CreateAsync(StuffDto.StuffDtoCreate createDto)
    {
        var stuff = new Stuff
        {
            Cabinetid = createDto.CabinetId,
            Itemid = createDto.ItemId,
            Statusid = createDto.StatusId
        };

        var createdStuff = await _repository.CreateAsync(stuff);

        return new StuffDto.StuffDtoRead
        {
            Id = createdStuff.Id,
            CabinetNumber = createdStuff.Cabinet.Number,
            ItemName = createdStuff.Item.Name,
            StatusName = createdStuff.Status.Name
        };

    }
}