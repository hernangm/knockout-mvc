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

        #region Form
        public static KnockoutFormBuilder<TModel> Form<TModel>(this KnockoutHtml<TModel> html)
        {
            return new KnockoutFormBuilder<TModel>(new KnockoutForm<TModel>(html.Context, null, null, html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases));
        }
        #endregion

        #region ValidationSummary
        public static KnockoutValidationSummary ValidationSummary<TModel>(this KnockoutHtml<TModel> html)
        {
            return new KnockoutValidationSummary();
        }
        #endregion

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

        #region NumericBoxFor
        public static KnockoutNumericBox<TModel> NumericBoxFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutNumericBox<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region DatePickerFor
        public static KnockoutDatePicker<TModel> DatePickerFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutDatePicker<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region TimePickerFor
        public static KnockoutTimePicker<TModel> TimePickerFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutTimePicker<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region CkeditorFor
        public static KnockoutCkeditor<TModel> CkeditorFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutCkeditor<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        #region Button
        public static KnockoutButton Button<TModel>(this KnockoutHtml<TModel> html, string label)
        {
            return new KnockoutButton() { Label = label };
        }

        public static KnockoutButton Button<TModel>(this KnockoutHtml<TModel> html, string label, PerpetuumSoft.Knockout.Html.KnockoutButton.ButtonType type)
        {
            return new KnockoutButton() { Label = label, Type = type };
        }
        #endregion

        #region SpanFor
        public static KnockoutSpan<TModel> SpanFor<TModel>(this KnockoutHtml<TModel> html, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutSpan<TModel>(html.Context, binding, GetMetaDataFor(binding), html.Context.CreateData().InstanceNames, html.Context.CreateData().Aliases);
        }
        #endregion

        private static IEnumerable<IPropertyConfig> GetMetaDataFor<TProperty, TItem>(Expression<Func<TProperty, TItem>> binding)
        {
            var ViewModelConfiguratorFactory = DependencyResolver.Current.GetService<IViewModelConfiguratorFactory>();
            var metadata = ViewModelConfiguratorFactory.GetViewModelConfigurator(typeof(TProperty));
            if (metadata != null)
            {
                var name = KnockoutExpressionConverter.Convert(binding, null);
                return metadata.CreateDescriptor().GetConfigsForMember(name).ToList();
            }
            return null;
        }

    }
}
