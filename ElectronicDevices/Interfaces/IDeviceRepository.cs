using ElectronicDevices.Models;
using System.Collections.Generic;

namespace ElectronicDevices.Interfaces
{
    public interface IDeviceRepository
    {
        public IEnumerable<Device> Devices { get;}
        public Device GetDeviceById(int id);
        public Device GetDeviceByName(string name);
    }
}
