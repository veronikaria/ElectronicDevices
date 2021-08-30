using System.Collections.Generic;

namespace ElectronicDevices.Models
{
    public class Kind
    {
        public int KindId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Device> Devices { get; set; }
    }
}
