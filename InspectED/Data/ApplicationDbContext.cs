using Microsoft.EntityFrameworkCore;
using InspectED.Models;

namespace InspectED.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties
        public DbSet<Device> Devices { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
