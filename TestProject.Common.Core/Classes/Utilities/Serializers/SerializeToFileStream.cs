
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
    /// Serializers to serialize object to File
    /// </summary>
    public static class SerializeToFileStream
    {
        /// <summary>
        /// Serializes specified object to the specified format
        /// </summary>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        /// <param name="convert">Format to convert to.</param>
        public static void Serialize(ref string file, object obj, FileMode fMode, ConvertFromTo convert)
        {
            Type type = obj.GetType();
            switch (convert)
            {
                case ConvertFromTo.Binary:
                {
                        SerializeBinary(ref file, obj, fMode);
                    break;
                }
                case ConvertFromTo.JSON:
                {
                        SerializeJSON(ref file, obj, fMode);
                    break;
                }
                case ConvertFromTo.XML:
                {
                        SerializeXML(ref file, obj, fMode);
                    break;
                }
                default:
                {

                    break;
                }
            }
            
        }

        /// <summary>
        /// Serializes specified object into Binary format.
        /// </summary>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void SerializeBinary(ref string file, object obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, fMode))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Serializes specified object into JSON format.
        /// </summary>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void SerializeJSON(ref string file, object obj, FileMode fMode)
        {
            using (StreamWriter sw = File.CreateText(file))
            //using (FileStream fs = new FileStream(file, fMode))
            {
                //FileStream sw = File.OpenWrite(file);
                //StreamWriter sw = File.CreateText(file);
                
                string jData = JsonConvert.SerializeObject(obj);//, Formatting.Indented);
                //ConsIO.WriteLine(jData);
                sw.WriteLine(jData);
            }
        }
        
        /// <summary>
        /// Serializes specified object into XML format.
        /// </summary>
        /// <param name="file">File name with or w/o path.</param>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fMode">File mode.</param>
        public static void SerializeXML(ref string file, object obj, FileMode fMode)
        {
            using (FileStream fs = new FileStream(file, fMode))
            {
                XmlSerializer xS = new XmlSerializer(obj.GetType());
                xS.Serialize(fs, obj);
            }
        }
    }
}
