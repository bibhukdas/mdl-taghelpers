using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Tooltips
{
    [HtmlTargetElement(TOOLTIP)] 
    [Mdl("div")]
    [Css("mdl-tooltip")]
    public class Tooltip : BaseTagHelper
    {
        public bool Large { get; set; }
        public bool MdlId { get; set; }

        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Top { get; set; }
        public bool Bottom { get; set; }

        public Tooltip ()
        {
            Large = false;
        }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            // Conditional CSS
            if (Large)
            {
                output.AppendClass("mdl-tooltip--large");
            }

            if (Left)
            {
                output.AppendClass("mdl-tooltip--left");
            }

            if (Right)
            {
                output.AppendClass("mdl-tooltip--right");
            }

            if (Top)
            {
                output.AppendClass("mdl-tooltip--top");
            }

            if (Bottom)
            {
                output.AppendClass("mdl-tooltip--bottom");
            }
            
            output.Content.SetContent(content);
        }
        
    }
}