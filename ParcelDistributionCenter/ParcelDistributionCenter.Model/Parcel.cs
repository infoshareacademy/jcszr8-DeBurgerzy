using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model
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

       /* public Parcel(ParcelSize size, string sender_email, string send_parcel_id, string recipient_email, string delivery_parcel_id) // konstruktor przy wprowadzaniu paczki
        {
           Number = "1"; // Do opracowania algorytm nadawania numerów paczek;
            Size = size;
            Sender_email = sender_email;
            Send_parcel_id = send_parcel_id;
            Recipient_email = recipient_email;
            Delivery_parcel_id = delivery_parcel_id;
            Status = (Status)0;
            Current_location_id = "Sender";
            Courier_id = "0";
            Registered = DateTime.Now;
            Expire_date = Registered.AddDays(2);
        }

        */


        //public string Delivery_address { get; set; } -  tego parametru nie rozumiem - dostarczamy do paczkomatu więc wszystko jest już w Parcel_id.
        // public string Sender_name { get; set; } - do klienta
        // public string Recipient_name { get; set; } - do klienta
        // public string Sender_phone { get; set; } do klienta
        // public string Recipient_phone { get; set; }  do klienta
        // public string Sender_address { get; set; }  do klienta
    }
}