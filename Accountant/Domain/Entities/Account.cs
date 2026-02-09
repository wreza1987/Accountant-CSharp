using Accountant.Domain.Enums;

namespace Accountant.Domain.Entities;

public class Account
{
    public int Id { get; private set; }
    public AccountType AccountType { get; set; } // Current,Savings,TimeDeposit,Credit
    public DateOnly OpenedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public ActiveMode ActiveMode { get; set; } // Active,Inactive
    public DateOnly ClosedAt { get; set; } = DateOnly.FromDateTime(DateTime.MaxValue);

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


    /*
    public void AddOwner(Profile profile, double sharePercentage)
    {
        if (sharePercentage <= 0 || sharePercentage > 1)
            throw new ArgumentOutOfRangeException(nameof(sharePercentage));
        
        var currentTotalShare = AccountOwners.Sum(x => x.Share) + (double)sharePercentage;

        if (currentTotalShare > 1)
            throw new Exception("مجموع سهم‌ها نمی تواند بیشتر از 1 باشد");

        AccountOwners.Add(new ProfileAccount
        {
            Profile = profile,
            Share = sharePercentage
        });
    }
    
    public void ValidateShares()
    {
        var totalShare = AccountOwners.Sum(x => x.Share);

        if (Math.Abs(totalShare - 1) > 0.001)
            throw new Exception("مجموع سهم‌ها باید دقیقاً برابر 1 باشد");
    }
*/

}