using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("columns")]
    public class Column
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("number_floors_served")]
        public long NumberFloorsServed { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("information")]
        public string Information { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("building_type")]
        public string BuildingType { get; set; }

        [Column("battery_id")]
        public long BatteryId { get; set; }

        public virtual ICollection<Elevator> Elevators { get; set; }
    }
}
