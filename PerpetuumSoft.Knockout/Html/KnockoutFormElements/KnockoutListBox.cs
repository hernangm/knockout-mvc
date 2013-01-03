using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using System.Collections;

namespace PerpetuumSoft.Knockout.Html
{

    public class KnockoutListBox<TModel> : KnockoutSelectBase<KnockoutListBox<TModel>, TModel, IEnumerable>
    {

        public KnockoutListBox(KnockoutContext<TModel> context, Expression<Func<TModel, IEnumerable>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, metadata, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureBinding(tagBuilder);
            tagBuilder.ApplyAttributes(new { multiple = "multiple" });
            tagBuilder.SelectedOptions(Binding);
        }

    }
}
