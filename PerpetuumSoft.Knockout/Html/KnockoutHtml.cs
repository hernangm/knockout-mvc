using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
  public class KnockoutHtml<TModel> : KnockoutSubContext<TModel>
  {
    private readonly ViewContext viewContext;

    public KnockoutHtml(ViewContext viewContext, KnockoutContext<TModel> context, string[] instancesNames = null, Dictionary<string, string> aliases = null)
      : base(context, instancesNames, aliases)
    {
      this.viewContext = viewContext;
    }

    //public KnockoutTagBuilder<TModel> Span(Expression<Func<TModel, object>> text, object htmlAttributes = null)
    //{
    //  var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "span", InstanceNames, Aliases);
    //  tagBuilder.ApplyAttributes(htmlAttributes);
    //  tagBuilder.Text(text);
    //  return tagBuilder;
    //}

    //public KnockoutTagBuilder<TModel> Span(string text, object htmlAttributes = null)
    //{
    //  var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "span", InstanceNames, Aliases);
    //  tagBuilder.ApplyAttributes(htmlAttributes);
    //  tagBuilder.SetInnerHtml(HttpUtility.HtmlEncode(text));
    //  return tagBuilder;
    //}

    //public KnockoutTagBuilder<TModel> SpanInline(string text, object htmlAttributes = null)
    //{
    //  var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "span", InstanceNames, Aliases);
    //  tagBuilder.ApplyAttributes(htmlAttributes);
    //  tagBuilder.Text(text);
    //  return tagBuilder;
    //}

    //public KnockoutTagBuilder<TModel> Button(string caption, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    //{
    //  var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "button", InstanceNames, Aliases);
    //  tagBuilder.ApplyAttributes(htmlAttributes);
    //  tagBuilder.Click(actionName, controllerName, routeValues);
    //  tagBuilder.SetInnerHtml(HttpUtility.HtmlEncode(caption));
    //  return tagBuilder;
    //}

    //public KnockoutTagBuilder<TModel> HyperlinkButton(string caption, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    //{
    //  var tagBuilder = new KnockoutTagBuilder<TModel>(Context, "a", InstanceNames, Aliases);
    //  tagBuilder.ApplyAttributes(htmlAttributes);
    //  tagBuilder.ApplyAttributes(new { href = "#" });
    //  tagBuilder.Click(actionName, controllerName, routeValues);
    //  tagBuilder.SetInnerHtml(HttpUtility.HtmlEncode(caption));
    //  return tagBuilder;
    //}    

    //public KnockoutFormContext<TModel> Form(string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    //{
    //  var formContext = new KnockoutFormContext<TModel>(
    //    viewContext, 
    //    Context, InstanceNames, Aliases, 
    //    actionName, controllerName, routeValues, htmlAttributes);
    //  formContext.WriteStart(viewContext.Writer);
    //  return formContext;
    //}    
  }
}