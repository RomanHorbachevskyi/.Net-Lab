using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task4 : IRunnable
    {   //calculate circle length and area; Rectangle area and perimeter using static classes

        // initializing Coordinates
        private static int _topLeftX;
        private static int _topLeftY;
        private static int _bottomRightX;
        private static int _bottomRightY;
        private static int _radius;
        
        public void Run()
        {
            string s;

            string[] shapes = { "r", "c", "rc"};
            ConsIO.WriteLine("*** Now you are in Lesson2.Task4 ***");
            ConsIO.WriteLine("\n* Task4: Calculate 'Length' and 'Area' of circle; Perimeter and Area" +
                              "\n         of rectangle using Static classes.");

            NextTry:
            ConsIO.WriteLine("Create Rectangle (\"r\") or Circle (\"c\") or both (\"rc\")?");
            
            //calling method to choose shape
            s = ConsIO.ReadLine().ToLower();
            Validators.CheckForExitTask(ref s);
            while (Validators.IsCorrectStringValue(ref s, shapes)==false)
            {
                ConsIO.WriteLine("Entered incorrect value.\nChoose shape: ");
                s = ConsIO.ReadLine().ToLower();
                Validators.CheckForExitTask(ref s);
            }
            
            switch (s)
            {
                case "r":
                    NextTryR:
                    //getting coordinates for rectangle and getting perimeter/area
                    CreateRectangle();
                    if (HasZeroSide(_topLeftX, _topLeftY, _bottomRightX, _bottomRightY))
                    {
                        ConsIO.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                        goto NextTryR;
                    }
                    ShowStaticRectangleInfo();
                    break;
                case "c":
                    CreateCircle();
                    ShowStaticCircleInfo();
                    break;
                case "rc":
                    NextTryRC:
                    CreateRectangle();
                    if (HasZeroSide(_topLeftX, _topLeftY, _bottomRightX, _bottomRightY))
                    {
                        ConsIO.WriteLine("Wrong coordinates. Some side of rectangle has 0 length.");
                        goto NextTryRC;
                    }
                    ShowStaticRectangleInfo();
                    CreateCircle();
                    ShowStaticCircleInfo();
                    break;
                default:
                    ConsIO.WriteLine("Entered incorrect value for shape.");
                    goto NextTry;
            }
            ConsIO.ReadLine();
        }

        /// <summary>
        /// Asks to enter values for coordinates of the rectangle
        /// and uses validating method.
        /// </summary>
        public static void CreateRectangle()
        {
            ConsIO.Write("Enter Top-Left coordinate (int) X: ");
            _topLeftX = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.Write("Enter Top-Left coordinate (int) Y: ");
            _topLeftY = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.Write("Enter Bottom-Right coordinate (int) X: ");
            _bottomRightX = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
            ConsIO.Write("Enter Bottom-Right coordinate (int) Y: ");
            _bottomRightY = Validators.GetIntNumber(ConsIO.ReadLine().ToLower());
        }

        /// <summary>
        /// Asks to enter value for Radius of circle
        /// and uses validating method.
        ///  </summary>
        public static void CreateCircle()
        {
            ConsIO.WriteLine("Enter Radius (int) R: ");
            _radius = Validators.GetIntPositiveNumber(ConsIO.ReadLine().ToLower());
        }

        /// <summary>
        /// Checks if defined rectangle has 0 side.
        /// </summary>
        /// <param name="topLeftX">Top left X coordinate.</param>
        /// <param name="topLeftY">Top left Y coordinate.</param>
        /// <param name="bottomRightX">Bottom right X coordinate.</param>
        /// <param name="bottomRightY">Bottom right Y coordinate.</param>
        /// <returns></returns>
        public static bool HasZeroSide(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            return (topLeftX == bottomRightX) | (topLeftY == bottomRightY);
        }

        /// <summary>
        /// Shows user-friendly info of the defined static rectangle:
        /// Coordinates, Perimeter, Area.
        /// </summary>
        public static void ShowStaticRectangleInfo()
        {
            ConsIO.WriteLine("Rectangle with coordinates Top-Left X, Y: {0}, {1}", 
                        RectangleStatic.TopLeftX, RectangleStatic.TopLeftY);
            ConsIO.WriteLine("and Bottom-Right X, Y: {0}, {1}",
                        RectangleStatic.BottomRightX, RectangleStatic.BottomRightY);
            ConsIO.WriteLine("has Perimeter: " + RectangleStatic.Perimeter(_topLeftX, _topLeftY,
                                 _bottomRightX, _bottomRightY));
            ConsIO.WriteLine("has Area: " + RectangleStatic.Area(_topLeftX, _topLeftY,
                                 _bottomRightX, _bottomRightY));
        }

        /// <summary>
        /// Shows user-friendly info of the defined static circle:
        /// Radius, Length, Area.
        /// </summary>
        public static void ShowStaticCircleInfo()
        {
            ConsIO.WriteLine($"Circle with Radius = {_radius} has Length = {CircleStatic.Length(ref _radius)}");
            ConsIO.WriteLine($"  has Area = {CircleStatic.Area(ref _radius)}");
            ConsIO.WriteLine();
        }
    }

    public static class CircleStatic
    {
        //constants
        private const double Pi = 3.14;

        /// <summary>
        /// Property that contains value of radius.
        /// </summary>
        public static int Radius { get; set; }
        
        /// <summary>
        /// Returns length of the circle with specified radius.
        /// </summary>
        /// <param name="radius">Radius of needed circle.</param>
        /// <returns></returns>
        public static double Length(ref int radius)
        {
            Radius = radius;

            return 2 * Pi * radius;
        }

        /// <summary>
        /// Returns area of the circle with specified radius.
        /// </summary>
        /// <param name="radius">Radius of needed circle.</param>
        /// <returns></returns>
        public static double Area(ref int radius)
        {
            Radius = radius;

            return Pi * radius * radius;
        }
    }

    public static class RectangleStatic
    {
        #region Auto-implemented properties

        /// <summary>
        /// Top left X coordinate.
        /// </summary>
        public static int TopLeftX { get; set; }
        /// <summary>
        /// Top left Y coordinate.
        /// </summary>
        public static int TopLeftY { get; set; }
        /// <summary>
        /// Bottom right X coordinate.
        /// </summary>
        public static int BottomRightX { get; set; }
        /// <summary>
        /// Bottom right Y coordinate.
        /// </summary>
        public static int BottomRightY { get; set; }

        #endregion

        /// <summary>
        /// Returns perimeter of rectangle using specified coordinates.
        /// </summary>
        /// <param name="topLeftX">Top left X coordinate.</param>
        /// <param name="topLeftY">Top left Y coordinate.</param>
        /// <param name="bottomRightX">Bottom right X coordinate.</param>
        /// <param name="bottomRightY">Bottom right Y coordinate.</param>
        /// <returns></returns>
        public static int Perimeter(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
            var a = bottomRightX - topLeftX;
            if (a < 0)
                a *= -1;
            var b = topLeftY - bottomRightY;
            if (b < 0)
                b *= -1;

            return 2 * (a + b);
        }

        /// <summary>
        /// Returns area of rectangle using specified coordinates.
        /// </summary>
        /// <param name="topLeftX">Top left X coordinate.</param>
        /// <param name="topLeftY">Top left Y coordinate.</param>
        /// <param name="bottomRightX">Bottom right X coordinate.</param>
        /// <param name="bottomRightY">Bottom right Y coordinate.</param>
        /// <returns></returns>
        public static int Area(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
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
