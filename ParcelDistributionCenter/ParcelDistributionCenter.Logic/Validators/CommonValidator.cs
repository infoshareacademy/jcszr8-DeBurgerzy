using System.Text.RegularExpressions;

namespace ParcelDistributionCenter.Logic.Validators
{
    [Obsolete("ZOBACZYĆ, CZY TO W OGÓLE JEST POTRZEBNE")]
    public class CommonValidator
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
            var regex = @"/ ^[a - zA - Z0 - 9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/";

            Match match = Regex.Match(email, regex, RegexOptions.IgnoreCase);

            if (email != string.Empty && match.Success)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateName(string name)
        {
            if (name.Length >= 3 & name.Length <= 12)
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