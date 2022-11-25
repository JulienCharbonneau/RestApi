using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("leads")]
    public class Lead
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("full_name_contact")]
        public string FullNameContact { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("project_description")]
        public string ProjectDescription { get; set; }

        [Column("department_elevator")]
        public string DepartmentElevator { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("date_contact_request")]
        public DateTime? DateContactRequest { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
