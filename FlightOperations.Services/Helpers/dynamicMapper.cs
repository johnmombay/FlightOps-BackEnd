using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Services.Helpers
{
    public static class dynamicMapper
    {
        public static class DynamicMapper
        {
            public static T ToStatic<T>(object expando)
            {
                var entity = Activator.CreateInstance<T>();

                //ExpandoObject implements dictionary
                var properties = expando as IDictionary<string, object>;

                if (properties == null)
                    return entity;

                foreach (var entry in properties)
                {
                    var propertyInfo = entity.GetType().GetProperty(entry.Key);
                    if (propertyInfo != null)
                        propertyInfo.SetValue(entity, entry.Value, null);
                }
                return entity;
            }

            public static List<object> ToArrayStatic<T>(IEnumerable<object> expando)
            {

                var statArray = new List<object>();
                foreach (object exp in expando)
                {
                    var entity = Activator.CreateInstance<T>();
                    var properties = exp as IDictionary<string, object>;



                    foreach (var entry in properties)
                    {
                        var propertyInfo = entity.GetType().GetProperty(entry.Key);
                        if (propertyInfo != null)
                            propertyInfo.SetValue(entity, entry.Value, null);
                    }

                    statArray.Add(entity);

                }
                //ExpandoObject implements dictionary

                return statArray;
            }
        }
    }
}
