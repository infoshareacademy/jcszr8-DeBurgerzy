using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public class AddPackage
    {
        //public static void AddNewPackage()
        //{
        //    Console.Clear();
        //    //Wprowadzanie numeru paczki
        //    int packageNumber2 = 0;
        //    bool ifDone1 = false;
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert package number");
        //        var packageNumber1 = Console.ReadLine();
        //        if (int.TryParse(packageNumber1, out packageNumber2))
        //        {
        //            ifDone1 = true;
        //        }
        //    } while (ifDone1 == false);

        //    // wprowadzanie statusu paczki //////////////////////////////////
        //    int IFoption2;
        //    bool ifDone2 = false;
        //    Status status = Status.in_preparation;
        //    Console.Clear();
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert status delivery:");
        //        Console.WriteLine("Insert '1' if status is 'In preparation");
        //        Console.WriteLine("Insert '2' if status is 'Stored by sender");
        //        Console.WriteLine("Insert '3' if status is 'Stored in machine");
        //        Console.WriteLine("Insert '4' if status is 'In delivery");
        //        Console.WriteLine("Insert '5' if status is 'Delivered");

        //        string IFoption = Console.ReadLine();

        //        if (int.TryParse(IFoption, out IFoption2))
        //        {
        //            if (IFoption2 == 1)
        //            {
        //                status = Status.in_preparation;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 2)
        //            {
        //                status = Status.stored_by_sender;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 3)
        //            {
        //                status = Status.stored_in_machine;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 4)
        //            {
        //                status = Status.in_delivery;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 5)
        //            {
        //                status = Status.delivered;
        //                ifDone2 = true;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Wprowadzono błędne dane. Wprowadź dane ponownie");
        //                Thread.Sleep(2000);
        //            }
        //        }
        //    } while (ifDone2 == false);
        //    ////////////////////////////////////////////////////////////////////////////
        //    //Wprowadzanie courier_id
        //    Console.WriteLine("Insert courier ID :");
        //    var courierID = Console.ReadLine();
        //    Console.Clear();

        //    //Wprowadzanie danych nadawcy
        //    Console.WriteLine("Insert name and surname sender :");
        //    var senderName = Console.ReadLine();
        //    while (senderName.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full name and surname sender:");
        //        senderName = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie danych odbiorcy
        //    Console.WriteLine("Insert name and surname sender :");
        //    var recipientName = Console.ReadLine();
        //    while (recipientName.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full name and surname sender:");
        //        recipientName = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    // wprowadzanie rozmiaru paczki
        //    PackageSize packageSize2;

        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert size delivery(small, medium, big");
        //        var packageSize = Console.ReadLine();
        //        bool x = PackageSize.TryParse(packageSize, out packageSize2);
        //        if (x == true)
        //        {
        //            ifDone3 = true;
        //        }
        //    } while (ifDone3 == false);

        //    // wprowadzanie rozmiaru paczki //////////////////////////////////
        //    int IfSize2;
        //    bool ifDone3 = false;
        //    Status status = Status.in_preparation;
        //    Console.Clear();
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert status delivery:");
        //        Console.WriteLine("Insert '1' if status is 'In preparation");
        //        Console.WriteLine("Insert '2' if status is 'Stored by sender");
        //        Console.WriteLine("Insert '3' if status is 'Stored in machine");
        //        Console.WriteLine("Insert '4' if status is 'In delivery");
        //        Console.WriteLine("Insert '5' if status is 'Delivered");

        //        string IfSize = Console.ReadLine();

        //        if (int.TryParse(IfSize, out IfSize2))
        //        {
        //            if (IFoption2 == 1)
        //            {
        //                status = Status.in_preparation;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 2)
        //            {
        //                status = Status.stored_by_sender;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 3)
        //            {
        //                status = Status.stored_in_machine;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 4)
        //            {
        //                status = Status.in_delivery;
        //                ifDone2 = true;
        //            }
        //            else if (IFoption2 == 5)
        //            {
        //                status = Status.delivered;
        //                ifDone2 = true;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Wprowadzono błędne dane. Wprowadź dane ponownie");
        //                Thread.Sleep(2000);
        //            }
        //        }
        //    } while (ifDone2 == false);
        //    ////////////////////////////////////////////////////////////////////////////

        //    //Wprowadzanie emaila nadawcy
        //    Console.WriteLine("Insert email sender :");
        //    var senderEmail = Console.ReadLine();
        //    while (senderEmail.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full email:");
        //        senderEmail = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie numeru telefonu nadawcy
        //    Console.WriteLine("Insert phone number sender :");
        //    var senderPhone = Console.ReadLine();
        //    while (senderPhone.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full phone number sender:");
        //        senderPhone = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie emaila odbiorcy
        //    Console.WriteLine("Insert email recipient :");
        //    var recipientEmail = Console.ReadLine();
        //    while (recipientEmail.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full email:");
        //        recipientEmail = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie numeru telefonu odbiorcy
        //    Console.WriteLine("Insert phone number recipient :");
        //    var recipientPhone = Console.ReadLine();
        //    while (recipientPhone.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full phone number recipient:");
        //        recipientPhone = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie adresu nadawcy
        //    Console.WriteLine("Insert adres sender :");
        //    var senderAddres = Console.ReadLine();
        //    while (senderAddres.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full adres sender:");
        //        senderAddres = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie adresu odbiorcy
        //    Console.WriteLine("Insert adres delivery :");
        //    var deliveryAddres = Console.ReadLine();
        //    while (deliveryAddres.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full adres delivery:");
        //        deliveryAddres = Console.ReadLine();
        //    }
        //    Console.Clear();

        //    //Wprowadzanie Id paczkomatu
        //    Console.WriteLine("Insert delivery machine ID :");
        //    var deliveryMachineID = Console.ReadLine();
        //    while (deliveryMachineID.Length < 2)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Insert full  delivery machine ID:");
        //        deliveryMachineID = Console.ReadLine();
        //    }
        //    Console.Clear();
        //    //data rejestracji
        //    DateTime registered = DateTime.Now;

        //    //Generowanie nowego użytkownika
        //    MemoryRepository.PackagesList.Add(new Package(packageNumber2, status, courierID, senderName, recipientName, packageSize2, senderEmail, senderPhone, recipientEmail, recipientPhone, senderAddres, deliveryAddres, deliveryMachineID, registered));
        //}
    }
}