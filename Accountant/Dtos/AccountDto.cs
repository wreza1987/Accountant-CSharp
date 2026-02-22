using Accountant.Domain.Entities;
using Accountant.Domain.Enums;

namespace Accountant.Dtos;


public class AccountDto
{
    public int Id { get; set; }
    public AccountType AccountType { get; set; }
    public DateOnly OpenedAt { get; set; }
    public ActiveMode ActiveMode { get; set; }
    public DateOnly ClosedAt { get; set; }
    public List<int> ProfileIds { get; set; } = new List<int>();

    public AccountDto(Account account)
    {
        Id          = account.Id;
        AccountType = account.AccountType;
        OpenedAt    = account.OpenedAt;
        ActiveMode  = account.ActiveMode;
        ClosedAt    = (DateOnly)account.ClosedAt!;

        ProfileIds  = account.ProfileAccounts
                          ?.Select(pa => pa.ProfileId)
                          ?.ToList() 
                      ?? new List<int>();
    }
}

public class AccountOpeningDto
{
    public AccountType AccountType { get; set; }
    public DateOnly OpenedAt { get; set; }
}

public class AccountClosingDto
{
    public int Id { get; set; }
    public DateOnly ClosedAt { get; set; }
}
