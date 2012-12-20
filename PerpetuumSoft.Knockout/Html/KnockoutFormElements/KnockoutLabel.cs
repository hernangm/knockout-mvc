using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutLabel<TModel> : IHtmlString
    {
        private readonly string pattern = @"<label for=""{0}"">{1}</label>{2}";
        private IField Field { get; set; }
        public string Text { get; set; }

        public KnockoutLabel(IField field)
        {
            this.Field = field;
        }

        public string ToHtmlString()
        {
            if (this.Field.WrappingLabel())
            {
                return string.Format(pattern, this.Field.GetId(), Field.ToString() + this.Text, string.Empty);
            }
            else
            {
                return string.Format(pattern, this.Field.GetId(), this.Text, Field.ToString());
            }
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
    }
}
