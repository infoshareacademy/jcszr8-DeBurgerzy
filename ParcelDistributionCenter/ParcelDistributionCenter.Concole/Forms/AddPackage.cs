using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public class AddPackage
    {
        // sprawdzanie długości i spacji w imieniu i nazwisku
       
        private static bool CheckNameValidation(string name)
        {
            bool status = name.Contains(" ");
            if ( status & name.Length > 5)
            {
                return true;
            }
            else
                return false;

        }
        private static bool CheckEmailValidation(string email)
        {
            bool status1 = email.Contains("@");
            bool status2 = email.Contains(".");
            bool status3 = email.Contains(" ");
           
            if (status1 & status2 & !status3 & email.Length > 6)
            {
                return true;
            }
            else
                return false;
        }
        private static bool CheckPhoneNumberValidation(string phoneNumber)
        {
            int numberCount=0;
            int letterCount = 0;
            int whiteSpaceCount=0;
            int separatorCount = 0;
            foreach (var ch in phoneNumber)
            {
                if (Char.IsNumber(ch))
                {
                    numberCount++;
                }
                else if(Char.IsLetter(ch))
                {
                    letterCount++;
                }
                else if (Char.IsWhiteSpace(ch))
                {
                    whiteSpaceCount++;
                }
                else if (Char.IsSeparator(ch))
                {
                    separatorCount++;
                }
            }
            if (numberCount>=9 & letterCount==0 & whiteSpaceCount==0 & separatorCount==0)
            {
                return true;
            }
            else
                return false;
        }
        public static void AddNewPackage()
        {
            //Wprowadzanie numeru paczki
            int packageNumber2 = 0;
            bool ifDone1 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Insert package number");
                var packageNumber1 = Console.ReadLine();
                if (int.TryParse(packageNumber1, out packageNumber2))
                {
                    ifDone1 = true;
                }
            } while (ifDone1 == false);

            // wprowadzanie statusu paczki 
            int caseOption2=0;
            bool caseDone = false;
            Status status = Status.in_preparation;
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("Insert status delivery:");
                Console.WriteLine("Insert '1' if status is 'In preparation");
                Console.WriteLine("Insert '2' if status is 'Stored by sender");
                Console.WriteLine("Insert '3' if status is 'Stored in machine");
                Console.WriteLine("Insert '4' if status is 'In delivery");
                Console.WriteLine("Insert '5' if status is 'Delivered");

                string caseOption = Console.ReadLine();
                int.TryParse(caseOption, out caseOption2);
                switch (caseOption2)
                {
                    case 1:
                        status = Status.in_preparation;
                        caseDone = true;
                        break;
                    case 2:
                        status = Status.stored_by_sender;
                        caseDone = true;
                        break;
                    case 3:
                        status = Status.stored_in_machine;
                        caseDone = true;
                        break;
                    case 4:
                        status = Status.in_delivery;
                        caseDone = true;
                        break;
                    case 5:
                        status = Status.delivered;
                        caseDone = true;
                        break;
                    default:
                        Console.WriteLine("Wrong data. Insert data again");
                        Thread.Sleep(2000);
                        caseOption2 = 0;
                        break;
                }                                                  
            } while (caseDone == false);
            Console.Clear();

            //Wprowadzanie courier_id
            Console.WriteLine("Insert courier ID :");
            var courierID = Console.ReadLine();
            Console.Clear();

            //Wprowadzanie danych nadawcy
            bool nameSenderAdd = false;
            string senderName;
            do
            {
                Console.WriteLine("Insert sender name and surname:");
                senderName = Console.ReadLine();
                if (CheckNameValidation(senderName))
                {
                    nameSenderAdd = true;
                }
            }
            while (nameSenderAdd == false);
            Console.Clear();

            //Wprowadzanie danych odbiorcy
            bool nameRecipientAdd = false;
            string recipientName;
            do
            {
                Console.WriteLine("Insert recipient name and surname:");
                recipientName = Console.ReadLine();
                if (CheckNameValidation(recipientName))
                {
                    nameRecipientAdd = true;
                }
            }
            while (nameRecipientAdd == false);
            Console.Clear();

            // wprowadzanie rozmiaru paczki
            int IfSize2;
            bool ifDone3 = false;
            PackageSize pSize = PackageSize.Big;
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("Insert status delivery:");
                Console.WriteLine("Insert '1' if status is 'Small ");
                Console.WriteLine("Insert '2' if status is 'Medium");
                Console.WriteLine("Insert '3' if status is 'Big");

                string IfSize = Console.ReadLine();

                if (int.TryParse(IfSize, out IfSize2))
                {
                    if (IfSize2 == 1)
                    {
                        pSize = PackageSize.Small;
                        ifDone3 = true;
                    }
                    else if (IfSize2 == 2)
                    {
                        pSize = PackageSize.Medium;
                        ifDone3 = true;
                    }
                    else if (IfSize2 == 3)
                    {
                        pSize = PackageSize.Big;
                        ifDone3 = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong data. Insert data again");
                        Thread.Sleep(2000);
                    }
                }
            } while (ifDone3 == false);
            Console.Clear();
            //Wprowadzanie emaila nadawcy
            string senderEmail;
            do
            {
                Console.WriteLine("Insert email sender :");
                senderEmail = Console.ReadLine();
                Console.Clear();
            } while (!CheckEmailValidation(senderEmail));

            //Wprowadzanie numeru telefonu nadawcy
            string senderPhone = "";
            do
            {
                Console.WriteLine("Insert phone number sender:");
                senderPhone = Console.ReadLine();
                Console.Clear();

            } while (!CheckPhoneNumberValidation(senderPhone));

            //Wprowadzanie emaila odbiorcy
            string recipientEmail;
            do
            {
                Console.WriteLine("Insert email recipient:");
                recipientEmail = Console.ReadLine();
                Console.Clear();
            } while (!CheckEmailValidation(recipientEmail));

            //Wprowadzanie numeru telefonu odbiorcy
            string recipientPhone = "";
            do
            {
                Console.WriteLine("Insert phone number recipient:");
                recipientPhone = Console.ReadLine();
                Console.Clear();

            } while (!CheckPhoneNumberValidation(recipientPhone));


            //Wprowadzanie adresu nadawcy
            Console.WriteLine("Insert adres sender :");
            var senderAddres = Console.ReadLine();
            while (senderAddres.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full adres sender:");
                senderAddres = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie adresu odbiorcy
            Console.WriteLine("Insert adres delivery :");
            var deliveryAddres = Console.ReadLine();
            while (deliveryAddres.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full adres delivery:");
                deliveryAddres = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie Id paczkomatu
            Console.WriteLine("Insert delivery machine ID :");
            var deliveryMachineID = Console.ReadLine();
            while (deliveryMachineID.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full  delivery machine ID:");
                deliveryMachineID = Console.ReadLine();
            }
            Console.Clear();
            //data rejestracji
            DateTime registered = DateTime.Now;

            //Generowanie nowego użytkownika
            MemoryRepository.PackagesList.Add(new Package(packageNumber2, status, courierID, senderName, recipientName, pSize, senderEmail, senderPhone,
                recipientEmail, recipientPhone, senderAddres, deliveryAddres, deliveryMachineID, registered));
        }
        
    }
}