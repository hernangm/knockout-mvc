using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerpetuumSoft.Knockout.Html;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
    public static class KnockoutFormBuilderExtensions
    {

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder)
        {
            return formBuilder.Action(null, null, null, null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName)
        {
            return formBuilder.Action(actionName, null, null, null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, object routeValues)
        {
            return formBuilder.Action(actionName, null, new RouteValueDictionary(routeValues), null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, RouteValueDictionary routeValues)
        {
            return formBuilder.Action(actionName, null, routeValues, null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, string controllerName)
        {
            return formBuilder.Action(actionName, controllerName, null, null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, string controllerName, object routeValues)
        {
            return formBuilder.Action(actionName, controllerName, new RouteValueDictionary(routeValues), null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return formBuilder.Action(actionName, controllerName, routeValues, null, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, string controllerName, object routeValues, string protocol)
        {
            return formBuilder.Action(actionName, controllerName, new RouteValueDictionary(routeValues), protocol, null);
        }

        public static KnockoutFormBuilder<TModel> Action<TModel>(this KnockoutFormBuilder<TModel> formBuilder, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            return formBuilder.SetAction(urlHelper.Action(actionName, controllerName, routeValues, protocol, hostName));
        }

    }
}
