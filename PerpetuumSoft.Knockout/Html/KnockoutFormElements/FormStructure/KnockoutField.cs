using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutField : KnockoutHtmlTagBase<KnockoutField>
    {
        private string Field { get; set; }

        public override string ToHtmlString()
        {
            var tagBuilder = new TagBuilder("li");
            tagBuilder.MergeAttributes(this.HtmlAttributes);
            tagBuilder.InnerHtml = this.Field;
            return tagBuilder.ToString();
        }
    }
}
