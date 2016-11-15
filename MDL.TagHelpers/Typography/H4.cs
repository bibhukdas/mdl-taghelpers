using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;
using System;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement(H4)]
    [Mdl("h4" )]
    [Css("mdl-typography--display-1")]
    public class H4 : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetContent(content);
        }
    }
}