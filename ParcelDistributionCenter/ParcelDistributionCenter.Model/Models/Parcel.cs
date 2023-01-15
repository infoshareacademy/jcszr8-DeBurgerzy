using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model.Models
{
    public class Parcel
    {
        public string Number { get; init; }
        public ParcelSize Size { get; init; }
        public string Sender_email { get; set; }
        public string Sender_locker_id { get; set; }
        public string Recipient_email { get; set; }
        public string Delivery_locker_id { get; set; }
        public Status Status { get; set; }
        public string Current_location_id { get; set; }
        public DateTime Registered { get; set; }
        public DateTime? Deliver_date { get; set; }
        public DateTime? Expire_date { get; set; }



        public Parcel(string number, ParcelSize size, string sender_email, string sender_locker_id, string recipient_email, string delivery_locker_id, Status status, string current_location_id, DateTime registered, DateTime? deliver_date) // konstruktor przy starcie programu - wczytywanie z bazy
        {
            Number = number;
            Size = size;
            Sender_email = sender_email;
            Sender_locker_id = sender_locker_id;
            Recipient_email = recipient_email;
            Delivery_locker_id = delivery_locker_id;
            Status = status;
            Current_location_id = current_location_id;
            Registered = registered;
            Deliver_date = deliver_date;
            Expire_date = null;
        }
    }
         
 }