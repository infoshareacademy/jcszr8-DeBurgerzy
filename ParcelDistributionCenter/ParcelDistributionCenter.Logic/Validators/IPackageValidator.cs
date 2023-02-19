namespace ParcelDistributionCenter.Logic.Validators
{
    public interface IPackageValidator
    {
        bool ValidateAddress(string address);

        bool ValidateEmail(string email);

        bool ValidateName(string name);

        bool ValidatePackageNumber(int packageNumber);

        bool ValidatePhoneNumber(string phoneNumber);
    }
}