using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public abstract class KnockoutTextInputBase<TType, TModel> : KnockoutInputBase<TType, TModel> where TType : KnockoutTextInputBase<TType, TModel>
    {

        public KnockoutTextInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, inputType, binding, instancesNames, aliases)
        {
            if (inputType == InputType.CheckBox || inputType == InputType.Radio)
            {
                throw new ArgumentException("Input type can only be text, hidden or password.");
            }
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureBinding(tagBuilder);
            tagBuilder.Value(Binding);
        }
    }
}
