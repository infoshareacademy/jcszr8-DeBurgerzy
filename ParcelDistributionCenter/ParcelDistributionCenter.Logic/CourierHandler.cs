using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Logic
{
    public static class CourierHandler
    {
        public static void Display(Courier courier)
        {
            Console.WriteLine();
            Console.Write
                (
                  $" Id: {courier.Id} || " +
                  $" Name: {courier.Name} || " +
                  $" Surname: {courier.Surname} || " +
                  $" Email: {courier.Email} || " +
                  $" Phone: {courier.Phone} || " +
                  $" Parcels: "
                );
            DisplayList(courier.Parcels_numbers_list);
            Console.Write("Rout: ");
            DisplayList(courier.Rout);
            
        }


        // HELPERS! <T>
        public static void DisplayList(List<string> elements)
        {
            if (elements != null)
            {
                foreach (string element in elements)
                {
                    Console.Write(element + ", ");
                }
                Console.Write("|| ");
            }
        }

        public static void Display(List<Courier> courier_list)
        {
            foreach (Courier courier in courier_list)
            {
                Display(courier);
            }
        }
    }
}
