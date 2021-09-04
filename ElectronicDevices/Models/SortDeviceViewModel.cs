using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDevices.Models
{
    public class SortDeviceViewModel
    {
        public SortDeviceState PriceSort { get; set; }

        public SortDeviceViewModel(SortDeviceState sortDevice)
        {
            PriceSort = sortDevice == SortDeviceState.PriceAsc
                ? SortDeviceState.PriceAsc : SortDeviceState.PriceDesc;
        }
    }
}
