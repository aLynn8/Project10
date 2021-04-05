using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SharpenTheSaw.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach (Wright) Section 2 Group 1

namespace SharpenTheSaw.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]

    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;

        public PaginationTagHelper (IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public PageNumberingInfo PageInfo { get; set; }
        //I think I'm stll using the variable MealType as I switch to Bowlers, but for teams. Not 100% sure though
        public string MealType { get; set; }

        //Build dictionary with our own key value pairs
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //fulls in URLFACTOR info passedin above
            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

            TagBuilder FinishedTag = new TagBuilder("div");

            //Build Page options and links

            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                
                
                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;

                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);
                individualTag.InnerHtml.Append(i.ToString());

                FinishedTag.InnerHtml.AppendHtml(individualTag);
            }

            output.Content.AppendHtml(FinishedTag.InnerHtml);
        }
    }
}
