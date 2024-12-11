namespace CourseWork.Dto;

public class ItemDto
{
    public class ItemDtoRead
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ItemDtoCreate
    {
        public string? Name { get; set; }
    }
}