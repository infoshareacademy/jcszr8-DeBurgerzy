namespace ParcelDistributionCenter.Model.Context
{
    public class Seed
    {
        public static void Initialize(ParcelDistributionCenterContext context)
        {
            context.Database.EnsureCreated();
            if (context.Couriers.Any())
            {
                return;
            }

            // TODO: TUTAJ DODAĆ ODCZYTYWANIE I WKLEJANIE RZECZY DO SEEDU (PEWNIE Z MEMORYREPOSITORY)

            context.SaveChanges();
        }
    }
}