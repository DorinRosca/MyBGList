namespace MyBGList.DTO;

public class RestDto<T>
{
    public List<LinkDto> Links { get; set; } = [];
    public T Data { get; set; } = default!;
}