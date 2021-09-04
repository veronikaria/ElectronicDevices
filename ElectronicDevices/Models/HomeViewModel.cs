using System.Collections.Generic;

namespace ElectronicDevices.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public SortDeviceViewModel SortDeviceViewModel { get; set; }
        public PageDeviceViewModel PageDeviceViewModel { get; set; }
    }
}
