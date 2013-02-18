using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutFormBuilder<TModel> : IHtmlString
    {

        private KnockoutForm<TModel> Form { get; set; }

        public KnockoutFormBuilder(KnockoutForm<TModel> form)
        {
            this.Form = form;
            this.Form.Action = new UrlHelper(HttpContext.Current.Request.RequestContext).Action(null);
        }

        public KnockoutFormBuilder<TModel> SetAction(string action)
        {
            Form.Action = action;
            return this;
        }

        public KnockoutFormBuilder<TModel> Method(FormMethod method)
        {
            Form.Method = method;
            return this;
        }

        public KnockoutFormBuilder<TModel> Submit(Expression<Func<TModel, object>> command)
        {
            Form.Submit = command;
            return this;
        }

        public KnockoutFormBuilder<TModel> Validate()
        {
            return Validate(new KnockoutFormValidationOptions());

        }

        public KnockoutFormBuilder<TModel> Validate(KnockoutFormValidationOptions validationOptions)
        {
            Form.ValidationOptions = validationOptions;
            return this;
        }

        public KnockoutFormBuilder<TModel> AddFieldset(Action<KnockoutFieldset> f)
        {
            var fieldset = new KnockoutFieldset();
            Form.Fieldsets.Add(fieldset);
            f.Invoke(fieldset);
            return this;
        }
        public KnockoutFormBuilder<TModel> AddButton(KnockoutButton button)
        {
            Form.Buttons.Add(button);
            return this;
        }

        public string ToHtmlString()
        {
            return Form.ToHtmlString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }
}
