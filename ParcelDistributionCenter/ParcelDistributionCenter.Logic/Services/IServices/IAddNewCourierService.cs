using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IAddNewCourierService
    {
        bool AddNewCourier(Courier courier);
    }
}