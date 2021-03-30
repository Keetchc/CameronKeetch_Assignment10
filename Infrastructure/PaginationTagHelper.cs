using CameronKeetch_Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment10.Infrastructure
{

    //inherits from TagHelper class, associated with a div tag
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        //set an attribute that is an IUrlHelperFactory
        private IUrlHelperFactory urlInfo;

        //constructor that sets the IurlHelperFactory to urlInfo.
        public PaginationTagHelper (IUrlHelperFactory urlHelper)
        {
            urlInfo = urlHelper;
        }

        //creates a dictionary we can use to store things
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        //creating a public instance of a ViewContext
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        //property that ensures it is set up correctly.
        public PageNumberingInfo PageInfo { get; set; }
        
        public string PageAction { get; set; }

        //properties to allos us to have css styling
        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //building the tag that will display the pagination and allow navigation between pages
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //create IUrlHelper to
            IUrlHelper urlH = urlInfo.GetUrlHelper(ViewContext);
            
            //variables for both tags
            TagBuilder finishedTag = new TagBuilder("div");
            


            for (int i =1; i <= PageInfo.NumPages; i++)
            {
                //builds new tag each time
                TagBuilder individualTag = new TagBuilder("a");


                KeyValuePairs["pageNum"] = i;
                //build outertag first
                individualTag.Attributes["href"] = urlH.Action("Index", KeyValuePairs);

                if (PageClassesEnabled)
                {
                    individualTag.AddCssClass(PageClass);
                    individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                individualTag.InnerHtml.Append(i.ToString());

                //adds to inner tag
                finishedTag.InnerHtml.AppendHtml(individualTag);

            }
            
            //the output of the tags
            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}
