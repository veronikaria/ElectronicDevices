using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicDevices.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        public int Number { get; set; }
        public int DeviceId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Device Device { get; set; }
        
    }
}
