using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace PerpetuumSoft.Knockout
{
    public interface IKnockoutContext
    {
        string GetInstanceName();
        string GetIndex();
    }

    public class KnockoutContext<TModel> : IKnockoutContext
    {
        protected TModel model;

        public TModel Model
        {
            get
            {
                return model;
            }
        }

        protected List<IKnockoutContext> ContextStack { get; set; }

        public KnockoutContext(ViewContext viewContext)
        {
            this.ViewContext = viewContext;
            ContextStack = new List<IKnockoutContext>() { this };
        }

        public ViewContext ViewContext { get; private set; }

        private int ActiveSubcontextCount
        {
            get
            {
                return ContextStack.Count - 1 - ContextStack.IndexOf(this);
            }
        }

        public KnockoutContext<TParent> Parent<TParent>(Expression<Func<TModel, TParent>> parent)
        {
            return (KnockoutContext<TParent>)ContextStack[ContextStack.IndexOf(this) - 1];
        }

        public KnockoutForeachContext<TItem> Foreach<TItem>(Expression<Func<TModel, IList<TItem>>> binding)
        {
            var expression = KnockoutExpressionConverter.Convert(binding, CreateData());
            var regionContext = new KnockoutForeachContext<TItem>(ViewContext, expression);
            regionContext.WriteStart(ViewContext.Writer);
            regionContext.ContextStack = ContextStack;
            ContextStack.Add(regionContext);
            return regionContext;
        }

        public KnockoutWithContext<TItem> With<TItem>(Expression<Func<TModel, TItem>> binding)
        {
            Func<TModel, TItem> func = binding.Compile();
            var model = (TItem)func((TModel)ViewContext.ViewData.Model);
            var expression = KnockoutExpressionConverter.Convert(binding, CreateData());
            var regionContext = new KnockoutWithContext<TItem>(ViewContext, expression, model);
            regionContext.WriteStart(ViewContext.Writer);
            regionContext.ContextStack = ContextStack;
            ContextStack.Add(regionContext);
            return regionContext;
        }

        public KnockoutIfContext<TModel> If(Expression<Func<TModel, bool>> binding)
        {
            var regionContext = new KnockoutIfContext<TModel>(ViewContext, KnockoutExpressionConverter.Convert(binding));
            regionContext.InStack = false;
            regionContext.WriteStart(ViewContext.Writer);
            return regionContext;
        }

        public string GetInstanceName()
        {
            switch (ActiveSubcontextCount)
            {
                case 0:
                    return "";
                case 1:
                    return "$parent";
                default:
                    return "$parents[" + (ActiveSubcontextCount - 1) + "]";
            }
        }

        private string GetContextPrefix()
        {
            var sb = new StringBuilder();
            int count = ActiveSubcontextCount;
            for (int i = 0; i < count; i++)
                sb.Append("$parentContext.");
            return sb.ToString();
        }

        public string GetIndex()
        {
            return GetContextPrefix() + "$index()";
        }

        public virtual KnockoutExpressionData CreateData()
        {
            return new KnockoutExpressionData { InstanceNames = new[] { GetInstanceName() } };
        }

        public virtual KnockoutBinding<TModel> Bind
        {
            get
            {
                return new KnockoutBinding<TModel>(this, CreateData().InstanceNames, CreateData().Aliases);
            }
        }

        public virtual KnockoutHtml<TModel> Html
        {
            get
            {
                return new KnockoutHtml<TModel>(ViewContext, this, CreateData().InstanceNames, CreateData().Aliases);
            }
        }
    }
}
