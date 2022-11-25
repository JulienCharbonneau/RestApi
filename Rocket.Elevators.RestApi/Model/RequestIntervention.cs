using System.ComponentModel.DataAnnotations.Schema;
namespace Rocket.Elevators.RestApi.Model
{
    [Table("request_interventions")]
    public class RequestIntervention
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("author")]
        public long author { get; set; }
        [Column("employee_id")]
        public long employee_id { get; set; }
        [Column("building_id")]
        public long building_id { get; set; }
        [Column("battery_id")]
        public long? battery_id { get; set; }
        [Column("column_id")]
        public long? column_id { get; set; }
        [Column("elevator_id")]
        public long? elevator_id { get; set; }
        [Column("start_date")]
        public string? start_date { get; set; } = null!;
        [Column("end_date")]
        public string? end_date { get; set; } = null!;
        [Column("result")]
        public string result { get; set; } = null!;
        [Column("report")]
        public string report { get; set; } = null!;
        [Column("status")]
        public string status { get; set; } = null!;
    }
}