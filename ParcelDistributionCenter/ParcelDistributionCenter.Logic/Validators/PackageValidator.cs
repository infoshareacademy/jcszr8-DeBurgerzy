using System.Text.RegularExpressions;

namespace ParcelDistributionCenter.Logic.Validators
{
    [Obsolete("MOŻLIWE, ŻE PRZEROBIĆ NA STATIC I WYWALIĆ Z KONTENERA I CZY W OGÓLE POTRZEBNE")]
    public class PackageValidator : IPackageValidator
    {
        public bool ValidateAddress(string address)
        {
            if (address != null)
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
            }
            return false;
        }

        public bool ValidateName(string name)
        {
            if (name != null)
            {
                bool isAnyCharUpper = name.Any(c => char.IsUpper(c));
                if (isAnyCharUpper & name.Length >= 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidatePackageNumber(int packageNumber) => packageNumber >= 1_000_000 && packageNumber <= 9_999_999;

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var cleaned = RemoveNonNumeric(phoneNumber);
                return cleaned.Length > 7 && cleaned.Length < 14;
            }
            return false;
        }

        private static string RemoveNonNumeric(string phone) => Regex.Replace(phone, @"[^0-9]+", "");
    }
}