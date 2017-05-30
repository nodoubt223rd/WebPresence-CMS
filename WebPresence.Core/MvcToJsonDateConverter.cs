using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;

namespace WebPresence.Core
{
    internal class MvcToJsonDateConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            //Define the ListItemCollection as a supported type.
            get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(DateTime), typeof(DateTime?) })); }
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                return null;

            object val = dictionary["DateInTicks"];

            if (val == null)
                return null;
            else
                return new DateTime((long)val);

        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            IDictionary<string, object> res = new Dictionary<string, object>();

            if (obj == null)
                res.Add("DateInTicks", null);
            else
                res.Add("DateInTicks", ((DateTime)obj).Ticks);

            return res;
        }
    }
}
