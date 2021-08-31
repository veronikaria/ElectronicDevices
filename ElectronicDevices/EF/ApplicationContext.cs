using ElectronicDevices.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDevices.EF
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Kind> Kinds { get; set; }

    }
}
