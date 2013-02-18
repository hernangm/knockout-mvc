using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutFieldset : KnockoutHtmlTagBase<KnockoutFieldset>
    {
        private List<KnockoutField> Fields { get; set; }
        private string Legend { get; set; }

        public KnockoutFieldset()
        {
            this.Fields = new List<KnockoutField>();
        }

        public override string ToHtmlString()
        {
            var tagBuilder = new TagBuilder("fieldset");
            tagBuilder.MergeAttributes(this.HtmlAttributes);
            if (!string.IsNullOrEmpty(this.Legend))
            {
                tagBuilder.InnerHtml += string.Format(@"<legend><span>{0}</span></legend>", this.Legend);
            }
            if (this.Fields.Count > 0)
            {
                var fields = string.Empty;
                foreach (var field in this.Fields)
                {
                    fields += field.ToHtmlString();
                }
                tagBuilder.InnerHtml += string.Format("<ol>{0}</ol>", fields);
            }

            return tagBuilder.ToString();
        }
    }
}
