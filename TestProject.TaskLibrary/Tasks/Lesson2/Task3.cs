using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task3 : IRunnable
    {   //calculate circle length and area

        public void Run() // main method
        {
            Console.WriteLine("*** Now you are in Lesson2.Task3 ***");
            Console.WriteLine("\n* Task3: Calculate 'Length' and 'Area' of circle using methods" +
                              "\n       Needed Radius");

            int R = 0;

            NextTry:
            
            //setting Radius for Circle
            Console.WriteLine("Enter Radius (int): ");
            string s = Console.ReadLine().ToLower();
            this.SetR( s);

            R=Int32.Parse(s);
            //ckecking for Zero length
            if (R<=0)
            {
                Console.WriteLine("Wrong Radius.");
                goto NextTry;
            }

            //creating Rectangle instance
            Circle crl=new Circle(ref R);
            crl.Length(ref R);
            crl.Area(ref R);
        }

        private void SetR(object R)
        {
            int r;
            //setting Radius or Exit
            if ((R.ToString() == "q") | (R.ToString() == "b"))
            {
                Environment.Exit(0);
            }
            //bool parsed= Int32.TryParse(R, out R);
            while (!Int32.TryParse(R.ToString(), out r) | (r <= 0))
            {
                Console.WriteLine("Entered incorrect value.\nEnter only positive digits: ");
                R = Console.ReadLine().ToLower();
                this.SetR(R);
            }
        }

    }

    public class Circle
    {
        //constants
        private const double pi = 3.14;

        //auto-implemented properties
        public int R { get; set; }
        
        //constructor
        public Circle(ref int r)
        {
            R = r;
        }
        public void Length(ref int r)
        {
            R = r;
            Console.WriteLine("Circle with Radius={0} has Length=" + (2 * pi * r), r);
            Console.WriteLine();
        }
        
        public void Area(ref int r)
        {
            R = r;
            Console.WriteLine("Circle with Radius={0} has Area=" + (pi * r*r), r);
            Console.WriteLine();
        }
    }

}
