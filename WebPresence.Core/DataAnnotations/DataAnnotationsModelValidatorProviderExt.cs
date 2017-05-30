using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebPresence.Core.DataAnnotations
{
    public class DataAnnotationsModelValidatorProviderExt : DataAnnotationsModelValidatorProvider
    {
        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProviderExt(type).GetTypeDescriptor(type);
        }
    }
}
