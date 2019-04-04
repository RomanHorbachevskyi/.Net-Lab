using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities.Enumerators;
using TestProject.Common.Core.Classes.Utilities.Serializers;

namespace TestProject.TaskLibrary.Tasks.Lesson13
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            int count = 5;
            Car[] cars;
            List<Car> lCars = new List<Car>();
            //Int32 i;
            ConsIO.Clear();
            string s = "*** Now you are in Lesson12.Task1 ***\n    Serialize/Deserialize a collection of instances" +
                       "\n      of the class Car (Binary/XML/JSON).";
            ConsIO.WriteLine(s);
            //i = 1;
            cars = new Car[count];
            for (int i = 0; i < count; i++)
            {
                cars[i] = new Car();
                cars[i].carId = i;
                cars[i].price = i * i * i;
                cars[i].quantity = i;
                cars[i].total = cars[i].quantity * cars[i].price;
                ConsIO.WriteLine(cars[i].carId + " " + cars[i].price + " " + cars[i].quantity + " " + cars[i].total);
                lCars.Add(cars[i]);
            }
            
            // Serialization
            s = "SerializedCars.BIN";
            SerializeToFileStream.Serialize(ref s, cars, FileMode.Create, ConvertFromTo.Binary);
            
            s = "SerializedCars.JSON";
            SerializeToFileStream.Serialize(ref s, cars, FileMode.Create, ConvertFromTo.JSON);
            /*using (FileStream fs = new FileStream("SerializedCars.JSON", FileMode.Create))
            {
                //ConsIO.WriteLine(fs.Name);
                StreamWriter sw = File.CreateText(fs.Name);
                string jData = JsonConvert.SerializeObject(cars);//, Formatting.Indented);
                ConsIO.WriteLine(jData);
                sw.WriteLine(jData);
            }*/
            s = "SerializedCars.XML";
            SerializeToFileStream.Serialize(ref s, cars, FileMode.Create, ConvertFromTo.XML);
            

            // Deserialization
            Car[] carsBin = {};
            s = "SerializedCars.BIN";
            DeserializeFromFileStream.DeserializeBinary<Car[]>(ref s, out carsBin, FileMode.Open);
            
            ConsIO.WriteLine($"Deserialized carsBin has {carsBin.Length} instances.");

            //List<Car> carsJSON;
            Car[] carsJSON = {};
            /*using (StreamReader fs = File.OpenText("SerializedCars.JSON")) //, FileMode.Open))
            {
                carsJSON = JsonConvert.DeserializeObject<Car[]>(fs.ReadToEnd()) ;//, Formatting.Indented);
                //ConsIO.WriteLine(jData);
                ConsIO.WriteLine($"Deserialized carsJSON has {carsJSON.Length} instances.");
            }*/

            s = "SerializedCars.JSON";
            DeserializeFromFileStream.DeserializeJSON<Car[]>(ref s, out carsJSON, FileMode.Open);
            /*using (FileStream fs = new FileStream("SerializedCars.JSON", FileMode.Open))
            {
                TextReader tr = new StreamReader(fs);
                carsJSON = JsonConvert.DeserializeObject<Car[]>(tr.ReadToEnd());//, Formatting.Indented);
                //ConsIO.WriteLine(jData);
                ConsIO.WriteLine($"Deserialized carsJSON has {carsJSON.Length} instances.");
            }*/
            ConsIO.WriteLine($"Deserialized carsJSON has {carsJSON.Length} instances.");

            Car[] carsXML = {};
            s = "SerializedCars.XML";
            DeserializeFromFileStream.DeserializeXML<Car[]>(ref s, out carsXML, FileMode.Open);
            
            ConsIO.WriteLine($"Deserialized carsXML has {carsXML.Length} instances.");

            //s = ConsIO.ReadLine();
            //ConsIO.CheckForExitTask(ref s);

            ConsIO.WriteLine("\n");
            ConsIO.ReadLine();
        }
    }

    [Serializable]
    public class Car
    {
        public Int32 carId;
        public decimal price;
        public Int32 quantity;
        [OptionalField]
        public decimal total;

        public Car() {}
    }
}
