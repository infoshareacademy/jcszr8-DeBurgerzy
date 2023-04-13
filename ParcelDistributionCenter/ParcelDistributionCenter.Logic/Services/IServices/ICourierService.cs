using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public interface ICourierService
    {
        IEnumerable<Courier> GetAll();
        Courier FindById(string id);
        public void Update(Courier model) { }
        public void Delete(Courier courier) { }
    }
}