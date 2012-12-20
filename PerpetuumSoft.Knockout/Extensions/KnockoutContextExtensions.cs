using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;
using PerpetuumSoft.Knockout.Html;

namespace PerpetuumSoft.Knockout
{
    public static class KnockoutContextInputExtensions
    {
        #region ApplyBindings
        public static KnockoutBindingApplier ApplyBindings<TProperty>(this KnockoutContext<TProperty> context)
        {
            return new KnockoutBindingApplier(context.ViewContext);
        }
        #endregion

        #region TextBoxFor
        public static KnockoutTextBox<TProperty> TextBoxFor<TProperty>(this KnockoutContext<TProperty> context, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutTextBox<TProperty>(context, binding, context.CreateData().InstanceNames, context.CreateData().Aliases);
        }
        #endregion

        #region PasswordFor
        public static KnockoutPassword<TProperty> PasswordFor<TProperty>(this KnockoutContext<TProperty> context, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutPassword<TProperty>(context, binding, context.CreateData().InstanceNames, context.CreateData().Aliases);
        }
        #endregion

        #region CheckboxFor
        public static KnockoutCheckBox<TProperty> CheckBoxFor<TProperty>(this KnockoutContext<TProperty> context, Expression<Func<TProperty, object>> binding)
        {
            return new KnockoutCheckBox<TProperty>(context, binding, context.CreateData().InstanceNames, context.CreateData().Aliases);
        }
        #endregion

        #region CkeditorFor
        public static KnockoutCkeditor<TModel> CkeditorFor<TModel>(this KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding)
        {
            return new KnockoutCkeditor<TModel>(context, binding, context.CreateData().InstanceNames, context.CreateData().Aliases);
        }
        #endregion
    }
}
