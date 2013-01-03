using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutTextAreaBase<TType, TModel> : KnockoutFieldBase<TType, TModel, object> where TType : KnockoutTextAreaBase<TType, TModel>
    {
        #region Constructors
        public KnockoutTextAreaBase(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metatada = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.TextArea, binding, metatada, instancesNames, aliases)
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
        public KnockoutTextArea(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, List<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, metadata, instancesNames, aliases)
        {
        }
        #endregion
    }
}
