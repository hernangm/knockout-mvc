using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using eqip.metadata.Configurations;
using System.Web;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public enum FieldType
    {
        Input,
        TextArea,
        Select
    }

    public interface IField : IHtmlString
    {
        string GetId();
        FieldType Type { get; }

    }

    public interface IInput
    {
        InputType InputType { get; }
    }

    public abstract class KnockoutFieldBase<TType, TModel, TItem> : KnockoutHtmlTagBase<TType, TModel, TItem>, IField where TType : KnockoutFieldBase<TType, TModel, TItem>
    {

        #region Properties
        public FieldType Type { get; private set; }
        protected IEnumerable<IPropertyConfig> Metadata { get; set; }
        protected string Name { get; set; }
        protected KnockoutLabel Label { get; set; }
        protected bool IsValidatable { get; set; }
        protected bool ShowValidationMessage { get; set; }
        protected bool IsReadOnly { get; set; }
        private string Id { get; set; }
        #endregion

        #region Constructors
        public KnockoutFieldBase(KnockoutContext<TModel> context, FieldType type, Expression<Func<TModel, TItem>> binding, IEnumerable<IPropertyConfig> metadata = null, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(type.ToString().ToLowerInvariant(), context, binding, instancesNames, aliases)
        {
            //this.Type = type;
            this.Metadata = metadata;
            this.Label = new KnockoutLabel(this, metadata);
            this.Name = KnockoutExpressionConverter.Convert(Binding, null);
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
            this.Label.Text = label;
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

        protected override void ConfigureTagBuilder(KnockoutTagBuilder<TModel> tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            this.HtmlAttributes.Add("id", this.GetId());
        }

        public override string ToHtmlString()
        {
            var tagBuilder = GetTagBuilder();
            if (this.Label.MustShow)
            {
                if (this.Label.WrappingLabel)
                {
                    return string.Format(this.Label.ToHtmlString(), tagBuilder.ToHtmlString());
                }
                else
                {
                    return this.Label.ToHtmlString() + tagBuilder.ToHtmlString();
                }
            }
            else
            {
                return tagBuilder.ToHtmlString();
            }
        }



    }
}
