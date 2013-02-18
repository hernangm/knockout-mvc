using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutForm<TModel> : KnockoutHtmlTagBase<KnockoutForm<TModel>, TModel, object>
    {
        private List<KnockoutFieldset> Fieldsets { get; set; }
        public string Action { get; set; }
        public FormMethod Method { get; set; }
        public Expression<Func<TModel, object>> Submit { get; set; }
        public KnockoutFormValidationOptions ValidationOptions { get; set; }

        public KnockoutForm(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("form", context, binding, instancesNames, aliases)
        {
            this.Fieldsets = new List<KnockoutFieldset>();
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (Submit != null)
            {
                tagBuilder.Submit(Submit);
            }
            if (ValidationOptions != null)
            {
                tagBuilder.ValidateOptions(ValidationOptions);
                tagBuilder.BeforeSubmit("validate");
            }
        }
        protected override void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            if (!this.HtmlAttributes.ContainsKey("action"))
            {
                this.HtmlAttributes.Add("action", this.Action);
            }
            if (!this.HtmlAttributes.ContainsKey("method"))
            {
                this.HtmlAttributes.Add("method", this.Method.ToString());
            }
        }

        public override string ToHtmlString()
        {
            var tagBuilder = GetTagBuilder();
            foreach (var fieldset in this.Fieldsets)
            {
                tagBuilder.InnerHtml += fieldset.ToHtmlString();
            }
            return tagBuilder.ToHtmlString();
        }
    }



}
