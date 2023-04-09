using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic
{
    public class CourierHandler : ICourierHandler
    {
        private readonly IPackageServices _packageServices;
        private readonly IRepository<Courier> _repository;

        public CourierHandler(IRepository<Courier> repository, IPackageServices packageServices)
        {
            _repository = repository;
            _packageServices = packageServices;
        }

        public void Delete(Courier model)
        {
            var courier = FindById(model.CourierId);
            _packageServices.UnassignCouriersPackages(courier.CourierId);
            _repository.Delete(courier);
        }

        public IEnumerable<Courier> FindAll() => _repository.GetAll();

        public Courier FindById(string id) => _repository.Get(id);

        public void Update(Courier model)
        {
            var courier = FindById(model.CourierId);
            courier.Name = model.Name;
            courier.Surname = model.Surname;
            courier.Email = model.Email;
            courier.Phone = model.Phone;
        }
    }
}