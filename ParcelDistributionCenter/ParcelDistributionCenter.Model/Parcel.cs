namespace ParcelDistributionCenter.Model
{
    public class Parcel //na razie tak wstępnie zrobione
    {
        public int package_number { get; set; }//moze uint? lub zabezpieczenue przed ujemnymi
        public Status status { get; set; } //enum
        public string courier_id { get; set; }
        public string sender_name { get; set; }
        public string recipient_name { get; set; }
        public ParcelSize size { get; set; }//enum
        public string sender_email { get; set; }
        public string sender_phone { get; set; }
        public string recipient_email { get; set; }
        public string recipient_phone { get; set; }
        public string sender_address { get; set; }
        public string delivery_address { get; set; }
        public string delivery_machine_id { get; set; }
        public DateTime registered { get; set; }//nie wiem czy dobrze

    }
}

/* //CLASSES:
 * 
 * Parcel ( 
 *      int ParcelId, "enum" Size, Client Sender, Client Recipient, Address SendAddres, Address DeliveryAddress
 *      "enum" ParcelStatus, Address CurrentAdress, Date PostDate, Date DeliveryDate, Date ExpireDate )
 * 
 *   //ExpireDate - data, po której paczka zostanie zwrócona do nadawcy w razie braku odbioru
 * 
 * Client( int ClientId, string Name, string Surname, Addres ClientAddres, Phone PhoneNumber)
 * 
 * ParcelLocker( int LockerId, "enum" LockerStatus, Capacity LockerCapacity, Addres LockerAddres, Parcel<list> StoredParcels)
 *  
 * DeliveryCenter( int CenterId, Capacity CenterCapacity, Adress CenterAdress, Parcel<list> StoredParcels, ParcelLocker <list> SuportedLockers) 
 * 
 * Courier( int Id, Capacity CourierCapacity, int <list> Route, Parcel<list> Parcels)
 * 
 * 
 * //POMOCNICZE
 * Capacity ( int L, int S, int M )
 * 
 * Date (int day, "enum" mounth, int year)
 * 
 * Addres ( ??GoogleFormat??)
 * 
 * Phone ()
 *
 *
 * // 1. Narazie zakładałbym że wszystkie paczki trafiają z paczkomatu do centrum przełądunkowego i potem do odpowiednich paczkomatów. 
 *       Jeżeli paczkomatu docelowego niema na liście SuportedLockers to wysyłka do DeliveryCenter które wspiera paczkomat docelowy
 * // 2. Na początek zakładałbym że kuruer może zrobić dziennie 2 kursy - Centrum-Paczkomat-Centrum (możemy kiedyś dodać listę odległości ale już chyba jest to dość skomplikowane)
 * // 3. Obecną lokalizację paczki określa dokłądnie Addres więc nie trzeba już dawać ID kuriera/paczkomatu/centrum
 * // 4. Przepraszam za literówki - to był dłuugi dzień 
*/