using System.Collections.Generic;

namespace ElectronicDevices.Models
{
    public class DeviceListViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public string CurrentKind { get; set; }
    }
}
