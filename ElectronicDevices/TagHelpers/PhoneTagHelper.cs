using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ElectronicDevices.TagHelpers
{
    //<a href="tel:+380987654321">Contact us</a>

    public class PhoneTagHelper : TagHelper
    {
        public string Number { get; set; } = "+380685553322";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            output.Attributes.SetAttribute("href", "tel:" + Number);
            output.Attributes.SetAttribute("class", "link-dark");
            output.Content.SetContent(Number);
        }

    }
}
