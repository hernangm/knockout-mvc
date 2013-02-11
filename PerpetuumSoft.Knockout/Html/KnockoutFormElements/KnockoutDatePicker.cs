using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using System.Web.Mvc;
using System.Linq;
using Newtonsoft.Json;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutDatePicker<TModel> : KnockoutTextInputBase<KnockoutDatePicker<TModel>, TModel>
    {
        public KnockoutDatePicker(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Text, binding, metadata, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (this.Metadata != null)
            {
                var metadata = (IDatePickerConfig)this.Metadata.FirstOrDefault(m => m.GetType().GetInterfaces().Any(p => p == typeof(IDatePickerConfig)));
                if (metadata != null)
                {
                    tagBuilder.DatePicker(Binding, metadata);
                }
                else
                {
                    tagBuilder.DatePicker(Binding);
                }
            }
            else
            {
                tagBuilder.DatePicker(Binding);
            }
        }
    }

    public static class KnockoutDatePickerTagBuilderExtensions
    {
        public static KnockoutBinding<TModel> DatePicker<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression)
        {
            binding.Items.Add(CreateDatePickerComplexBindingItem(expression, null));
            return binding;
        }

        public static KnockoutBinding<TModel> DatePicker<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression, IDatePickerConfig config)
        {
            binding.Items.Add(CreateDatePickerComplexBindingItem(expression, config));
            return binding;
        }

        private static KnockoutBindingComplexItem CreateDatePickerComplexBindingItem<TModel>(Expression<Func<TModel, object>> expression, IDatePickerConfig config)
        {
            var complexBinding = new KnockoutBindingComplexItem { Name = "datepicker" };
            complexBinding.Add(new KnockoutBindingItem<TModel, object> { Name = "value", Expression = expression });
            complexBinding.Add(new KnockoutBindingStringItem("options", JsonConvert.SerializeObject(config), false));
            return complexBinding;
        }
    }
}