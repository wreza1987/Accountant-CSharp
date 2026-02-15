namespace Accountant.Dtos;

public class ProvinceDto
{
    public string Name { get; set; }
    public string Capital { get; set; }
}

public class ProvinceUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
}