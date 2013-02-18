using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerpetuumSoft.Knockout.Html
{
    public class KnockoutFormValidationOptions
    {
        public class KnockoutFormValidationOptionsGroup
        {
            public bool deep { get; set; }
            public bool observable { get; set; }

            public KnockoutFormValidationOptionsGroup()
            {
                this.deep = false;
                this.observable = true;
            }
        }

        //Indicates whether <span> tags with the validation message will be inserted to the right of your <input> element
        public bool insertMessages { get; set; }
        //Indicates whether to assign an error class to the <input> tag when your property is invalid
        public bool decorateElement { get; set; }
        //The CSS class assigned to validation error messages
        public string errorMessageClass { get; set; }
        //The CSS class assigned to validation error <input> elements
        public string errorElementClass { get; set; }
        //If defined, the CSS class assigned to both <input> and validation message elements
        public string errorClass { get; set; }
        //Indicates whether to assign validation rules to your ViewModel using HTML5 validation attributes
        public bool parseInputAttributes { get; set; }
        //Indicates whether validation messages are triggered only when properties are modified or at all times
        public bool messagesOnModified { get; set; }
        //The id of the <script type="text/html"></script> that you want to use for all your validation messages
        public string messageTemplate { get; set; }
        //when using the group or validatedObservable functions, deep indicates whether to walk the ViewModel (or object) recursively, or only walk first-level properties. observable indicates whether the returned errors object is a ko.computed or a simple function
        public KnockoutFormValidationOptionsGroup grouping { get; set; }

        public KnockoutFormValidationOptions()
        {
            this.insertMessages = true;
            this.decorateElement = false;
            this.errorMessageClass = "validationMessage";
            this.errorElementClass = "validationElement";
            this.errorClass = null;
            this.parseInputAttributes = false;
            this.messagesOnModified = true;
            this.messageTemplate = null;
            this.grouping = new KnockoutFormValidationOptionsGroup();
        }
    }
}
