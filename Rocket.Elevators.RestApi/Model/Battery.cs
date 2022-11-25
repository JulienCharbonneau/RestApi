using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    /// <summary>
    /// Class to mapping battery table 
    /// </summary>
    [Table("batteries")]
    public class Battery
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("type_of_building")]
        public string TypeBuilding { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("date_of_commissioning")]
        public DateTime DateCommissioning { get; set; }

        [Column("date_of_last_inspection")]
        public DateTime DateLastInspection { get; set; }

        [Column("certificate_of_operations")]
        public string CertificateOperations { get; set; }

        [Column("information")]
        public string Information { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("employee_id")]
        public long EmployeeId { get; set; }

        [Column("building_id")]
        public long BuildingId { get; set; }

        public virtual ICollection<Column> Columns { get; set; }

    }
}
