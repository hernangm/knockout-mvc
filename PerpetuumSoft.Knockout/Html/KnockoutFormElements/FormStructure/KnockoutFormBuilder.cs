using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutFormBuilder<TModel> : IHtmlString
    {

        private KnockoutForm<TModel> Form { get; set; }

        public KnockoutFormBuilder(KnockoutForm<TModel> form)
        {
            this.Form = form;
        }

        public KnockoutFormBuilder<TModel> SetAction(string action)
        {
            Form.Action = action;
            return this;
        }

        public KnockoutFormBuilder<TModel> Method(string method)
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
