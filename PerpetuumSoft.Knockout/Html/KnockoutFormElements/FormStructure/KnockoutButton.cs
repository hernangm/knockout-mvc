using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutButton : KnockoutHtmlTagBase<KnockoutButton>
    {
        public enum ButtonType
        {
            Button,
            Submit,
            Reset
        }
        public string Label { get; set; }
        public ButtonType Type { get; set; }

        public KnockoutButton()
        {
            this.Type = ButtonType.Button;
        }

        public override string ToHtmlString()
        {
            var buttonTagBuilder = new TagBuilder("button");
            buttonTagBuilder.Attributes.Add("type", this.Type.ToString().ToLowerInvariant());
            buttonTagBuilder.InnerHtml += this.Label;
            return buttonTagBuilder.ToString();
        }
    }
}
