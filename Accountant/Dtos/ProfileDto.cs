namespace Accountant.Dtos;

public class ProfileDto
{
    public required string ProfileType { get; set; }
    public required string Name { get; set; }
    public int ProvinceId { get; set; }
}

public class ChangeProfileDto
{
    public required string Name { get; set; }
    public int ProvinceId { get; set; }
}