using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace PerpetuumSoft.Knockout.Html
{
    public static class KnockoutFormBindingExtensions
    {
        public static KnockoutBinding<TModel> Submit<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression)
        {
            binding.Items.Add(new KnockoutBindingItem<TModel, object> { Name = "submit", Expression = expression });
            return binding;
        }

        public static KnockoutBinding<TModel> ValidateOptions<TModel>(this KnockoutBinding<TModel> binding, KnockoutFormValidationOptions validationOptions)
        {
            binding.Items.Add(new KnockoutBindingStringItem("validateOptions", JsonConvert.SerializeObject(validationOptions), false));
            return binding;
        }

        public static KnockoutBinding<TModel> BeforeSubmit<TModel>(this KnockoutBinding<TModel> binding, string method)
        {
            binding.Items.Add(new KnockoutBindingStringItem { Name = "beforeSubmit", Value = method, NeedQuotes = false });
            return binding;
        }
    }
}
