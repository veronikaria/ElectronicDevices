using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicDevices.Controllers
{
    public class DeviceController: Controller
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly IKindRepository kindRepository;

        public DeviceController(IDeviceRepository deviceRepository, IKindRepository kindRepository)
        {
            this.deviceRepository = deviceRepository;
            this.kindRepository = kindRepository;
        }

        public IActionResult List() 
        {
            List<Device> devices = this.deviceRepository.Devices.ToList();
            return View(devices);
        }
    }
}
