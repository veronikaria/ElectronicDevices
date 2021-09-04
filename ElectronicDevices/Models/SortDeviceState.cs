using System.ComponentModel.DataAnnotations;

namespace ElectronicDevices.Models
{
    public enum SortDeviceState
    {
        [Display(Name = "По умолчанию")]
        Default,
        [Display(Name = "По возрастанию цены")]
        PriceAsc,
        [Display(Name = "По убыванию цены")]
        PriceDesc
    }
}
