using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Helper
{
    public static class ReflectionVehicleHelper
    {


        /// <summary>
        /// Finds all properties names of <paramref name="type"/>, including properties names
        /// of nested not String properties. If <paramref name="propertyPrefix"/> isn't null or Empty,
        /// then names of properties get prefix sided by point "prefix.nameOfProperty"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="propertyPrefix"></param>
        /// <returns>List of properties names</returns>
        private static List<String> GetAllPropertiesNames(Type type, string propertyPrefix)
        {
            List<string> propertiesList = new List<string>();

            foreach (var property in type.GetProperties())
            {
                string msg = propertyPrefix == null || propertyPrefix == String.Empty ?
                    String.Format(property.Name) :
                    String.Format(propertyPrefix + '.' + property.Name);

                if (property.PropertyType.IsClass && property.PropertyType != typeof(String))
                {
                    propertiesList.AddRange(GetAllPropertiesNames(property.PropertyType, msg));
                }
                else
                {
                    propertiesList.Add(msg);
                }
            }

            return propertiesList;
        }

        public static List<String> GetUniqueListOfPropertiesNames(Type[] types)
        {
            List<string> propertiesList = new List<string>();
            foreach(Type type in types)
            {
                foreach(string propertyName in GetAllPropertiesNames(type, String.Empty))
                {
                    if (!propertiesList.Contains(propertyName))
                    {
                        propertiesList.Add(propertyName);
                    }
                }
            }

            return propertiesList;
        }

    }
}
