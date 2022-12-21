using System.ComponentModel.DataAnnotations.Schema;

namespace Rocket.Elevators.RestApi.Model
{
    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        public long Id { get; set; }

         [Column("email")]
        public string? Email { get; set; }

        [Column("email_company_contact")]
        public string? ContactEmail { get; set; }

         [Column("_email_service")]
        public string? EmailService { get; set; }



        }
    }

