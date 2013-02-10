using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{

    public abstract class KnockoutCheckedInputBase<TType, TModel> : KnockoutInputBase<TType, TModel> where TType : KnockoutCheckedInputBase<TType, TModel>
    {

        public KnockoutCheckedInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, inputType, binding, metadata, instancesNames, aliases)
        {
            if (!(inputType == InputType.CheckBox || inputType == InputType.Radio))
            {
                throw new ArgumentException("Input type can only be checkable.");
            }
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Checked(Binding);
        }


    }
}
