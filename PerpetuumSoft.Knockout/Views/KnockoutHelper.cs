using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace PerpetuumSoft.Knockout.Views
{
    public class KnockoutHelper<TModel>
    {
        private ViewDataDictionary ViewData { get; set; }
        private HtmlHelper<TModel> Helper { get; set; }
        private KnockoutContext<TModel> _CurrentContext { get; set; }

        public KnockoutHelper(HtmlHelper<TModel> helper, IViewDataContainer viewDataContainer)
            : this(helper, viewDataContainer, RouteTable.Routes)
        {
        }

        public KnockoutHelper(HtmlHelper<TModel> helper, IViewDataContainer container, RouteCollection routeCollection)
        {
            this.Helper = helper;
            ViewData = new ViewDataDictionary<TModel>(container.ViewData);
        }

        public void RenderPartial<TItem>(string partialViewName, KnockoutCommonRegionContext<TItem> context)
        {

            var key = string.Format("ko_context_{0}", string.Concat(context.Keyword, context.StackId, partialViewName));
            if (!this.ViewData.ContainsKey(key))
            {
                this.ViewData["ko_key"] = key;
                this.ViewData.Add(key, context);
            }

            this.Helper.RenderPartial(partialViewName, context.Model, ViewData);
        }

        public KnockoutContext<TModel> CurrentContext
        {
            get
            {
                if (this._CurrentContext == null)
                {
                    if (this.Helper.ViewData.ContainsKey("ko_key"))
                    {
                        this._CurrentContext = (KnockoutContext<TModel>)this.Helper.ViewData[this.Helper.ViewData["ko_key"].ToString()];
                    }
                    else
                    {
                        this._CurrentContext = new KnockoutContext<TModel>(this.Helper.ViewContext);
                    }
                }
                return this._CurrentContext;
            }
        }
    }

}
