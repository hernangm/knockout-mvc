using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutSpan<TModel> : KnockoutHtmlTagBase<KnockoutSpan<TModel>, TModel, object>
    {

        public KnockoutSpan(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("span", context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Text(Binding);
        }

        public override string ToHtmlString()
        {
            return GetTagBuilder().ToHtmlString();
        }

        protected override void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder)
        {
        
        }
    }
}
