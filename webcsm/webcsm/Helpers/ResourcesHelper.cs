using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webcsm.Helpers
{
    public static class ResourcesHelper
    {
        /// <summary>
        /// Renders an HTML tag script
        /// </summary>
        public static string Script(this HtmlHelper helper, string script)
        {
            // Instantiate a UrlHelper 
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            // Create tag builder
            var builder = new TagBuilder("script");

            // Add attributes
            builder.MergeAttribute("src", urlHelper.Content(String.Format("~/Scripts/{0}", script)));
            builder.MergeAttribute("type", "text/javascript");

            // Render tag
            return builder.ToString();
            
        }
        /// <summary>
        /// Renders an HTML link to css
        /// </summary>
        public static string Css(this HtmlHelper helper, string css, CssMedia media)
        {
            // Instantiate a UrlHelper 
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            // Create tag builder
            var builder = new TagBuilder("link");

            // Add attributes
            builder.MergeAttribute("href", urlHelper.Content(String.Format("~/Content/css/{0}", css)));
            builder.MergeAttribute("rel", "stylesheet");
            builder.MergeAttribute("type", "text/css");
            builder.MergeAttribute("media", Enum.GetName(typeof(CssMedia),media).ToLower());
            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public enum CssMedia
        {
            Screen,
            Tty,
            Tv,
            Projection,
            Handheld,
            Print,
            Braille,
            Aural,
            All
        }
    }
}