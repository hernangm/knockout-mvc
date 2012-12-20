using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutCheckBox<TModel> : KnockoutCheckedInputBase<KnockoutCheckBox<TModel>, TModel>
    {
        public KnockoutCheckBox(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.CheckBox, binding, instancesNames, aliases)
        {
        }
    }
}