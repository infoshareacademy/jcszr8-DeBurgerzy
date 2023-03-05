using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface ICourierHandler
    {
        IEnumerable<Courier> FindAll();
        Courier FindById(string id);
        public void Update(Courier model) { }
        public void Delete(Courier courier) { }
    }
}