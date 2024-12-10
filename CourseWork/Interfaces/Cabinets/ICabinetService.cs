using CourseWork.Dto;

namespace CourseWork.Interfaces.Cabinets;

public interface ICabinetService
{
    Task<List<CabinetDto.CabinetDtoRead>> GetAllAsync();
    Task<CabinetDto.CabinetDtoRead> GetByIdAsync(int id);
    Task<CabinetDto.CabinetDtoRead> CreateAsync(CabinetDto.CabinetDtoCreate cabinetDto);
}
    