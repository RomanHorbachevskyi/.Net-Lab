using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            ConsIO.WriteLine("*** Now you are in Lesson2.Task1 ***");
            ConsIO.WriteLine("\n* Task1: Calculate 'Perimeter' and 'Area' of rectangle using fields." +
                              "\n       Needed Top-Left and Bottom-Right coordinates");

            // initializing Coordinates
            int TLX;
            int TLY;
            int BRX;
            int BRY;

            NextTry:
            //setting coordinates for Rectangle
            ConsIO.WriteLine("Enter Top-Left coordinate (int) X: ");
            TLX = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.WriteLine("Enter Top-Left coordinate (int) Y: ");
            TLY = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.WriteLine("Enter Bottom-Right coordinate (int) X: ");
            BRX = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.WriteLine("Enter Bottom-Right coordinate (int) Y: ");
            BRY = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());

            //checking for Zero length
            if ((TLX == BRX) | (TLY == BRY))
            {
                ConsIO.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                goto NextTry;
            }

            //creating Rectangle instance
            var rec=new Rectangle(ref TLX,ref TLY,ref BRX,ref BRY);
            
            ConsIO.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", TLX, TLY);
            ConsIO.WriteLine("and Bottom-Right X, Y: {0}, {1}", BRX, BRY);
            ConsIO.WriteLine("has Perimeter: " + rec.Perimeter());
            ConsIO.WriteLine("has Area: " + rec.Area());
            ConsIO.WriteLine();
            ConsIO.ReadLine();
        }
        
    }

    public partial class Rectangle
    {
        private int topLeftX, topLeftY, bottomRightX, bottomRightY;
        
        /// <summary>
        /// Initializes new instance of Rectangle by defining fields.
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public Rectangle(ref int topLeftX, ref int topLeftY, ref int bottomRightX, ref int bottomRightY)
        {
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.bottomRightX = bottomRightX;
            this.bottomRightY = bottomRightY;
            // auto-properties
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
        }

        /// <summary>
        /// Calculates perimeter of current rectangle by using fields.
        /// Do Not use it if you changed coordinates.
        /// </summary>
        public int Perimeter()
        {
            var a = bottomRightX - topLeftX;
            if (a < 0)
                a *= -1;
            var b = topLeftY - bottomRightY;
            if (b < 0)
                b *= -1;
            return 2 * (a + b);
        }

        /// <summary>
        /// Calculates an area of current rectangle by using fields.
        /// Do Not use it if you changed coordinates.
        /// </summary>
        public int Area()
        {
            var a = bottomRightX - topLeftX;
            if (a < 0)
                a *= -1;
            var b = topLeftY - bottomRightY;
            if (b < 0)
                b *= -1;

            return a * b;
        }
    }
}
