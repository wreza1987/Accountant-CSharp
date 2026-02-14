using Accountant.Domain.Enums;

namespace Accountant.Dtos;

public class ProfileDto
{
    public required ProfileType ProfileType { get; set; }
    public required string Name { get; set; }
    public int ProvinceId { get; set; }
}

public class ChangeProfileDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ProvinceId { get; set; }
}