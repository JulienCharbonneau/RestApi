using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("fact_interventions")]
    public class FactIntervention
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("employeeId")]
        public long EmployeeId { get; set; }

        [Column("buildingId")]
        public long BuildingId { get; set; }

        [Column("batteryId")]
        public long BatteryId { get; set; }

        [Column("columnId")]
        public DateTime ColumnId { get; set; }

        [Column("elevatorId")]
        public DateTime ElevatorId { get; set; }

        [Column("interventionStartAt")]
        public string InterventionStartAt { get; set; }

        [Column("interventionEndAt")]
        public string InterventionEndAt { get; set; }

        [Column("result")]
        public string Result { get; set; }

        [Column("report")]
        public string Report { get; set; }

        [Column("status")]
        public long Status { get; set; }

     
    }
}
