namespace Accountant.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public int ProfileAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    
    public ProfileAccount ProfileAccount { get; set; } = null!;
}
