using Microsoft.EntityFrameworkCore;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Infra.Context
{
    public class FluentMySqlContext : DbContext
    {
        public FluentMySqlContext(DbContextOptions<FluentMySqlContext> options) : base(options) 
        {

        }

        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Elevator> Elevators{ get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Customer> Customers { get; set; }
       
    }
}
