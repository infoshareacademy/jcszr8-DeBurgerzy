﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    public class Center : IParcelHandler, IParcelPlace
    {
        public string Id { get; init; }
        public string Address { get; init; }
        public bool Is_active { get; set; }
        public int Big_lockers_count { get; set; }
        public int Medium_lockers_count { get; set; }
        public int Small_lockers_count { get; set; }
        public List<uint> Parcels_numbers_list { get; set; }
        public List<int> Connected_lockers_ids { get; set; }


        public Center(string id,string address, int big_lockers_count, int medium_lockers_count, int small_lockers_count) // konstruktor przy starcie programu
        {
            Id = id;
            Address = address;
            Is_active = true;
            Big_lockers_count = big_lockers_count;
            Medium_lockers_count = medium_lockers_count;
            Small_lockers_count = small_lockers_count;
            Parcels_numbers_list = new List<uint>();
            Connected_lockers_ids = new List<int>();
        }

        public Center( string address, int big_lockers_count, int medium_lockers_count, int small_lockers_count) // konstruktor przy dodawaniu centrum
        {
            Id = "C1"; // do opracowania auto nadawanie GUID
            Address = address;
            Is_active = true;
            Big_lockers_count = big_lockers_count;
            Medium_lockers_count = medium_lockers_count;
            Small_lockers_count = small_lockers_count;
            Parcels_numbers_list= new List<uint>();
            Connected_lockers_ids = new List<int>();
        }

        public void AddConnectedLocker( int Locker_Id) 
        {
            if (!Connected_lockers_ids.Contains(Locker_Id))
            {
                Connected_lockers_ids.Add(Locker_Id);
            }
        }
        public void AddConnectedLocker(List<int> Locker_Id)
        {
            foreach (int Id in Locker_Id)
            {
                if (!Connected_lockers_ids.Contains(Id))
                {
                    Connected_lockers_ids.Add(Id);
                }
            }
        }

    }
}
