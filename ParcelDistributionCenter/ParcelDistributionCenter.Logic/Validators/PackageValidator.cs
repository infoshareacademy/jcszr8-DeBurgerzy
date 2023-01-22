using System.Text.RegularExpressions;

namespace ParcelDistributionCenter.Logic.Validators
{
    public class PackageValidator
    {
        public static bool ValidateAddress(string address)
        {
            int numberCount = 0;
            int letterCount = 0;
            int separatorCount = 0;
            foreach (var ch in address)
            {
                if (char.IsNumber(ch))
                {
                    numberCount++;
                }
                else if (char.IsLetter(ch))
                {
                    letterCount++;
                }
                else if (char.IsSeparator(ch))
                {
                    separatorCount++;
                }
            }
            if (numberCount >= 1 & letterCount >= 2 & separatorCount >= 1)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateEmail(string email)
        {
            bool monkeyChar = email.Contains('@');
            bool dotchar = email.Contains('.');
            bool whiteSpaceChar = email.Contains(' ');

            if (monkeyChar & dotchar & !whiteSpaceChar & email.Length > 6)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateName(string name)
        {
            bool isAnyCharUpper = name.Any(c => char.IsUpper(c));
            if (isAnyCharUpper & name.Length >= 3)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePackageNumber(int packageNumber) => packageNumber >= 1_000_000 && packageNumber <= 9_999_999;

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            var cleaned = RemoveNonNumeric(phoneNumber);
            return cleaned.Length > 7 && cleaned.Length < 14;
        }

        private static string RemoveNonNumeric(string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }
    }
}