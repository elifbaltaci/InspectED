using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InspectED.Data
{
    public class AppDbContext: DbContext

    {
        //Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }

        //DbSet properties

        public DbSet<Models.Device> Devices { get; set; }

        public DbSet<Models.Grade> Grades { get; set; }

        }
}
