using Accountant.Domain.Enums;

namespace Accountant.Shared
{
    public static class Helper
    {

        public static string NormalizeText(this string text)
        {
            text = text.Trim();
            text = text.Trim().ToLower();
            text = char.ToUpper(text[0]) + text.Substring(1);
            text = text.Replace("ي", "ی");

            return text;
        }


        public static string ValidateNotEmpty(this string text, string message)
        {
            if (string.IsNullOrEmpty(text)) throw new Exception(message);
            return text;
        }

        //public static AccountType CheckAccountType(this AccountType accountType)
        //{
        //    if (!Enum.IsDefined(typeof(AccountType), accountType))
        //    {
        //        throw new Exception("نوع اکانت نامعتبر است.");
        //    }
        //    return accountType;
        //}
    }
}
