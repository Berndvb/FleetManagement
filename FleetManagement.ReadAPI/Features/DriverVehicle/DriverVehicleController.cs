using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FleetManagement.ReadAPI.Features.DriverVehicle
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tag-name")]
    public class DriverVehicleController : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

        }
    }
}
