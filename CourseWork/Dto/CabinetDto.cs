namespace CourseWork.Dto;

public static class CabinetDto
{
    public class CabinetDtoRead
    {
        public int Id { get; set; }
        public string? Number { get; set; }
    }

    public class CabinetDtoCreate
    {
        public string? Number { get; set; }
    }
}