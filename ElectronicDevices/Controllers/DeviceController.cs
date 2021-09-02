using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult List(string kind)
        {
            List<Device> devices;
            string current = string.Empty;
            if (string.IsNullOrEmpty(kind))
            {
                current = "AllDevices";
                devices = deviceRepository.Devices.ToList();
            }

            else
            {
                if (String.Compare(kind, "Smartphones", comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    current = "Smartphones";
                else if (String.Compare(kind, "Laptops", comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    current = "Laptops";
                else if (String.Compare(kind, "TVs", comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    current = "TVs";
                else
                    return NotFound();

                devices = deviceRepository.Devices.Where(x => x.Kind.Name == current).ToList();
            }

            DeviceListViewModel vm = new DeviceListViewModel();
            vm.Devices = devices;
            vm.CurrentKind = current;

            //List<Device> devices = deviceRepository.Devices.ToList();
            return View(vm);
        }

        public IActionResult Details(int deviceId)
        {
            Device devices = this.deviceRepository.Devices.FirstOrDefault(dev=>dev.DeviceId== deviceId);
            return View(devices);
        }

        [HttpPost]
        public IActionResult Details(Device device, int quantity)
        {
            return RedirectToAction("AddToCart", "Cart", new { deviceId = device.DeviceId, number = quantity });
        }
    }
}
