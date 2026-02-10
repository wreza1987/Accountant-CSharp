using Accountant.Domain.Enums;

namespace Accountant.Dtos;


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
