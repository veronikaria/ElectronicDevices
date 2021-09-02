using ElectronicDevices.Models;

namespace ElectronicDevices.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
