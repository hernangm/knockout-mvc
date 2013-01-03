using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutRadioButton<TModel> : KnockoutCheckedInputBase<KnockoutRadioButton<TModel>, TModel>
    {
        public KnockoutRadioButton(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, List<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Radio, binding, metadata, instancesNames, aliases)
        {
        }
    }
}