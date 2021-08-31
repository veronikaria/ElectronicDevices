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
            get => this.context.Device.Include(dev => dev.Kind).ToList(); 
            set => throw new NotImplementedException(); 
        }

        public Device GetDeviceById(int id)
        {
            return this.context.Device.FirstOrDefault(dev => dev.DeviceId==id);
        }

        public Device GetDeviceByName(string name)
        {
            return this.context.Device.FirstOrDefault(dev => dev.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
