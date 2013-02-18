using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public abstract class KnockoutTextInputBase<TType, TModel> : KnockoutInputBase<TType, TModel> where TType : KnockoutTextInputBase<TType, TModel>
    {

        public KnockoutTextInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, inputType, binding, metadata, instancesNames, aliases)
        {
            if (inputType == InputType.CheckBox || inputType == InputType.Radio)
            {
                throw new ArgumentException("Input type can only be text, hidden or password.");
            }
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            Func<IPropertyConfig, bool> func = m => m.GetType().GetInterfaces().Any(p => p == typeof(IFormatConfig));
            if (this.Metadata != null && this.Metadata.Any(func))
            {
                var first = (IFormatConfig)this.Metadata.First(func);
                var propertyName = KnockoutExpressionConverter.Convert(Binding, null) + "." + first.Name;
                tagBuilder.Custom("value", propertyName, false);
            }
            else
            {
                base.ConfigureBinding(tagBuilder);
            }
        }
    }
}
