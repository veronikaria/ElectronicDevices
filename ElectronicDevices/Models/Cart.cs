using ElectronicDevices.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicDevices.Models
{
    public class Cart
    {
        private readonly ApplicationContext context;
        public Cart(ApplicationContext context)
        {
            this.context = context;
        }
        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public const string CartSessionKey = "CartId";

        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            ApplicationContext context = service.GetService<ApplicationContext>();
            string cartId = session.GetString(CartSessionKey) ?? Guid.NewGuid().ToString();
            session.SetString(CartSessionKey, cartId);
            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart(Device device, int cnt)
        {
            CartItem cart = context.CartItems.FirstOrDefault(
                c => c.DeviceId == device.DeviceId
                && c.CartId == this.CartId
                );
            if (cart == null)
            {
                cart = new CartItem
                {
                    CartId = this.CartId,
                    DateCreated = DateTime.Now,
                    Device = device,
                    Number = cnt,
                };
                context.CartItems.Add(cart);
            }
            else
            {
                cart.Number += cnt;
            }
            context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            if (this.CartItems == null)
            {
                this.CartItems = context.CartItems.Where(c => c.CartId.Equals(CartId))
                    .Include(c => c.Device).ToList();
            }
            return this.CartItems;

        }

        public void ClearCart()
        {
            var items = context.CartItems.Where(c => c.CartId == this.CartId);
            this.context.CartItems.RemoveRange(items);
            this.context.SaveChanges();
        }

        public decimal GetCartAllSumm()
        {
            return this.context.CartItems
                .Where(c => c.CartId == this.CartId)
                .Select(c => c.Device.Price * c.Number)
                .Sum();
        }
    }
}
