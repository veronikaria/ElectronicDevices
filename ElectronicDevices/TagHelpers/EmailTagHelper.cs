using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace ElectronicDevices.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; } = "devices@gmail.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var content = await output.GetChildContentAsync();
            //string strContent = content.GetContent();
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Attributes.SetAttribute("class", "link-dark");
            output.Content.SetContent(Address);
        }
    }
}
