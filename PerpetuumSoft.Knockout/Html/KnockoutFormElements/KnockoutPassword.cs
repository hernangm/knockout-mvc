using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutPassword<TModel> : KnockoutInputBase<KnockoutPassword<TModel>, TModel>
    {
        public KnockoutPassword(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Password, binding, metadata, instancesNames, aliases)
        {
        }
    }
}
