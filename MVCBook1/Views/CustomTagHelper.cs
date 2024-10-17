using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCBook1.Views
{
    [HtmlTargetElement("MyTag")]
    public class CustomTagHelper:TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "H1";
            output.Content.SetContent($"Hello,{Name}");
        }
    }
}
