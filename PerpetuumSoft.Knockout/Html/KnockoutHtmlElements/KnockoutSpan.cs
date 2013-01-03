using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html.KnockoutHtmlElements
{
    public class KnockoutSpan<TModel> : KnockoutHtmlTagBase<KnockoutSpan<TModel>,TModel>
    {
        
        public KnockoutSpan(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Text(Binding);
        }

    }
}
