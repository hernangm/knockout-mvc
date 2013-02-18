using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using eqip.metadata.Configurations;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutLabel : IHtmlString
    {
        private IField Field { get; set; }
        public string Text { get; set; }
        private IEnumerable<IPropertyConfig> Metadata { get; set; }

        public KnockoutLabel(IField field, IEnumerable<IPropertyConfig> metadata = null)
        {
            this.Field = field;
            this.Metadata = metadata;
        }

        public bool WrappingLabel
        {
            get
            {
                var input = Field as IInput;
                if (input != null)
                {
                    return input.InputType == InputType.CheckBox || input.InputType == InputType.Radio;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool MustShow { get { return !string.IsNullOrWhiteSpace(this.Text); } }

        public string ToHtmlString()
        {
            var labelPattern = @"<label for=""{0}"">{1}</label>";
            if (this.WrappingLabel)
            {
                return string.Format(labelPattern, Field.GetId(), "{0}" + GetLabelText());
            }
            else
            {
                return string.Format(labelPattern, Field.GetId(), GetLabelText());
            }
        }

        private string GetLabelText()
        {
            if (Metadata != null)
            {
                var metadataLabel = Metadata.FirstOrDefault(m => m.GetType() == typeof(LabelConfig)) as LabelConfig;
                if (metadataLabel != null)
                {
                    return metadataLabel.ResourceKey;
                }
            }
            return this.Text;
        }

    }
}
