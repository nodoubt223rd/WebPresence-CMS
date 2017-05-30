using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebPresence.Core.DataAnnotations
{
    public class RangeAdapter : DataAnnotationsModelValidator<RangeAttribute>
    {
        public RangeAdapter(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            string errorMessage = ErrorMessage;
            object father = null;

            if (Metadata.AdditionalValues.ContainsKey("WebPresence.Parent"))
            {
                father = Metadata.AdditionalValues["WebPresence.Parent"];
            }

            var rule = new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = Metadata.ModelType == typeof(DateTime) ? "daterange" : "dynamicrange"
            };

            rule.ValidationParameters.Add("min", Attribute.Minimum);
            rule.ValidationParameters.Add("max", Attribute.Maximum);

            return new[] { rule };
        }
    }
}
