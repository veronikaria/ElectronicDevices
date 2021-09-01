using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElectronicDevices.Controllers
{
    public class CartController: Controller
    {
        private readonly IDeviceRepository repository;
        private readonly Cart cart;

        public CartController(IDeviceRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public IActionResult Index()
        {
            var items = cart.GetCartItems();
            cart.CartItems = items;

            CartViewModel vm = new CartViewModel
            {
                Cart = this.cart,
                CartAllSumm = this.cart.GetCartAllSumm()
            };

            return View(vm);
        }

        public IActionResult AddToCart(int deviceId, int number = 1)
        {
            var selectedDevice = this.repository.Devices
                .FirstOrDefault(t => t.DeviceId == deviceId);

            if (selectedDevice != null)
            {
                this.cart.AddToCart(selectedDevice, number);
            }
            return RedirectToAction("Index");
        }
       
    }
}
