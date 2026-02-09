namespace Accountant.Domain.Enums;

public enum AccountType
{
    Current     = 1,   // جاری
    Savings     = 2,   // پس‌انداز
    TimeDeposit = 3, // سپرده مدت‌دار
    Credit      = 4    // اعتباری / قرض‌الحسنه
}

public enum ActiveMode
{
    Active   = 1,
    Inactive = 2
}