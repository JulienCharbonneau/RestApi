using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("elevators")]
    public class Elevator
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("date_commissioning")]
        public DateTime DateCommissioning { get; set; }

        [Column("date_last_inspection")]
        public DateTime DateLastInspection { get; set; }

        [Column("certificate_inspection")]
        public string CertificateInspection { get; set; }

        [Column("information")]
        public string Information { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("building_type")]
        public string BuildingType { get; set; }

        [Column("column_id")]
        public long ColumnId { get; set; }

    }
}
