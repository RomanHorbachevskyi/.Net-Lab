using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task2 : IRunnable
    {
        public void Run() // main method
        {
            Console.WriteLine("*** Now you are in Lesson2.Task2 ***");
            //Console.WriteLine("*** Select one of Tasks listed below ***");
            Console.WriteLine("\n* Task2: Calculate 'Perimetr' and 'Area' of rectangle using Auto-implemented Properties" +
                              "\n       Needed Top-Left and Bottom-Right coordinates");

            
            // initializing Coordinates
            int TLX;
            int TLY;
            int BRX;
            int BRY;

            NextTry:
            TLX = 0;
            TLY = 0;
            BRX = 0;
            BRY = 0;

            //setting coordinates for Rectangle
            Console.WriteLine("Enter Top-Left coordinate (int) X: ");
            string s = Console.ReadLine().ToLower();
            Task1.SetCd(ref s, ref TLX);
            Console.WriteLine("Enter Top-Left coordinate (int) Y: ");
            s = Console.ReadLine().ToLower();
            Task1.SetCd(ref s, ref TLY);
            Console.WriteLine("Enter Bottom-Right coordinate (int) X: ");
            s = Console.ReadLine().ToLower();
            Task1.SetCd(ref s, ref BRX);
            Console.WriteLine("Enter Bottom-Right coordinate (int) Y: ");
            s = Console.ReadLine().ToLower();
            Task1.SetCd(ref s, ref BRY);

            // checking for Zero length
            if ((TLX == BRX) | (TLY == BRY))
            {
                Console.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                goto NextTry;
            }

            //creating Rectangle instance
            Rectangle2 rec=new Rectangle2(ref TLX,ref TLY,ref BRX,ref BRY);
            rec.Perimeter();
            rec.Area();
        }

        /*public void SetCd(ref string S, ref int Cd)
        {
            //setting Coordinates or Exit
            if ((S == "q") | (S == "b"))
            {
                Environment.Exit(0);
            }
            //bool parsed= Int32.TryParse(s, out TLX);
            while (!Int32.TryParse(S, out Cd))
            {
                Console.WriteLine("Entered incorrect value.\nEnter only digits: ");
                S = Console.ReadLine().ToLower();
                this.SetCd(ref S,ref Cd);
            }
        }*/

    }

    public class Rectangle2
    {
        //auto-implemented properties
        public int TLX { get; set; }
        public int TLY { get; set; }
        public int BRX { get; set; }
        public int BRY { get; set; }


        //(int tlx, int tly, int brx, int bry)
        //private int TLX, TLY, BRX, BRY;

        public Rectangle2(ref int tlx, ref int tly, ref int brx, ref int bry)
        {
            TLX = tlx;
            TLY = tly;
            BRX = brx;
            BRY = bry;
        }

        public void Perimeter()
        {
            int a = BRX - TLX;
            if (a < 0)
                a *= -1;
            int b = TLY - BRY;
            if (b < 0)
                b *= -1;
            Console.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}",TLX,TLY);
            Console.WriteLine("and Bottom-Right X, Y: {0}, {1}", BRX, BRY);
            Console.WriteLine("has Perimeter: "+ (2 * (a + b)));
            Console.WriteLine();

        }

        public void Area()
        {
            int a = BRX - TLX;
            if (a < 0)
                a *= -1;
            int b = TLY - BRY;
            if (b < 0)
                b *= -1;
            Console.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", TLX, TLY);
            Console.WriteLine("and Bottom-Right X, Y: {0}, {1}", BRX, BRY);
            Console.WriteLine("has Area: " + (a * b));
            Console.WriteLine();
        }
    }

}
