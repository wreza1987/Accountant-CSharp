namespace Accountant.Domain.Entities;

public class Province
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Capital { get; set; } = null!;
    
    public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}