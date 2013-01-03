using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;
using PerpetuumSoft.Knockout.Html;
using eqip.metadata;
using eqip.metadata.Configurations;
using System.Collections;

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
    }
}
