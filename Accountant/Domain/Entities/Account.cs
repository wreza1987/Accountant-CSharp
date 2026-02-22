using Accountant.Domain.Enums;

namespace Accountant.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public AccountType AccountType { get; set; } // Current,Savings,TimeDeposit,Credit
    public DateOnly OpenedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public ActiveMode ActiveMode { get; set; } // Active,Inactive
    //public DateOnly ClosedAt { get; set; } = DateOnly.FromDateTime(DateTime.MaxValue);
    public DateOnly? ClosedAt { get; set; } = null;

    public ICollection<ProfileAccount> ProfileAccounts { get; set; }
        = new List<ProfileAccount>();

    public ICollection<Transaction> Transactions { get; set; }
        = new List<Transaction>();
    
    
    public void SetAccountOpenedAt(DateOnly time)
    {
        this.OpenedAt = time != default
            ? time : DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public void SetAccountType(AccountType accountType)
    {
        if (!Enum.IsDefined(typeof(AccountType), accountType))
        {
            throw new Exception("نوع اکانت نامعتبر است.");
        }
        this.AccountType = accountType;
    }
}