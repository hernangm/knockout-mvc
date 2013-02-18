using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutTooltip<TModel, TItem> : KnockoutHtmlTagBase<KnockoutTooltip<TModel, TItem>, TModel, TItem>
    {
        public KnockoutTooltip(KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("div", context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            var propertyName = KnockoutExpressionConverter.Convert(Binding, null) + "." + "tooltip";
            tagBuilder.Tooltip(propertyName);
        }

        public override string ToHtmlString()
        {
            return GetTagBuilder().ToHtmlString();
        }

        protected override void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder)
        {
            this.AddClass("tooltip");
        }

    }

    public static class TooltipKnockoutTagBuilderExtensions
    {
        public static KnockoutBinding<TModel> Tooltip<TModel>(this KnockoutBinding<TModel> binding, string property)
        {
            binding.Items.Add(new KnockoutBindingStringItem("tooltip", property, false));
            return binding;
        }
    }
}
