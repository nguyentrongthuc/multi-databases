using System;
using System.Collections.Generic;
using System.Reflection;
using ServiceCore.Models;

namespace ServiceCore.Utilities
{
    public class GettingPropertiesOfTable
    {
        public static IEnumerable<T> Copy<T>(IEnumerable<T> Sources, IEnumerable<T> Destinations, string ExceptProperty = null) where T : class
        {
            var Properties = GettingPropertiesOfTable.GetPropertiesByTableName<T>();
            foreach (var destination in Destinations)
            {
                foreach (var source in Sources)
                {
                    foreach (var property in Properties)
                    {
                        var NeedCopy = true;
                        if (ExceptProperty != null)
                        {
                            NeedCopy = property != ExceptProperty;
                        }
                        if (NeedCopy)
                        {
                            var sourceProperty = source.GetType().GetProperty(property);
                            var destinationProperty = destination.GetType().GetProperty(property);
                            if (sourceProperty != null && destinationProperty != null)
                            {
                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source), null);
                            }
                        }
                    }
                }
            }
            return Destinations;
        }
        public static List<string> GetPropertiesByTableName<T>()
        {
            var Properties = typeof(T).GetProperties();
            List<string> result = new List<string>();
            foreach (var item in Properties)
            {
                result.Add(item.Name);
            }
            return result;
        }

        public static bool HasProperty<T>(string propertyName)
        {
            List<string> properties = GettingPropertiesOfTable.GetPropertiesByTableName<T>();
            return properties.Contains(propertyName);
        }

        public static string GetPropertyType<T>(string propertyName)
        {
            if (GettingPropertiesOfTable.HasProperty<T>(propertyName))
            {
                Type typeOfTable = typeof(T);
                PropertyInfo info = typeOfTable.GetProperty(propertyName);
                return info.PropertyType.Name;
            }
            return null;
        }
    }
}