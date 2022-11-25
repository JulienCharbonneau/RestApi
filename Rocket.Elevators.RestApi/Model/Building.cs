using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("buildings")]
    public class Building
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("buildingAddress")]
        public string BuildingAddress { get; set; }

        [Column("adminFullName")]
        public string AdminFullName { get; set; }

        [Column("adminEmail")]
        public string AdminEmail { get; set; }

        [Column("adminPhoneNumber")]
        public string AdminPhoneNumber { get; set; }

        [Column("technicalContactFullName")]
        public string TechnicalContactFullName { get; set; }

        [Column("technicalContactEmail")]
        public string TechnicalContactEmail { get; set; }

        [Column("technicalContactPhoneNumber")]
        public string TechnicalContactPhoneNumber { get; set; }

        [Column("customer_id")]
        public long CustomerId { get; set; }



        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
