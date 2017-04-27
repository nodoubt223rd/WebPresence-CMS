using System;
using System.ComponentModel;

namespace WebPresence.Core.DataAnnotations
{
    public class AssociatedMetadataTypeTypeDescriptionProviderExt : TypeDescriptionProvider
    {
        private Type _associatedMetadataType;

        public AssociatedMetadataTypeTypeDescriptionProviderExt(Type x)
            : base(TypeDescriptor.GetProvider(x))
        {
        }

        public AssociatedMetadataTypeTypeDescriptionProviderExt(Type x, Type y)
            : this(x)
        {
            _associatedMetadataType = y ?? throw new ArgumentNullException("associatedMetadataType");
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor typeDescriptor = base.GetTypeDescriptor(objectType, instance);

            return new AssociatedMetadataTypeTypeDescriptor(typeDescriptor, objectType, _associatedMetadataType);
        }

    }
}
