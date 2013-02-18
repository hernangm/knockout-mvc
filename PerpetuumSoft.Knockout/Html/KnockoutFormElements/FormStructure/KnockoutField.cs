using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutField : KnockoutHtmlTagBase<KnockoutField>
    {
        private KnockoutFieldset Parent { get; set; }
        private string _Content { get; set; }
        private bool _NewLine { get; set; }

        public KnockoutField(KnockoutFieldset fieldset, IField f)
        {
            this.Parent = fieldset;
            this._Content = f.ToHtmlString();
        }

        public KnockoutField NewLine()
        {
            this._NewLine = true;
            return this;
        }

        public KnockoutField Size(int n)
        {
            this.AddClass(string.Format("grid_{0}", n));
            return this;
        }

        public override string ToHtmlString()
        {
            var tagBuilder = new TagBuilder("li");
            if (this.IsFirstChild() || this._NewLine)
            {
                this.AddClass("alpha");
            }
            if (this.IsLastChild() || this.InsertNewLine())
            {
                this.AddClass("omega");
                this.AddClass("clearfix");
            }
            tagBuilder.MergeAttributes(this.HtmlAttributes);
            tagBuilder.InnerHtml = this._Content;
            return tagBuilder.ToString();
        }

        private bool IsFirstChild()
        {
            return this.Parent.Fields.First() == this;
        }

        private bool IsLastChild()
        {
            return this.Parent.Fields.Last() == this;
        }

        private bool InsertNewLine()
        {
            if (IsLastChild())
            {
                return true;
            }
            return this.Parent.Fields[CurrentIndex() + 1]._NewLine;

        }

        private int CurrentIndex()
        {
            return this.Parent.Fields.IndexOf(this);
        }

    }
}
