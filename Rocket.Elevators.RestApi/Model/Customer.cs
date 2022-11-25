using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("email_company_contact")]
        public string Email { get; set; }
    }
}
