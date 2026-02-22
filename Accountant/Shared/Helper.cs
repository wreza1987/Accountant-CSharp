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

        
        public static double ValidateShare(double shareOwned, double currentSumShare)
        {
            if (shareOwned < 0 || shareOwned > 1)
                throw new ArgumentOutOfRangeException(nameof(shareOwned));
            if (currentSumShare + shareOwned > 1)
                throw new InvalidOperationException("مجموع سهم‌ها بیش از ۱ می‌شود");

            return shareOwned;
        }
    }
}
