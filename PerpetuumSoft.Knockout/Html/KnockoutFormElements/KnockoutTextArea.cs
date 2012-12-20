using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutTextAreaBase<TType, TModel> : KnockoutFieldBase<TType, TModel> where TType : KnockoutTextAreaBase<TType, TModel>
    {
        #region Constructors
        public KnockoutTextAreaBase(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.TextArea, binding, instancesNames, aliases)
        {
        }
        #endregion

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Value(Binding);
        }
    }

    public class KnockoutTextArea<TModel> : KnockoutTextAreaBase<KnockoutTextArea<TModel>, TModel>
    {
        #region Constructors
        public KnockoutTextArea(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }
        #endregion
    }
}
