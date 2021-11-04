using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VehicleXML.Model;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Helper
{
    static class XmlHelper
    {
        /// <summary>
        /// Serializes generic list of objects to new XML File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objects"></param>
        /// <param name="filePath"></param>
        public static void XmlSerialize<T>(List<T> objects, string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, objects);
            }
        }
    }
}
