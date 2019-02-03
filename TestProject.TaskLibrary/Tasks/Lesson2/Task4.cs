using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task4 : IRunnable
    {   //calculate circle length and area; Rectangle area and perimeter using static classes

        // initializing Coordinates
        private int TLX;
        private int TLY;
        private int BRX;
        private int BRY;
        private int R;
        private string s;

        public void Run() // main method
        {
            Console.WriteLine("*** Now you are in Lesson2.Task4 ***");
            Console.WriteLine("\n* Task4: Calculate 'Length' and 'Area' of circle; Perimeter and Area" +
                              "\n         of rectangle using Static classes.");

            NextTry:
            Console.WriteLine("Create Rectangle (\"r\") or Circle (\"c\") or both (\"rc\")?");

            TLX = 0;
            TLY = 0;
            BRX = 0;
            BRY = 0;
            R = 0;
            //calling method to choose shape
            s = Console.ReadLine().ToLower();
            ChooseShape(s);
            goto NextTry;
        }
        public void ChooseShape(string S)
        {
            //setting Coordinates or Exit
            if ((S == "q") | (S == "b"))
            {
                Environment.Exit(0);
            }
            else if (S == "r")
            {//calculating rectangle
                NextTryR:
                SetCds();
                //checking for Zero length
                if ((TLX == BRX) | (TLY == BRY))
                {
                    Console.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                    goto NextTryR;
                }
                Rectangle4.Perimeter(ref TLX,ref TLY, ref BRX,ref BRY);
                Rectangle4.Area(ref TLX, ref TLY, ref BRX, ref BRY);
            }
            else if (S == "c")
            {//calculating circle
                Console.WriteLine("Enter Radius (int) R: ");
                S = Console.ReadLine().ToLower();
                SetR(ref S,ref R);
                Circle4.Length(ref R);
                Circle4.Area(ref R);
            }
            else if (S == "rc")
            {//calculating both
                NextTryRC:
                SetCds();
                //checking for Zero length
                if ((TLX == BRX) | (TLY == BRY))
                {
                    Console.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                    goto NextTryRC;
                }
                Rectangle4.Perimeter(ref TLX, ref TLY, ref BRX, ref BRY);
                Rectangle4.Area(ref TLX, ref TLY, ref BRX, ref BRY);
                //circle
                Console.WriteLine("Enter Radius (int) R: ");
                S = Console.ReadLine().ToLower();
                SetR(ref S, ref R);
                Circle4.Length(ref R);
                Circle4.Area(ref R);
            }
            else
            {
                Console.WriteLine("Entered incorrect value.\nChoose shape: ");
                S = Console.ReadLine().ToLower();
                this.ChooseShape(S);
            }
            
        }
        private void SetR(ref string S, ref int r)
        {
            
            //setting Radius or Exit
            if ((S == "q") | (S == "b"))
            {
                Environment.Exit(0);
            }

            while (!Int32.TryParse(S, out r) | (r <= 0))
            {
                Console.WriteLine("Entered incorrect value.\nEnter only positive digits: ");
                S = Console.ReadLine().ToLower();
                this.SetR(ref S,ref r);
            }
        }
        public void SetCd(ref string S, ref int Cd)
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
                this.SetCd(ref S, ref Cd);
            }
        }

        public void SetCds()
        {
            //setting coordinates for Rectangle
            Console.WriteLine("Enter Top-Left coordinate (int) X: ");
            string s = Console.ReadLine().ToLower();
            this.SetCd(ref s, ref TLX);
            Console.WriteLine("Enter Top-Left coordinate (int) Y: ");
            s = Console.ReadLine().ToLower();
            this.SetCd(ref s, ref TLY);
            Console.WriteLine("Enter Bottom-Right coordinate (int) X: ");
            s = Console.ReadLine().ToLower();
            this.SetCd(ref s, ref BRX);
            Console.WriteLine("Enter Bottom-Right coordinate (int) Y: ");
            s = Console.ReadLine().ToLower();
            this.SetCd(ref s, ref BRY);
        }
    }

    public static class Circle4
    {
        //constants
        private const double pi = 3.14;

        //auto-implemented properties
        public static int R { get; set; }
        
        public static void Length(ref int r)
        {
            R = r;
            Console.WriteLine("Circle with Radius={0} has Length=" + (2 * pi * r), r);
            Console.WriteLine();
        }
        
        public static void Area(ref int r)
        {
            R = r;
            Console.WriteLine("Circle with Radius={0} has Area=" + (pi * r*r), r);
            Console.WriteLine();
        }
    }
    public static class Rectangle4
    {
        //auto-implemented properties
        public static int TLX { get; set; }
        public static int TLY { get; set; }
        public static int BRX { get; set; }
        public static int BRY { get; set; }

        public static void Perimeter(ref int tlx, ref int tly, ref int brx, ref int bry)
        {
            TLX = tlx;
            TLY = tly;
            BRX = brx;
            BRY = bry;
            int a = brx - tlx;
            if (a < 0)
                a *= -1;
            int b = tly - bry;
            if (b < 0)
                b *= -1;
            Console.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", tlx, tly);
            Console.WriteLine("and Bottom-Right X, Y: {0}, {1}", brx, bry);
            Console.WriteLine("has Perimeter: " + (2 * (a + b)));
            Console.WriteLine();

        }

        public static void Area(ref int tlx, ref int tly, ref int brx, ref int bry)
        {
            TLX = tlx;
            TLY = tly;
            BRX = brx;
            BRY = bry;
            int a = brx - tlx;
            if (a < 0)
                a *= -1;
            int b = tly - bry;
            if (b < 0)
                b *= -1;
            Console.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", tlx, tly);
            Console.WriteLine("and Bottom-Right X, Y: {0}, {1}", brx, bry);
            Console.WriteLine("has Area: " + (a * b));
            Console.WriteLine();
        }
    }
}
