using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model
{
    public class Parcel
    {
        public uint Package_number { get; init; }
        public ParcelSize Size { get; init; }
        public string Sender_email { get; set; }
        public string Send_parcel_id { get; set; }
        public string Recipient_email { get; set; }
        public string Delivery_parcel_id { get; set; }
        public Status Status { get; set; }
        public string Current_location_id { get; set; }
        public string Courier_id { get; set; }
        public DateTime Registered { get; set; }
        public DateTime Deliver_date { get; set; }
        public DateTime? Expire_date { get; set; }


        public Parcel(uint package_number, ParcelSize size, string sender_email, string send_parcel_id, string recipient_email, string delivery_parcel_id) // konstruktor przy starcie programu - wczytywanie z bazy
        {
            Package_number = package_number;
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

        public Parcel(ParcelSize size, string sender_email, string send_parcel_id, string recipient_email, string delivery_parcel_id) // konstruktor przy wprowadzaniu paczki
        {
            Package_number = 1; // Do opracowania algorytm nadawania numerów paczek;
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

        //public string Delivery_address { get; set; } -  tego parametru nie rozumiem - dostarczamy do paczkomatu więc wszystko jest już w Parcel_id.
        // public string Sender_name { get; set; } - do klienta
        // public string Recipient_name { get; set; } - do klienta
        // public string Sender_phone { get; set; } do klienta
        // public string Recipient_phone { get; set; }  do klienta
        // public string Sender_address { get; set; }  do klienta
    }
}