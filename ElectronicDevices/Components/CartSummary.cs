using ElectronicDevices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElectronicDevices.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart cart;

        public CartSummary(Cart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            //List<CartItem> items = new List<CartItem> { new CartItem(), new CartItem() }; 
            // UNCOMMENT !!!
            List<CartItem> items = this.cart.GetCartItems();
            this.cart.CartItems = items;

            CartViewModel vm = new CartViewModel
            {
                Cart = this.cart,
                CartAllSumm = this.cart.GetCartAllSumm()
            };

            return View(vm);
        }
    }
}
