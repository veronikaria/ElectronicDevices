using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDevices.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceRepository deviceRepository;

        public HomeController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public IActionResult Index(string name, int page = 1, SortDeviceState sortDevice = SortDeviceState.Default)
        {
            int pageSize = 3;

            var devices = this.deviceRepository.Devices;

            if (!string.IsNullOrEmpty(name))
            {
                devices = devices.Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortDevice)
            {
                case SortDeviceState.PriceAsc:
                    devices = devices.OrderBy(t => t.Price);
                    break;
                case SortDeviceState.PriceDesc:
                    devices = devices.OrderByDescending(t => t.Price);
                    break;
                default:
                    break;
            }

            var count = devices.Count();
            var items = devices.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            HomeViewModel vm = new HomeViewModel
            {
                Devices = items,
                SortDeviceViewModel = new SortDeviceViewModel(sortDevice),
                PageDeviceViewModel = new PageDeviceViewModel(count, page, pageSize)
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
