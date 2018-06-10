using System;
using System.Collections.Generic;
using System.Linq;
using CsOhm.Attributes;

namespace CsOhm
{
    internal class Util
    {
        public static long? GetId<T>(T obj)
        {
            if (obj == null)
            {
                return null;
            }

            var idProp = obj.GetType().GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(IdAttribute)));

            if (idProp == null)
            {
                throw new CsOhmException("CsOhm does not support a Model without an Id");
            }

            return (long) idProp.GetValue(obj);
        }

        public static void SetId<T>(T obj, long id)
        {
            if (obj == null)
            {
                return;
            }
            var idProp = obj.GetType().GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(IdAttribute)));

            if (idProp == null)
            {
                throw new CsOhmException("CsOhm does not support a Model without an Id");
            }

            idProp.SetValue(obj, id);
        }

        public static IDictionary<string, string> GetFields<T>(T obj)
        {
            var fields = obj?.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(FieldAttribute)));

            if (fields == null)
            {
                return null;
            }

            var dict = new Dictionary<string, string>();
            foreach (var field in fields)
            {
                var name = field.Name;
                var value = field.GetValue(obj).ToString();
                dict.Add(name, value);
            }

            return dict;
        }

        public static void SetFields<T>(T obj, IDictionary<string, string> fields)
        {
            foreach (var field in fields)
            {
                var prop = obj.GetType().GetProperty(field.Key);
                prop?.SetValue(obj, Convert.ChangeType(field.Value, prop.PropertyType));
            }
        }
 
    }
}
