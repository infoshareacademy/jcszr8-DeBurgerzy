﻿using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IAddNewPackageHandler
    {
        bool AddNewPackage(ref Package package);
    }
}