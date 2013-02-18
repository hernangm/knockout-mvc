using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutForm<TModel> : KnockoutHtmlTagBase<KnockoutForm<TModel>, TModel, object>
    {
        private List<KnockoutFieldset> Fieldsets { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public Expression<Func<TModel, object>> Submit { get; set; }
        public KnockoutFormValidationOptions ValidationOptions { get; set; }

        public KnockoutForm(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
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

        public override string ToHtmlString()
        {
            var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "form", InstanceNames, Aliases);
            this.HtmlAttributes.Add("action", this.Action);
            this.HtmlAttributes.Add("method", this.Method);
            tagBuilder.ApplyAttributes(this.HtmlAttributes);
            foreach (var fieldset in this.Fieldsets)
            {
                tagBuilder.InnerHtml += fieldset.ToHtmlString();
            }
            return tagBuilder.ToString();
        }
    }



}
