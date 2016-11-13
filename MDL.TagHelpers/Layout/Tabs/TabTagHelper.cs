﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Layout.Tabs
{
    [HtmlTargetElement(TAB)]
    [Mdl("div", "mdl-tabs", "mdl-js-tabs" ,"mdl-js-ripple-effect")]
    [RestrictChildren(TAB_BAR, TAB_CONTENT)]
    public class TabTagHelper: BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetHtmlContent(content);
        }
        
    }

    [HtmlTargetElement(TAB_BAR)]
    [Mdl("div", "mdl-tabs__tab-bar")]
    [RestrictChildren(TAB_BAR_LINK)]
    public class TabBarTagHelper : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetHtmlContent(content);
        }

    }

    [HtmlTargetElement(TAB_BAR_LINK)]
    [Mdl("a","mdl-tabs__tab")]
    public class TabBarLinkTagHelper : BaseTagHelper
    {
        public bool Active { get; set; } = false;
        public string For { get; set; } 
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            if(String.IsNullOrEmpty(For))
            {
                throw new NotSupportedException("You must set the Id on the tab and then the for attribute on the corresponding panel");
            }
            output.Content.SetHtmlContent(content);

            var prefix = ((For.Substring(0, 1)).CompareTo("#") != 0) ? "#" : "";
            output.Attributes.SetAttribute("href", prefix + For);
            if (Active)
            {
                output.AppendClass("is-active");
            }
        }

    }

    [HtmlTargetElement(TAB_CONTENT)]
    [Mdl("div", true, "mdl-tabs__panel")]
    public class TabContentTagHelper : BaseTagHelper
    {
        public string Id { get; set; }
        public bool Active { get; set; } = false;
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            if (String.IsNullOrEmpty(Id))
            {
                throw new NotSupportedException("You must set the Id on the tab and then the for attribute on the corresponding panel");
            }

            if(Active)
            {
                output.AppendClass("is-active");
            }
            output.Content.SetHtmlContent(content);

            output.Attributes.SetAttribute("id", Id);


        }

    }
}
