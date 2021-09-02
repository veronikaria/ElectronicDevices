using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDevices.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int DeviceId { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }

        public virtual Device Device { get; set; }
        public virtual Order Order { get; set; }
    }
}
