using Accountant.Domain.Enums;

namespace Accountant.Domain.Entities;

public class Profile
{
    public int Id { get; set; }
    public ProfileType ProfileType {get; set;} // Real, Legal
    public string Name { get; set; } = null!;
    public int ProvinceId { get; set; }
    
    // public virtual required Province Province { get; set; } = null!;
    public ICollection<ProfileAccount> ProfileAccounts { get; set; }
        = new List<ProfileAccount>();
}