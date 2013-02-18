using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutFieldset : KnockoutHtmlTagBase<KnockoutFieldset>
    {
        public List<KnockoutField> Fields { get; private set; }
        private string _Legend { get; set; }

        public KnockoutFieldset()
        {
            this.Fields = new List<KnockoutField>();
        }

        public KnockoutFieldset Legend(string legend)
        {
            this._Legend = legend;
            return this;
        }

        public KnockoutField AddField(IField f)
        {
            var field = new KnockoutField(this, f);
            this.Fields.Add(field);
            return field;
        }

        public override string ToHtmlString()
        {
            var tagBuilder = new TagBuilder("fieldset");
            tagBuilder.MergeAttributes(this.HtmlAttributes);
            if (!string.IsNullOrEmpty(this._Legend))
            {
                tagBuilder.InnerHtml += string.Format(@"<legend><span>{0}</span></legend>", this._Legend);
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
