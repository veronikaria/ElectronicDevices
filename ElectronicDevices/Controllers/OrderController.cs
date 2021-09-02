using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElectronicDevices.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly Cart cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            this.orderRepository = orderRepository;
            this.cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            List<CartItem> items = this.cart.GetCartItems();
            this.cart.CartItems = items;
            if (ModelState.IsValid)
            {
                this.orderRepository.CreateOrder(order);
                this.cart.ClearCart();
                return RedirectToAction("CheckoutOk");
            }
            return View(order);
        }

        public IActionResult CheckoutOk()
        {
            return View();
        }
    }
}
