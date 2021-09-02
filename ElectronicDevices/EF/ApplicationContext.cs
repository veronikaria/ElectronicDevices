using ElectronicDevices.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDevices.EF
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            //Database.EnsureDeleted();
            Database.Migrate();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
