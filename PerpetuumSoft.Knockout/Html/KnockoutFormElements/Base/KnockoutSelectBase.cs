using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;
using eqip.metadata.Configurations;
using eqip.core.utils;

namespace PerpetuumSoft.Knockout.Html
{
    public abstract class KnockoutSelectBase<TType, TModel, TItem> : KnockoutFieldBase<TType, TModel, TItem> where TType : KnockoutSelectBase<TType, TModel,TItem>
    {
        protected Expression<Func<TModel, IEnumerable<TItem>>> SelectOptions { get; set; }
        protected Expression<Func<object, object>> SelectOptionsText { get; set; }

        public KnockoutSelectBase(KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.Select, binding, metadata, instancesNames, aliases)
        {
        }


        public TType WithOptions(Expression<Func<TModel, IEnumerable<TItem>>> options)
        {
            this.SelectOptions = options;
            return (TType)this;
        }


        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            if (this.Metadata != null)
            {
                var first = (IListSourceConfig)this.Metadata.FirstOrDefault(m => m.GetType().GetInterfaces().Any(p => p == typeof(IListSourceConfig)));
                if (first != null)
                {
                    var propertyName = KnockoutExpressionConverter.Convert(Binding, null);
                    propertyName += "." + first.Name;
                    tagBuilder.Custom("options", propertyName, false);
                    tagBuilder.OptionsText(first.OptionsText, true);
                    tagBuilder.OptionsValue(first.OptionsValue, true);
                }
            }
            else
            {
                if (SelectOptions != null)
                {
                    tagBuilder.Options(Expression.Lambda<Func<TModel, IEnumerable>>(SelectOptions.Body, SelectOptions.Parameters));
                }
                if (SelectOptionsText != null)
                {
                    var data = new KnockoutExpressionData { InstanceNames = new[] { "item" } };
                    tagBuilder.OptionsText("function(item) { return " + KnockoutExpressionConverter.Convert(SelectOptions, data) + "; }");
                }
            }
        }
    }
}
