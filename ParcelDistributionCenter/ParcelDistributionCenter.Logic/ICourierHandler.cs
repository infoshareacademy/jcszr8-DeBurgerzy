using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface ICourierHandler
    {
        IEnumerable<Courier> FindAll();
    }
}