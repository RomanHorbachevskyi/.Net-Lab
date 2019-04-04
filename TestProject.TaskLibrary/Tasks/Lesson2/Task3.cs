using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task3 : IRunnable
    {   

        public void Run()
        {
            string s;
            int R;

            ConsIO.WriteLine("*** Now you are in Lesson2.Task3 ***");
            ConsIO.WriteLine("\n* Task3: Calculate 'Length' and 'Area' of circle using methods of instance." +
                              "\n       Needed Radius");
            
            //setting Radius for Circle
            ConsIO.WriteLine("Enter Radius (int): ");
            s = ConsIO.ReadLine().ToLower();
            R = Validators.GetIntPositiveNumber(s);
            
            //creating Rectangle instance
            var crl=new Circle(ref R);

            ConsIO.WriteLine("Circle with Radius={1} has Length={0}", crl.Length(ref R), R);
            ConsIO.WriteLine("Circle with Radius={1} has Area={0}", crl.Area(ref R), R);
            ConsIO.WriteLine();
            ConsIO.ReadLine();
            ConsIO.ReadLine();
        }
    }

    public class Circle
    {
        //constants
        private const double pi = 3.14;

        //auto-implemented properties
        public int R { get; set; }

        //constructor
        /// <summary>
        /// Initializes an instance of class Circle with specified radius.
        /// </summary>
        /// <param name="r"></param>
        public Circle(ref int r)
        {
            R = r;
        }

        /// <summary>
        /// Returns length of circle with specified radius.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public double Length(ref int r)
        {
            R = r;

            return (2 * pi * r);
        }
        
        /// <summary>
        /// Returns area of circle with specified radius.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public double Area(ref int r)
        {
            R = r;

            return (pi * r * r);
        }
    }
}
