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
    public abstract class KnockoutHtmlTagBase<TType> : IHtmlString where TType : KnockoutHtmlTagBase<TType>
    {
        #region "Properties"
        protected IDictionary<string, object> HtmlAttributes { get; set; }
        #endregion


        public KnockoutHtmlTagBase()
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

        public abstract string ToHtmlString();

        public override string ToString()
        {
            return this.ToHtmlString();
        }

    }


    public abstract class KnockoutHtmlTagBase<TType, TModel, TItem> : KnockoutHtmlTagBase<TType> where TType : KnockoutHtmlTagBase<TType, TModel, TItem>
    {
        #region "Properties"
        private string TagName { get; set; }
        protected Expression<Func<TModel, TItem>> Binding { get; set; }
        protected KnockoutContext<TModel> Context { get; set; }
        protected string[] InstanceNames { get; set; }
        protected Dictionary<string, string> Aliases { get; set; }
        #endregion

        public KnockoutHtmlTagBase(string tagName, KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
        {
            this.TagName = tagName;
            this.Context = context;
            this.InstanceNames = instancesNames;
            this.Aliases = aliases;
            this.Binding = binding;
        }

        protected KnockoutTagBuilder<TModel> GetTagBuilder()
        {
            var tagBuilder = new KnockoutTagBuilder<TModel>(Context, this.TagName, InstanceNames, Aliases);
            ConfigureTagBuilder(tagBuilder);
            ConfigureBinding(tagBuilder);
            tagBuilder.ApplyAttributes(this.HtmlAttributes);
            return tagBuilder;
        }

        #region Abstract Methods
        protected abstract void ConfigureBinding(KnockoutTagBuilder<TModel> tagBuilder);
        protected abstract void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder);
        #endregion



    }
}
