using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerpetuumSoft.Knockout.Html;
using eqip.metadata.Configurations;
using System.Linq.Expressions;
using System.Web.Mvc;
using eqip.metadata;
using System.Collections;

namespace PerpetuumSoft.Knockout
{
    public static class KnockoutHtmlExtensions
    {

        #region TextBoxFor
        public static KnockoutTextBox<TProperty> TextBoxFor<TProperty>(this KnockoutHtml<TProperty> html, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutTextBox<TProperty>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region PasswordFor
        public static KnockoutPassword<TProperty> PasswordFor<TProperty>(this KnockoutHtml<TProperty> html, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutPassword<TProperty>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region CheckboxFor
        public static KnockoutCheckBox<TProperty> CheckBoxFor<TProperty>(this KnockoutHtml<TProperty> html, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutCheckBox<TProperty>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region DropDownListFor
        public static KnockoutDropDownList<TModel> DropDownListFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutDropDownList<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region ListBoxFor
        public static KnockoutListBox<TModel> ListBoxFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, IEnumerable>> binding)
        {
            return new KnockoutListBox<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region CkeditorFor
        public static KnockoutCkeditor<TModel> CkeditorFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutCkeditor<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        private static IEnumerable<IPropertyConfig> GetMetaDataFor<TProperty, TItem>(Expression<Func<TProperty, TItem>> binding)
        {
            var ViewModelConfiguratorFactory = DependencyResolver.Current.GetService<IViewModelConfiguratorFactory>();
            var metadata = ViewModelConfiguratorFactory.GetViewModelConfigurator(typeof(TProperty));
            if (metadata != null)
            {
                var name = KnockoutExpressionConverter.Convert(binding, null);
                return metadata.CreateDescriptor().GetConfigsForMember(name);
            }
            return null;
        }

    }
}
