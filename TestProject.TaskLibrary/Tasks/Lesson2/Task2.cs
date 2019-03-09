using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task2 : IRunnable
    {
        public void Run() // main method
        {
            ConsIO.WriteLine("*** Now you are in Lesson2.Task2 ***");
            ConsIO.WriteLine("\n* Task2: Calculate 'Perimeter' and 'Area' of rectangle using Auto-implemented Properties" +
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

            // checking for Zero length
            if ((TLX == BRX) | (TLY == BRY))
            {
                ConsIO.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                goto NextTry;
            }
            
            //creating Rectangle instance
            var rec=new Rectangle(TLX, TLY, BRX, BRY);

            ConsIO.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", rec.TopLeftX, rec.TopLeftY);
            ConsIO.WriteLine("and Bottom-Right X, Y: {0}, {1}", rec.BottomRightX, rec.BottomRightY);
            ConsIO.WriteLine("has Perimeter: " + rec.PerimeterByProperties());
            ConsIO.WriteLine("has Area: " + rec.AreaByProperties());
            ConsIO.WriteLine();
        }
    }

    public partial class Rectangle
    {
        //auto-implemented properties
        /// <summary>
        /// Top left X coordinate.
        /// </summary>
        public int TopLeftX { get; set; }
        /// <summary>
        /// Top left Y coordinate.
        /// </summary>
        public int TopLeftY { get; set; }
        /// <summary>
        /// Bottom right X coordinate.
        /// </summary>
        public int BottomRightX { get; set; }
        /// <summary>
        /// Bottom right Y coordinate.
        /// </summary>
        public int BottomRightY { get; set; }

        /// <summary>
        /// Initializes new instance of Rectangle by defining Auto-Properties.
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
            // fields
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.bottomRightX = bottomRightX;
            this.bottomRightY = bottomRightY;
        }
        /// <summary>
        /// Calculates an area of current rectangle
        /// by using properties.
        /// </summary>
        public int PerimeterByProperties()
        {
            int a = BottomRightX - TopLeftX;
            if (a < 0)
                a *= -1;
            int b = TopLeftY - BottomRightY;
            if (b < 0)
                b *= -1;

            return 2 * (a + b);
        }
        /// <summary>
        /// Calculates an area of current rectangle by using auto-properties.
        /// </summary>
        /// <returns></returns>
        public int AreaByProperties()
        {
            var a = BottomRightX - TopLeftX;
            if (a < 0)
                a *= -1;
            var b = TopLeftY - BottomRightY;
            if (b < 0)
                b *= -1;

            return a * b;
        }
    }
}
