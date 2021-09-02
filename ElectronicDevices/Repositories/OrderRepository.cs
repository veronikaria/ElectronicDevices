using ElectronicDevices.EF;
using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicDevices.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext context;
        private readonly Cart cart;

        public OrderRepository(ApplicationContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.DateOrder = DateTime.Now;
            context.Orders.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (CartItem item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Number = item.Number,
                    Price = item.Device.Price,
                    Device = item.Device,
                    DeviceId = item.Device.DeviceId,
                };

                orderDetails.Add(orderDetail);
            }
            order.OrderDetails = orderDetails;

            if (orderDetails.Any())
                context.OrderDetails.AddRange(orderDetails);

            context.SaveChanges();
        }
    }
}
