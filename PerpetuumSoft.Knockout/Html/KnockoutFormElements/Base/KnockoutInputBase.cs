using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{

    public abstract class KnockoutInputBase<TType, TModel> : KnockoutFieldBase<TType, TModel, object>, IInput where TType : KnockoutInputBase<TType, TModel>
    {

        public InputType InputType { get; private set; }

        public KnockoutInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.Input, binding, metadata, instancesNames, aliases)
        {
            this.InputType = inputType;
        }

        protected override void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            this.HtmlAttributes.Add("type", this.InputType.ToString().ToLowerInvariant());
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Value(Binding);
        }

    }
}
