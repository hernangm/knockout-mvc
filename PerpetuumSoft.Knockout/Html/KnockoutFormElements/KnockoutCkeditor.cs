using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutCkeditor<TModel> : KnockoutTextAreaBase<KnockoutCkeditor<TModel>, TModel>
    {
        public KnockoutCkeditor(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder)
        {
            tagBuilder.Ckeditor(Binding);
        }
    }

    public static class CkeditorKnockoutTagBuilderExtensions
    {
        public static KnockoutBinding<TModel> Ckeditor<TModel>(this KnockoutBinding<TModel> binding, Expression<Func<TModel, object>> expression)
        {
            binding.Items.Add(new KnockoutBindingItem<TModel, object> { Name = "ckeditor", Expression = expression });
            return binding;
        }
    }
}
