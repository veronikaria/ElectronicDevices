using ElectronicDevices.Models;
using System;
using System.Linq;

namespace ElectronicDevices.EF
{
    public class DbInitializer
    {
        public static void Seed(ApplicationContext context)
        {
            if (!context.Kinds.Any())
            {
                SeedKinds(context);
            }
            if (!context.Devices.Any())
            {
                SeedDevices(context);
            }
        }

        private static void SeedKinds(ApplicationContext context)
        {
            context.Kinds.AddRange(
               new Kind { Name = "Smartphones", Description = "Buy a smartphone" },
               new Kind { Name = "Laptops", Description = "Buy a laptop" },
               new Kind { Name = "TVs", Description = "Buy a TV" }
            );
            context.SaveChanges();
        }

        private static void SeedDevices(ApplicationContext context)
        {
            context.Devices.AddRange(
                    new Device
                    {
                        Name = "SAMSUNG SM-G991B Galaxy S21",
                        ImageUrl = "https://localhost:44348/images/smartphones/s21.jpg",
                        SmallImageUrl = "https://localhost:44348/images/smartphones/s21_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Smartphones", StringComparison.OrdinalIgnoreCase)),
                        Price = 34000,
                        Stock = 15,
                        ShortDescription = "SAMSUNG SM-G991B Galaxy S21 8/128Gb ZAD Phantom Grey (SM-G991BZADSEK)",
                        LongDescription = "The Samsung Galaxy S21 specs are top-notch including a Snapdragon 888 chipset, 5G capability, 8GB RAM coupled with 128/256GB storage, and a 4000mAh battery. The phone sports a 6.2-inch Dynamic AMOLED display with an adaptive 120Hz refresh rate. In the camera department, a triple-sensor setup is presented. The Samsung Galaxy S21 price starts at $800 for the base 128GB model.",
                    },
                    new Device
                    {
                        Name = "Sony Xperia 1 II XQ-AT52",
                        ImageUrl = "https://localhost:44348/images/smartphones/sx1.jpg",
                        SmallImageUrl = "https://localhost:44348/images/smartphones/sx1_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Smartphones", StringComparison.OrdinalIgnoreCase)),
                        Price = 26000,
                        Stock = 22,
                        ShortDescription = "Sony Xperia 1 II XQ-AT52 8/256GB White",
                        LongDescription = "The Sony Xperia 1 II (XQ-AT52) is a good Android phone with 2.84Ghz Octa-Core processor that allows run games and heavy applications. An advantage of the Sony Xperia 1 II (XQ-AT52) is the possibility of using two mobile carriers, a Dual-SIM device with two SIM card slots."
                    },
                    new Device
                    {
                        Name = "Huawei MateBook X Pro",
                        ImageUrl = "https://localhost:44348/images/laptops/matebook.jpg",
                        SmallImageUrl = "https://localhost:44348/images/laptops/matebook_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Laptops", StringComparison.OrdinalIgnoreCase)),
                        Price = 43000,
                        Stock = 32,
                        ShortDescription = "Huawei MateBook X Pro (53010VUK) Space Gray",
                        LongDescription = "The Huawei Matebook X Pro is the first laptop in Huawei's lineup to feature what the company is calling FullView design, giving the laptop a screen to body ratio of 91%. The display is a 13.9-inch LTPS touchscreen with an aspect ratio of 3:2."
                    },
                    new Device
                    {
                        Name = "Huawei MateBook 13",
                        ImageUrl = "https://localhost:44348/images/laptops/matebook13.jpg",
                        SmallImageUrl = "https://localhost:44348/images/laptops/matebook13_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Laptops", StringComparison.OrdinalIgnoreCase)),
                        Price = 24000,
                        Stock = 36,
                        ShortDescription = "Huawei Matebook 13 Heng-W29A Space Gray (53012CUW)",
                        LongDescription = "The Huawei Matebook 13 is the first laptop in Huawei's lineup to feature what the company is calling FullView design, giving the laptop a screen to body ratio of 91%. The display is a 13.9-inch LTPS touchscreen with an aspect ratio of 3:2."
                    },
                    new Device
                    {
                        Name = "HP Pavilion 15",
                        ImageUrl = "https://localhost:44348/images/laptops/hp15.jpg",
                        SmallImageUrl = "https://localhost:44348/images/laptops/hp15_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Laptops", StringComparison.OrdinalIgnoreCase)),
                        Price = 24000,
                        Stock = 36,
                        ShortDescription = "HP Pavilion 15-eg0016ur Foggy Blue (37N90EA)",
                        LongDescription = "HP Pavilion 15 is a Windows 10 laptop with a 15.60-inch display that has a resolution of 1366x768 pixels. It is powered by a Core i7 processor and it comes with 8GB of RAM. The HP Pavilion 15 packs 1TB of HDD storage."
                    },
                    new Device
                    {
                        Name = "HP Pavilion Gaming 17",
                        ImageUrl = "https://localhost:44348/images/laptops/hp17.jpg",
                        SmallImageUrl = "https://localhost:44348/images/laptops/hp17_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("Laptops", StringComparison.OrdinalIgnoreCase)),
                        Price = 24000,
                        Stock = 36,
                        ShortDescription = "HP Pavilion Gaming 17-cd1036ur Dark Grey (232F6EA)",
                        LongDescription = "The latest Pavilion Gaming 17 is an update of last year's model and it throws us a curve ball with a brand new look not seen on any ordinary Pavilion configuration. HP offers a wide variety of SKUs ranging from Core i5-9300H to Core i7-9750H, 60 Hz or 144 Hz 1080p IPS, 8 GB to 32 GB of DDR4 RAM, and either GTX 1050, GTX 1650, or GTX 1660 Ti Max-Q graphics."
                    },
                    new Device
                    {
                        Name = "Samsung 50-4K TV",
                        ImageUrl = "https://localhost:44348/images/tvs/samsung50.jpg",
                        SmallImageUrl = "https://localhost:44348/images/tvs/samsung50_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k=>k.Name.Equals("TVs", StringComparison.OrdinalIgnoreCase)),
                        Price = 20000,
                        Stock = 36,
                        ShortDescription = "Samsung 50 4K UHD Smart TV(QE50Q60TAUXUA)",
                        LongDescription = "The ultra-fast Crystal Processor 4K transforms everything you watch into stunning 4K. See what you’ve been missing on the crisp,clear picture that’s 4X the resolution of Full HD"
                    },
                    new Device
                    {
                        Name = "LG OLED48C14LB",
                        ImageUrl = "https://localhost:44348/images/tvs/lg48.jpg",
                        SmallImageUrl = "https://localhost:44348/images/tvs/lg48_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k => k.Name.Equals("TVs", StringComparison.OrdinalIgnoreCase)),
                        Price = 40000,
                        Stock = 28,
                        ShortDescription = "LG 48 OLED48A16LA Black",
                        LongDescription = "LG OLED TV is a joy to behold. Self-lit pixels allow truly spectacular picture quality and a whole host of design possibilities, while the latest cutting-edge technologies help deliver unprecedented levels of wonder. This is everything you love about TV — elevated in every way."
                    },
                    new Device
                    {
                        Name = "Kivi 40U710KB",
                        ImageUrl = "https://localhost:44348/images/tvs/kivi40.jpg",
                        SmallImageUrl = "https://localhost:44348/images/tvs/kivi40_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k => k.Name.Equals("TVs", StringComparison.OrdinalIgnoreCase)),
                        Price = 8000,
                        Stock = 81,
                        ShortDescription = "TV Kivi 40U710KB 40U710KB Black",
                        LongDescription = "KIVI — is the modern European brand of TVs. Using latest developments of the industry, we create a product that embodies your vision of the perfect TV for relaxation and improvement."
                    },
                    new Device
                    {
                        Name = "Xiaomi Mi TV 4A",
                        ImageUrl = "https://localhost:44348/images/tvs/xiaomi4a.jpg",
                        SmallImageUrl = "https://localhost:44348/images/tvs/xiaomi4a_small.jpg",
                        Kind = context.Kinds.FirstOrDefault(k => k.Name.Equals("TVs", StringComparison.OrdinalIgnoreCase)),
                        Price = 10000,
                        Stock = 39,
                        ShortDescription = "Xiaomi Mi TV 4A 32 International Edition",
                        LongDescription = "The Xiaomi Mi TV 4A is the cheapest version in Xiaomi’s TV lineup. It functions as a Smart TV owing to the Patchwall OS integrated in it. The 32-inch model has few differences when compared to the top variants."
                    }


                );

            context.SaveChanges();
        }
    }
}
