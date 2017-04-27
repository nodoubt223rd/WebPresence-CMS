using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace WebPresence.Core.DataAnnotations
{
    public class DataAnnotationsModelMetadataProviderExt : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata res = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            FormatAttribute formatAttribute = attributes.OfType<FormatAttribute>().FirstOrDefault();
            if (formatAttribute != null)
            {
                string clientFormat;
                string prefix;
                string postfix;
                formatAttribute.GetClientFormat(out prefix, out postfix, out clientFormat);
                res.AdditionalValues.Add("WebPresence.ClientFormatString", clientFormat);
                res.AdditionalValues.Add("WebPresence.ClientFormatPrefix", prefix);
                res.AdditionalValues.Add("WebPresence.ClientFormatPostfix", postfix);

            }
            if (res != null) res.AdditionalValues.Add("WebPresence.Attributes", attributes);
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            string name = null;
            if (display != null)
            {
                res.Description = display.GetDescription();
                res.ShortDisplayName = display.GetShortName();
                res.Watermark = display.GetPrompt();


                name = display.GetName();
                if (!string.IsNullOrWhiteSpace(name)) res.DisplayName = name;
            }
            return res;
        }

        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProviderExt(type).GetTypeDescriptor(type);
        }
    }
}
