using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class AddNewCourierService : IAddNewCourierService
    {
        private readonly IRepository<Courier> _repository;

        public AddNewCourierService(IRepository<Courier> repository)
        {
            _repository = repository;
        }

        public bool AddNewCourier(Courier courier)
        {
            Dictionary<string, bool> validator = new()
            {
                ["Name"] = Validators.CommonValidator.ValidateName(courier.Name),
                ["Surname"] = Validators.CommonValidator.ValidateName(courier.Surname),
                ["Email"] = Validators.CommonValidator.ValidateEmail(courier.Email),
                ["Phone"] = Validators.CommonValidator.ValidatePhoneNumber(courier.Phone)
            };

            if (validator.Any(v => v.Value == false))
            {
                // INFORMACJA O BŁĘDZIE DO DODANIA
                return false;
            }
            else
            {
                _repository.Insert(courier);
                return true;
            }
        }
    }
}