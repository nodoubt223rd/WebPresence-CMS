using System;
using System.ComponentModel;
using System.Linq;

namespace WebPresence.Core.DataAnnotations
{
    class MetadataPropertyDescriptorWrapper : PropertyDescriptor
    {
        private PropertyDescriptor _descriptor;
        private bool _isReadOnly;
        public override Type ComponentType
        {
            get
            {
                return _descriptor.ComponentType;
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return _isReadOnly || this._descriptor.IsReadOnly;
            }
        }
        public override Type PropertyType
        {
            get
            {
                return _descriptor.PropertyType;
            }
        }
        public override bool SupportsChangeEvents
        {
            get
            {
                return _descriptor.SupportsChangeEvents;
            }
        }
        public MetadataPropertyDescriptorWrapper(PropertyDescriptor descriptor, Attribute[] newAttributes)
            : base(descriptor, newAttributes)
        {
            _descriptor = descriptor;

            ReadOnlyAttribute readOnlyAttribute = newAttributes.OfType<ReadOnlyAttribute>().FirstOrDefault<ReadOnlyAttribute>();
            _isReadOnly = (readOnlyAttribute != null && readOnlyAttribute.IsReadOnly);
        }
        public override void AddValueChanged(object component, EventHandler handler)
        {
            _descriptor.AddValueChanged(component, handler);
        }
        public override bool CanResetValue(object component)
        {
            return _descriptor.CanResetValue(component);
        }
        public override object GetValue(object component)
        {
            return _descriptor.GetValue(component);
        }
        public override void RemoveValueChanged(object component, EventHandler handler)
        {
            _descriptor.RemoveValueChanged(component, handler);
        }
        public override void ResetValue(object component)
        {
            _descriptor.ResetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            _descriptor.SetValue(component, value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return _descriptor.ShouldSerializeValue(component);
        }
    }
}
