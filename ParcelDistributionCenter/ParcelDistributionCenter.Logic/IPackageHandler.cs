﻿using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IPackageHandler
    {
        IEnumerable<Package> FindAll();
        Package FindPackageByNumber(int packageNumber);
        IEnumerable<Package> FindPackagesByCourierID(string courierId);
        IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID);
        IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail);
        void Update(Package model);
    }
}