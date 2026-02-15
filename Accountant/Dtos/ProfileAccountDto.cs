namespace Accountant.Dtos;

public class ProfileAccountDto
{
    public int ProfileId { get; set; }
    public int AccountId { get; set; }
    public double ShareOwned { get; set; }
}

public class ChangeProfileAccountDto
 {
     public int Id { get; set; }
     public double ShareOwned { get; set; }
 }