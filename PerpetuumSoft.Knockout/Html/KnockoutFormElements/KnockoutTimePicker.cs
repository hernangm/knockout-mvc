using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Web.Mvc;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{

    public class KnockoutTimePicker<TModel> : KnockoutTextInputBase<KnockoutTimePicker<TModel>, TModel>
    {
        public KnockoutTimePicker(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Text, binding, metadata, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (this.Metadata != null)
            {
                var metadata = (ITimePickerConfig)this.Metadata.FirstOrDefault(m => m.GetType().GetInterfaces().Any(p => p == typeof(IDatePickerConfig)));
                if (metadata != null)
                {
                    tagBuilder.TimePicker(Binding, metadata);
                }
                else
                {
                    tagBuilder.TimePicker(Binding);
                }
            }
            else
            {
                tagBuilder.TimePicker(Binding);
            }
        }
    }

    public static class KnockoutTimePickerTagBuilderExtensions
    {
        public static KnockoutBinding<TModel> TimePicker<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression)
        {
            binding.Items.Add(CreateTimePickerComplexBindingItem(expression, null));
            return binding;
        }

        public static KnockoutBinding<TModel> TimePicker<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression, ITimePickerConfig config)
        {
            binding.Items.Add(CreateTimePickerComplexBindingItem(expression, config));
            return binding;
        }

        private static KnockoutBindingComplexItem CreateTimePickerComplexBindingItem<TModel>(Expression<Func<TModel, object>> expression, ITimePickerConfig config)
        {
            var complexBinding = new KnockoutBindingComplexItem { Name = "timepicker" };
            complexBinding.Add(new KnockoutBindingItem<TModel, object> { Name = "value", Expression = expression });
            complexBinding.Add(new KnockoutBindingStringItem("options", JsonConvert.SerializeObject(config), false));
            return complexBinding;
        }
    }
}
