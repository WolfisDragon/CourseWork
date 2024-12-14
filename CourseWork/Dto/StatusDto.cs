namespace CourseWork.Dto;

public class StatusDto
{
    public class StatusDtoRead
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class StatusDtoCreate
    {
        public string? Name { get; set; }
    }
}