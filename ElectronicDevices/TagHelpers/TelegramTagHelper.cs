using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ElectronicDevices.TagHelpers
{
    public class TelegramTagHelper : TagHelper
    {
        public string Username { get; set; } = "ElectronicEquipmentSite";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            output.Attributes.SetAttribute("href", "https://telegram.me/" + Username);
            output.Attributes.SetAttribute("class", "text-primary");

            output.Content.SetHtmlContent("<i class='fa fa-telegram'></i>");
        }

    }
}
