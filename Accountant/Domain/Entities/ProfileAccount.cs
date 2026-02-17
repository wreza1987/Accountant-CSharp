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

    public void ValidateSharePercentage(decimal proposedShare)
    {
        if (proposedShare <= 0 || proposedShare > 1)
            throw new ArgumentOutOfRangeException(nameof(proposedShare));
    }
}
