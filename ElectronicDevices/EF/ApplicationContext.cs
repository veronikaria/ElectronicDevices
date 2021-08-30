using ElectronicDevices.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDevices.EF
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }

        public DbSet<Device> Device { get; set; }
        public DbSet<Kind> Kind { get; set; }

    }
}
