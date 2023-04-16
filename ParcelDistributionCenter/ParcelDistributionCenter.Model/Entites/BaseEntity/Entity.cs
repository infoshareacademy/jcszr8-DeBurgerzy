using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributionCenter.Model.Entites.BaseEntity
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}