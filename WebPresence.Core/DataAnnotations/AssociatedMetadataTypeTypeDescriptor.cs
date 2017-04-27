using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebPresence.Core.DataAnnotations
{
    internal class AssociatedMetadataTypeTypeDescriptor : CustomTypeDescriptor
    {
        private Type AssociatedMetadataType
        {
            get;
            set;
        }

        public AssociatedMetadataTypeTypeDescriptor(ICustomTypeDescriptor parent, Type type, Type associatedMetadataType)
            : base(parent)
        {
            AssociatedMetadataType = (associatedMetadataType ?? TypeDescriptorCache.GetAssociatedMetadataType(type));

            if (AssociatedMetadataType != null)
            {
                TypeDescriptorCache.ValidateMetadataType(type, this.AssociatedMetadataType);
            }
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return this.GetPropertiesWithMetadata(base.GetProperties(attributes));
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetPropertiesWithMetadata(base.GetProperties());
        }
        public override AttributeCollection GetAttributes()
        {
            AttributeCollection attributeCollection = base.GetAttributes();
            if (this.AssociatedMetadataType != null)
            {
                Attribute[] newAttributes = TypeDescriptor.GetAttributes(this.AssociatedMetadataType).OfType<Attribute>().ToArray<Attribute>();
                attributeCollection = AttributeCollection.FromExisting(attributeCollection, newAttributes);
            }
            return attributeCollection;
        }
        private PropertyDescriptorCollection GetPropertiesWithMetadata(PropertyDescriptorCollection originalCollection)
        {
            if (this.AssociatedMetadataType == null)
            {
                return originalCollection;
            }
            bool flag = false;
            List<PropertyDescriptor> list = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor propertyDescriptor in originalCollection)
            {
                Attribute[] associatedMetadata = TypeDescriptorCache.GetAssociatedMetadata(this.AssociatedMetadataType, propertyDescriptor.Name);
                PropertyDescriptor item = propertyDescriptor;
                if (associatedMetadata.Length > 0)
                {
                    item = new MetadataPropertyDescriptorWrapper(propertyDescriptor, associatedMetadata);
                    flag = true;
                }
                list.Add(item);
            }
            if (flag)
            {
                return new PropertyDescriptorCollection(list.ToArray(), true);
            }
            return originalCollection;
        }
    }
}
