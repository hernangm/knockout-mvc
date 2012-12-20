using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using eqip.core.utils;

namespace PerpetuumSoft.Knockout.Html
{
    public abstract class KnockoutHtmlTagBase<TType, TModel> : KnockoutBinding<TModel>, IHtmlString where TType : KnockoutHtmlTagBase<TType, TModel>
    {
        #region "Properties"
        protected IDictionary<string, object> HtmlAttributes { get; set; }
        #endregion

        public KnockoutHtmlTagBase(KnockoutContext<TModel> context, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, instancesNames, aliases)
        {
            this.HtmlAttributes = new Dictionary<string, object>();
        }


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
