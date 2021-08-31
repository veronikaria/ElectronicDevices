using ElectronicDevices.EF;
using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicDevices.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationContext context;

        public DeviceRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Device> Devices 
        {
            get => this.context.Devices.Include(dev => dev.Kind).ToList(); 
        }

        public Device GetDeviceById(int id)
        {
            return this.context.Devices.FirstOrDefault(dev => dev.DeviceId==id);
        }

        public Device GetDeviceByName(string name)
        {
            return this.context.Devices.FirstOrDefault(dev => dev.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
