using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParcelDistributionCenter.Logic
{
    public class AddNewCourierHandler : IAddNewCourierHandler
    {
        private readonly IMemoryRepository _memoryRepository;

        public AddNewCourierHandler(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        public bool AddNewCourier(Courier courier)
        {
            Dictionary<string,bool> validator= new Dictionary<string,bool>();
            validator["Name"] = Validators.CommonValidator.ValidateName(courier.Name);
            validator["Surname"] = Validators.CommonValidator.ValidateName(courier.Surname);
            validator["Email"] = Validators.CommonValidator.ValidateEmail(courier.Email);
            validator["Phone"] = Validators.CommonValidator.ValidatePhoneNumber(courier.Phone);

            if (validator.Any(v => v.Value == false))
            {
                // INFORMACJA O BŁĘDZIE DO DODANIA
                return false;
            }
            else
            {
                _memoryRepository.CouriersList.Add(new Courier(courier.Name, courier.Surname, courier.Email, courier.Phone));
                return true;
            }
        }
    }
}
