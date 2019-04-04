
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestProject.Common.Core.Classes.Utilities.Serializers
{
    /// <summary>
    /// Derializers to deserialize object from FileStream
    /// </summary>
    public static class DeserializeFromFileStream
    {
        /// <summary>
        /// Deserializes specified object from Binary format.
        /// </summary>
        /// <typeparam name="T">Type of resulting object.</typeparam>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void DeserializeBinary<T>(ref string file, out T obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = (T) bf.Deserialize(fs);
            }
        }

        public static void DeserializeBinary<T>(ref string file, out T[] obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = (T[])bf.Deserialize(fs);
                //T[] carsB = (T[])bf.Deserialize(fs);
                //T[] carsBin = new T[carsB.Length]; //new Car[carsB.Count];
                //obj = carsBin;// = carsB; //carsB.CopyTo(carsBin);
                //ConsIO.WriteLine($"Deserialized carsBin has {carsBin.Length} instances.");
            }
        }

        /// <summary>
        /// Deserializes specified object from JSON format.
        /// </summary>
        /// <typeparam name="T">Type of resulting object.</typeparam>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void DeserializeJSON<T>(ref string file, out T obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, fMode))
            {
                TextReader tr = new StreamReader(fs);
                obj = JsonConvert.DeserializeObject<T>(tr.ReadToEnd());//, Formatting.Indented);
            }
        }

        /// <summary>
        /// Deserializes specified object from XML format.
        /// </summary>
        /// <typeparam name="T">Type of resulting object.</typeparam>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void DeserializeXML<T>(ref string file, out T obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, fMode))
            {
                XmlSerializer xS = new XmlSerializer(typeof(T));
                obj = (T)xS.Deserialize(fs);
            }
        }
    }
}
