using Accountant.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Domain.Entities;

public class ProfileAccount
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int AccountId { get; set; }
    public double ShareOwned { get; set; }
    
    public Profile Profile { get; set; } = null!;
    public Account Account { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    internal static void ValidateShare(double shareOwned, double currentSum)
    {
        throw new NotImplementedException();
    }

    //public void ValidateSharePercentage(decimal proposedShare)
    //{
    //    if (proposedShare <= 0 || proposedShare > 1)
    //        throw new ArgumentOutOfRangeException(nameof(proposedShare));
    //    return;
    //}

    //public void CheckShareSum(MyDbContext _db, ProfileAccount profileAccount)
    //{
    //    var currentSum = _db.ProfileAccounts
    //            .Where(pa => pa.AccountId == profileAccount.AccountId)
    //            .SumAsync(pa => pa.ShareOwned);

    //    if (currentSum + profileAccount.ShareOwned > 1)
    //        throw new InvalidOperationException("مجموع سهم‌ها بیش از ۱ می‌شود");
    //}
}
