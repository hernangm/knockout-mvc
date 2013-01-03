using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutDropDownList<TModel> : KnockoutSelectBase<KnockoutDropDownList<TModel>, TModel, object>
    {
        public KnockoutDropDownList(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, metadata, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureBinding(tagBuilder);
            tagBuilder.Value(Binding);
        }
    }
}
