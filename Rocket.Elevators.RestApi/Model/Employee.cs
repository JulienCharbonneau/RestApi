using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("employees")]
    public class Employee
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("first_name")]
        public string? FirstNname { get; set; }

        [Column("title")]
        public string? Title { get; set; }

         [Column("email")]
        public string? Email { get; set; }

    }
}
