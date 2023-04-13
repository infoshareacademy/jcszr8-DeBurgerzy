using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class CourierService : ICourierService
    {
        private readonly IPackageServices _packageServices;
        private readonly IRepository<Courier> _repository;

        public CourierService(IRepository<Courier> repository, IPackageServices packageServices)
        {
            _repository = repository;
            _packageServices = packageServices;
        }

        public void Delete(Courier model)
        {
            var courier = FindById(model.CourierJsonId);
            _packageServices.UnassignCouriersPackages(courier.CourierJsonId);
            _repository.Delete(courier);
        }

        public IEnumerable<Courier> GetAll() => _repository.GetAll();

        public Courier FindById(string id) => _repository.Get(id);

        public void Update(Courier model)
        {
            var courier = FindById(model.CourierJsonId);
            courier.Name = model.Name;
            courier.Surname = model.Surname;
            courier.Email = model.Email;
            courier.Phone = model.Phone;
        }
    }
}