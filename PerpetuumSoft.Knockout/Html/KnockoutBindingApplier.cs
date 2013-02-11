using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web;
using eqip.core.utils;
using System.Text.RegularExpressions;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutBindingApplier : IHtmlString
    {
        private static string wrapper = "<script type=\"text/javascript\">{0}</script>";
        private static string patron = "var {0} = new {1}({2}); ko.applyBindings({0}{3});";
        private static string later = "$(function() {{ {0} }})</script>";
        private ViewContext ViewContext { get; set; }
        public object Model { get; private set; }
        private string _VariableName { get; set; }
        private string _To { get; set; }
        private string _Scope { get; set; }
        private List<object> _AdditionalParameters { get; set; }
        private bool _Later { get; set; }

        public KnockoutBindingApplier(ViewContext context)
        {

            this.ViewContext = context;
            this.Model = this.ViewContext.ViewData.Model;
            this._AdditionalParameters = new List<object>();
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// Name of the variable where the binded object will be set
        /// </summary>
        public KnockoutBindingApplier WithModel(object model)
        {
            this.Model = model;
            return this;
        }

        /// <summary>
        /// Name of the variable where the binded object will be set
        /// </summary>
        public KnockoutBindingApplier VariableName(string variableName)
        {
            this._VariableName = variableName;
            return this;
        }

        /// <summary>
        /// Name of the function to be called
        /// </summary>
        public KnockoutBindingApplier To(string function)
        {
            this._To = function;
            return this;
        }

        public KnockoutBindingApplier InScope(string scope)
        {
            this._Scope = scope;
            return this;
        }

        public KnockoutBindingApplier AddParameter(params object[] parameters)
        {
            this._AdditionalParameters.AddRange(parameters);
            return this;
        }

        public KnockoutBindingApplier Later()
        {
            this._Later = true;
            return this;
        }

        public string ToHtmlString()
        {
            var encodedArguments = new List<string>();
            if (this.Model != null)
            {
                encodedArguments.Add(Serialize(this.Model));
            }
            foreach (var arg in this._AdditionalParameters)
            {
                encodedArguments.Add(Serialize(arg));
            }
            var var = patron.FormatWith(GetVariableName(), GetFunction(), string.Join(",", encodedArguments.ToArray()), GetScope());
            var = this._Later ? later.FormatWith(var) : var;
            return MvcHtmlString.Create(wrapper.FormatWith(var)).ToString();
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }

        private string GetFunction()
        {
            return !string.IsNullOrEmpty(this._To) ? _To : Regex.Replace(this.Model.GetType().Name, "ViewModel$", "");
        }

        private string GetVariableName()
        {
            return !string.IsNullOrEmpty(this._VariableName) ? _VariableName : "ko_object_{0}".FormatWith(new Random().Next(10000));
        }

        private string GetScope()
        {
            return !string.IsNullOrEmpty(this._Scope) ? ",document.getElementById('{0}')".FormatWith(this._Scope) : string.Empty;
        }
    }


}
