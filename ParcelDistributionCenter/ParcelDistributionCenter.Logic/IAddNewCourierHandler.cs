using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IAddNewCourierHandler
    {
        bool AddNewCourier(Courier courier);
    }
}