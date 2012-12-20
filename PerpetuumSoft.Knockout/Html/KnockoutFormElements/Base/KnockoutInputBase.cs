using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{

    public abstract class KnockoutInputBase<TType, TModel> : KnockoutFieldBase<TType, TModel> where TType : KnockoutInputBase<TType, TModel>
    {

        public InputType InputType { get; private set; }

        public KnockoutInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.Input, binding, instancesNames, aliases)
        {
            this.InputType = inputType;
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            tagBuilder.ApplyAttributes(new { type = this.InputType.ToString().ToLowerInvariant() });
        }

    }
}
