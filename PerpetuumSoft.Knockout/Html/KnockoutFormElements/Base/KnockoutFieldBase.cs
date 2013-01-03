using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using eqip.metadata.Configurations;

namespace PerpetuumSoft.Knockout.Html
{
    public interface IField
    {
        string GetId();
        bool WrappingLabel();
    }

    public abstract class KnockoutFieldBase<TType, TModel, TItem> : KnockoutHtmlTagBase<TType, TModel, TItem>, IField where TType : KnockoutFieldBase<TType, TModel, TItem>
    {
        public enum FieldType
        {
            Input,
            TextArea,
            Select
        }

        #region Properties
        private readonly string labelPattern = @"<label for=""{0}"">{1}</label>{2}";
        private FieldType Type { get; set; }
        protected IEnumerable<IPropertyConfig> Metadata { get; set; }
        protected string Name { get; set; }
        protected string Label { get; set; }
        protected bool IsValidatable { get; set; }
        protected bool ShowValidationMessage { get; set; }
        protected bool IsReadOnly { get; set; }
        private string Id { get; set; }
        #endregion

        #region Constructors
        public KnockoutFieldBase(KnockoutContext<TModel> context, FieldType type, Expression<Func<TModel, TItem>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
            this.Type = type;
            this.Metadata = metadata;
            this.Name = KnockoutExpressionConverter.Convert(Binding, null);
        }
        #endregion

        #region Abstract Methods
        public virtual bool WrappingLabel()
        {
            return false;
        }
        #endregion

        #region Methods
        public string GetId()
        {
            return !string.IsNullOrEmpty(Id) ? Id : Name;
        }
        #endregion

        #region Fluent Methods
        public TType WithLabel()
        {
            return (TType)this.WithLabel(Name);
        }

        public TType WithLabel(string label)
        {
            this.Label = label;
            return (TType)this;
        }

        public TType WithId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("parametro id no puede ser nulo o vacio.");
            }
            this.Id = id;
            return (TType)this;
        }
        #endregion

        public override string ToHtmlString()
        {
            var tagBuilder = new KnockoutTagBuilder<TModel>(Context, this.Type.ToString().ToLowerInvariant(), InstanceNames, Aliases);
            this.HtmlAttributes.Add("id", this.GetId());
            tagBuilder.ApplyAttributes(this.HtmlAttributes);
            this.ConfigureBinding(tagBuilder);
            if (!string.IsNullOrWhiteSpace(this.Label))
            {
                if (this.WrappingLabel())
                {
                    return string.Format(labelPattern, this.GetId(), tagBuilder.ToHtmlString() + this.Label, string.Empty);
                }
                else
                {
                    return string.Format(labelPattern, this.GetId(), this.Label, tagBuilder.ToHtmlString());
                }
            }
            return tagBuilder.ToHtmlString();
        }

    }
}
