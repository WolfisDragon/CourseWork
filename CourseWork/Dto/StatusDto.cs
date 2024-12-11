namespace CourseWork.Dto;

public class StatusDto
{
    public class StatusDtoRead
    {
        public int Id { get; set; }
        public string? Number { get; set; }
    }

    public class StatusDtoCreate
    {
        public string? Number { get; set; }
    }
}