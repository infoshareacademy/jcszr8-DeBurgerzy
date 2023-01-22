namespace ParcelDistributionCenter.Logic.Validators
{
    public class AddPackageValidator
    {
        public static bool CheckAddressValidation(string address)
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

        public static bool CheckEmailValidation(string email)
        {
            bool status1 = email.Contains("@");
            bool status2 = email.Contains(".");
            bool status3 = email.Contains(" ");

            if (status1 & status2 & !status3 & email.Length > 6)
            {
                return true;
            }
            return false;
        }

        public static bool CheckNameValidation(string name)
        {
            bool status = name.Contains(" ");
            if (status & name.Length > 5)
            {
                return true;
            }
            return false;
        }

        public static bool CheckPackageNumberValidation(int packageNumber)
        {
            return true;
        }

        public static bool CheckPhoneNumberValidation(string phoneNumber)
        {
            int numberCount = 0;
            int letterCount = 0;
            int whiteSpaceCount = 0;
            int separatorCount = 0;
            foreach (var ch in phoneNumber)
            {
                if (char.IsNumber(ch))
                {
                    numberCount++;
                }
                else if (char.IsLetter(ch))
                {
                    letterCount++;
                }
                else if (char.IsWhiteSpace(ch))
                {
                    whiteSpaceCount++;
                }
                else if (char.IsSeparator(ch))
                {
                    separatorCount++;
                }
            }
            if (numberCount >= 9 & letterCount == 0 & whiteSpaceCount == 0 & separatorCount == 0)
            {
                return true;
            }
            return false;
        }
    }
}