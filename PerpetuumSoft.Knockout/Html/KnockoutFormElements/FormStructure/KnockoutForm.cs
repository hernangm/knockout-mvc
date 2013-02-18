using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutForm<TModel> : KnockoutHtmlTagBase<KnockoutForm<TModel>, TModel, object>
    {
        public List<KnockoutFieldset> Fieldsets { get; private set; }
        public string Action { get; set; }
        public FormMethod Method { get; set; }
        public Expression<Func<TModel, object>> Submit { get; set; }
        public KnockoutFormValidationOptions ValidationOptions { get; set; }
        public List<KnockoutButton> Buttons { get; set; }

        public KnockoutForm(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("form", context, binding, instancesNames, aliases)
        {
            this.Fieldsets = new List<KnockoutFieldset>();
            this.Buttons = new List<KnockoutButton>();
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (Submit != null)
            {
                tagBuilder.Submit(Submit);
            }
            if (IsValidatableForm())
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
                this.HtmlAttributes.Add("method", this.Method.ToString().ToLowerInvariant());
            }
        }

        public override string ToHtmlString()
        {
            var tagBuilder = GetTagBuilder();
            if (IsValidatableForm())
            {
                tagBuilder.InnerHtml += new KnockoutValidationSummary().ToHtmlString();
            }
            foreach (var fieldset in this.Fieldsets)
            {
                tagBuilder.InnerHtml += fieldset.ToHtmlString();
            }
            if (this.Buttons.Count > 0)
            {
                var buttonsTagBuilder = new TagBuilder("div");
                buttonsTagBuilder.AddCssClass("form-actions");
                foreach (var b in this.Buttons)
                {
                    buttonsTagBuilder.InnerHtml += b;
                }
                tagBuilder.InnerHtml += buttonsTagBuilder.ToString();
            }
            return tagBuilder.ToHtmlString();
        }

        private bool IsValidatableForm()
        {
            return ValidationOptions != null;
        }
    }



}
