using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using Newtonsoft.Json;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutNumericBox<TModel> : KnockoutTextBox<TModel>
    {
        public KnockoutNumericBox(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, metadata, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (this.Metadata != null)
            {
                var metadata = (INumericConfig)this.Metadata.FirstOrDefault(m => m.GetType().GetInterfaces().Any(p => p == typeof(INumericConfig)));
                if (metadata != null)
                {
                    tagBuilder.Numeric(Binding, metadata);
                }
                else
                {
                    tagBuilder.Numeric(Binding);
                }
            }
            else
            {
                tagBuilder.Numeric(Binding);
            }
            
        }
    }

    public static class NumericKnockoutTagBuilderExtensions
    {
        public static KnockoutBinding<TModel> Numeric<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression)
        {
            binding.Items.Add(CreateNumericComplexBindingItem(expression, null));
            return binding;
        }

        public static KnockoutBinding<TModel> Numeric<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression, INumericConfig config)
        {
            binding.Items.Add(CreateNumericComplexBindingItem(expression, config));
            return binding;
        }

        private static KnockoutBindingComplexItem CreateNumericComplexBindingItem<TModel>(Expression<Func<TModel, object>> expression, INumericConfig config)
        {
            var complexBinding = new KnockoutBindingComplexItem { Name = "numeric" };
            complexBinding.Add(new KnockoutBindingItem<TModel, object> { Name = "value", Expression = expression });
            complexBinding.Add(new KnockoutBindingStringItem("options", JsonConvert.SerializeObject(config), false));
            return complexBinding;
        }
    }
}
