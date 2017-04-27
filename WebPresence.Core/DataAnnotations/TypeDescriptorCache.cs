using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace WebPresence.Core.DataAnnotations
{
    internal static class TypeDescriptorCache
    {
        private static readonly Attribute[] emptyAttributes = new Attribute[0];
        private static readonly ConcurrentDictionary<Type, Type> _metadataTypeCache = new ConcurrentDictionary<Type, Type>();
        private static readonly ConcurrentDictionary<Tuple<Type, string>, Attribute[]> _typeMemberCache = new ConcurrentDictionary<Tuple<Type, string>, Attribute[]>();
        private static readonly ConcurrentDictionary<Tuple<Type, Type>, bool> _validatedMetadataTypeCache = new ConcurrentDictionary<Tuple<Type, Type>, bool>();

        public static void ValidateMetadataType(Type type, Type associatedType)
        {
            Tuple<Type, Type> key = new Tuple<Type, Type>(type, associatedType);

            if (!_validatedMetadataTypeCache.ContainsKey(key))
            {
                CheckAssociatedMetadataType(type, associatedType);
                _validatedMetadataTypeCache.TryAdd(key, true);
            }
        }

        public static Type GetAssociatedMetadataType(Type type)
        {
            Type type2 = null;
            if (_metadataTypeCache.TryGetValue(type, out type2))
            {
                return type2;
            }

            MetadataTypeAttribute metadataTypeAttribute = (MetadataTypeAttribute)Attribute.GetCustomAttribute(type, typeof(MetadataTypeAttribute));

            if (metadataTypeAttribute != null)
            {
                type2 = metadataTypeAttribute.MetadataClassType;
            }

            _metadataTypeCache.TryAdd(type, type2);

            return type2;
        }
        private static void CheckAssociatedMetadataType(Type mainType, Type associatedMetadataType)
        {

        }

        public static Attribute[] GetAssociatedMetadata(Type type, string memberName)
        {
            Tuple<Type, string> key = new Tuple<Type, string>(type, memberName);

            Attribute[] customAttributes;

            if (_typeMemberCache.TryGetValue(key, out customAttributes))
            {
                return customAttributes;
            }

            MemberTypes type2 = MemberTypes.Field | MemberTypes.Property;
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

            MemberInfo memberInfo = type.GetMember(memberName, type2, bindingAttr).FirstOrDefault<MemberInfo>();

            if (memberInfo != null)
            {
                customAttributes = Attribute.GetCustomAttributes(memberInfo, true);
            }
            else
            {
                customAttributes = emptyAttributes;
            }

            _typeMemberCache.TryAdd(key, customAttributes);

            return customAttributes;
        }
    }
}
