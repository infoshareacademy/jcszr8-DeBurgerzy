using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IAddNewCourierService
    {
        bool AddNewCourier(Courier courier);
    }
}