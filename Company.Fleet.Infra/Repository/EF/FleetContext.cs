using Microsoft.EntityFrameworkCore;
using Company.Fleet.Domain;

namespace Company.Fleet.Infra.Repository.EF
{
    public class FleetContext : DbContext
    {
        public FleetContext(DbContextOptions<FleetContext> options):base(options)
        {}

        public DbSet<Vehicle> Vehicles {get; set; }
    }
}