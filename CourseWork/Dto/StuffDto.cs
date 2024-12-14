namespace CourseWork.Dto;

public class StuffDto
{
    public class StuffDtoRead
    {
        public int Id { get; set; }
        public string? CabinetNumber { get; set; }
        public string? ItemName { get; set; }
        public string? StatusName { get; set; }
    }

    public class StuffDtoCreate
    {
        public int CabinetId { get; set; }
        public int ItemId { get; set; }
        public int StatusId { get; set; }
    }
}