using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using eqip.core.utils;
using System.Linq.Expressions;

namespace PerpetuumSoft.Knockout.Html
{
    public abstract class KnockoutHtmlTagBase<TType, TModel, TItem> : KnockoutBinding<TModel>, IHtmlString where TType : KnockoutHtmlTagBase<TType, TModel, TItem>
    {
        #region "Properties"
        protected IDictionary<string, object> HtmlAttributes { get; set; }
        protected Expression<Func<TModel, TItem>> Binding { get; set; }
        #endregion

        public KnockoutHtmlTagBase(KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, instancesNames, aliases)
        {
            this.HtmlAttributes = new Dictionary<string, object>();
            this.Binding = binding;
        }

        #region Abstract Methods
        protected abstract void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder);
        #endregion

        public TType Attributes(object htmlAttributes)
        {
            this.HtmlAttributes.Merge(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return (TType)this;
        }

        public TType AddClass(string @class)
        {
            if (!string.IsNullOrWhiteSpace(@class))
            {
                if (!this.HtmlAttributes.ContainsKey("class"))
                {
                    this.HtmlAttributes["class"] = @class.Trim();
                }
                else
                {
                    var classes = ((string)this.HtmlAttributes["class"]).Split(' ').ToList();
                    if (!classes.Any(a => a.Equals(@class, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        classes.Add(@class.Trim());
                        this.HtmlAttributes["class"] = string.Join(" ", classes.ToArray());
                    }
                }
            }
            return (TType)this;
        }

        public abstract override string ToHtmlString();

        public override string ToString()
        {
            return this.ToHtmlString();
        }


    }
}
