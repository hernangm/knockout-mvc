using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{

    public class KnockoutValidationSummary : KnockoutHtmlTagBase<KnockoutValidationSummary>
    {
        private const string template = "<!-- ko if: hasErrors --><div class=\"msg error\"><ul data-bind=\"foreach:errores\"><li data-bind=\"text: $data\"></li></ul></div><!-- /ko -->";
        private string ErrorCollectionVariable { get; set; }
        private string Scope { get; set; }

        public KnockoutValidationSummary()
            : this(null, null)
        {
        }

        public KnockoutValidationSummary(string errorCollectionVariable, string scope)
        {
            this.ErrorCollectionVariable = !string.IsNullOrEmpty(errorCollectionVariable) ? errorCollectionVariable : "Errors";
            this.Scope = scope;
        }

        public override string ToHtmlString()
        {
            var salida = string.Format(template, this.ErrorCollectionVariable);
            return string.IsNullOrEmpty(this.Scope) ? salida : string.Format("<!-- ko with:{0} -->{1}<!-- /ko -->", this.Scope, salida);
        }

    }
}
