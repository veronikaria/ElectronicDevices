namespace ElectronicDevices.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public int KindId { get; set; }
        public virtual Kind Kind { get; set; }
    }
}
