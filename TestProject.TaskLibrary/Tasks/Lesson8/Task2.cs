﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson8
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            int offsetBottom=4;
            int CirclesCount;
            int windowWidth = ConsIO.WindowWidth;
            int windowHeight = ConsIO.WindowHeight;
            
            Circle[] Circles;
            
            string s = "*** Now you are in Lesson8.Task1 ***\n    Style Coding. Work with Circle";
            ConsIO.WriteLine(s);
            ConsIO.Write("How many Circles do you want to draw?:  ");
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            CirclesCount = Validators.GetIntPositiveNumber(s);

            Circles = new Circle[CirclesCount];
            
            ConsIO.WriteLine("\n***  Window dimensions: " + windowWidth + "; " + windowHeight + "  ***\n");

            for (int i = 0; i < CirclesCount; i++)
            {
                CreateCircle(ref i, ref Circles);
                
            }
            ConsIO.Clear();

            Circle.LeftOffsetX = 11;
            Circle.TopOffsetY = 3;
            Circle.OffsetHorizontal = Circle.LeftOffsetX + 0;
            Circle.OffsetVertical = Circle.TopOffsetY + offsetBottom;
            Circle.OffsetBottom = offsetBottom;

            ConsIO.WriteLine("\n\n\n");
            foreach (var circle in Circles)
            {
                ConsIO.WriteLine($"{circle.X}, {circle.Y}, {circle.Radius}");
            }

            Circle.Draw(Circles);
            
            WhatToDo(ref offsetBottom, ref Circles);

            ConsIO.ClearBottom(ref offsetBottom);

            ConsIO.ReadLine();
        }

        /// <summary>
        /// Asks what to do next. Text is displayed in the line
        /// "offsetBottom" from the bottom of window.
        /// </summary>
        /// <param name="offsetBottom">Distance (number of lines)</param>
        /// <param name="Circles">An array of Circles we work with</param>
        private static void WhatToDo(ref int offsetBottom, ref Circle[] Circles)
        {
            string s;
            int first;
            int second;
            ConsIO.ClearBottom(ref offsetBottom);
            ConsIO.Write($"What to do now? [M]ove Circle, [R]esize, create [I]ntersected, [S]mallest or [Q]uit?:  ");
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);

            if (s.ToLower() == "m")
            {
                ConsIO.ClearBottom(ref offsetBottom);
                MoveCircle(ref Circles);
                Circle.Draw(Circles);
            }
            else if (s.ToLower() == "r")
            {
                ResizeCircle(ref Circles);
                Circle.Draw(Circles);
            }
            /*else if (s.ToLower() == "i")
            {
                EnterIntPositive("\rEnter number of Circle a:  ", out first);
                EnterIntPositive("\rEnter number of Circle b:  ", out second);
                first -= 1;
                second -= 1;
                CreateIntersectedCircle(first, second, ref Circles);
                Circle.Draw(Circles);
            }*/
            else if (s.ToLower() == "s")
            {
                EnterIntPositive("\rEnter number of Circle a:  ", out first);
                EnterIntPositive("\rEnter number of Circle b:  ", out second);
                first -= 1;
                second -= 1;
                CreateSmallestCircle(first, second, ref Circles);
            }
            
            WhatToDo(ref offsetBottom, ref Circles);
        }

        /*
        /// <summary>
        /// Checks if Circle "a" intersects with Circle "b"
        /// and creates Circle from intersection.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="rects"></param>
        private static void CreateIntersectedCircle(int a, int b, ref Circle[] rects)
        {
            int offsetBottom = Circle.OffsetBottom;

            if (rects[a].IntersectsWith(rects[b]))
            {
                ConsIO.Clear();
                ConsIO.SetCursorPosition(0, 0);
                var intersectedCircle = Circle.Intersect(rects[a],rects[b]);
                ConsIO.Write($"Circle on intersection of rect {a+1} and {b+1} " +
                                 $"has X: {intersectedCircle.X}, " +
                                 $"Y: {intersectedCircle.Y}, " +
                                 $"Width: {intersectedCircle.Diameter}, " +
                                 $"Height: {intersectedCircle.Diameter}");
                ConsIO.SetCursorPosition(0,0);
                intersectedCircle.DrawFrom00=true;
                intersectedCircle.Draw();
            }
            else
            {
                ConsIO.WriteLine("Circles are not intersecting. Press 'Enter' key and choose what to do.");
                ConsIO.ReadLine();
            }
            WhatToDo(ref offsetBottom, ref rects);
        }*/
        
        /// <summary>
        /// Checks smallest Circle dimensions with our bounds and
        /// creates it if it is inside bounds. If no - asks what to do. 
        /// </summary>
        /// <param name="a">Index of element</param>
        /// <param name="b">Index of element</param>
        /// <param name="rects">An array with Circles</param>
        private static void CreateSmallestCircle(int a, int b, ref Circle[] rects)
        {
            string s;
            if (Circle.IsInWindowSmallestForBoth(ref rects[a], ref rects[b]))
            {
                var smRect = Circle.GetSmallestCircle();
                ConsIO.Clear();
                ConsIO.SetCursorPosition(0, 0);
                ConsIO.Write($"The smallest Circle for rect {a + 1} and {b + 1} " +
                             $"has X: {smRect.X}, " +
                             $"Y: {smRect.Y}, " +
                             $"Width: {smRect.Diameter}, " +
                             $"Height: {smRect.Diameter}");
                ConsIO.SetCursorPosition(0, 0);
                smRect.Draw();
            }
            else
            {
                s = $"The smallest Circle for rect {a + 1} and {b + 1} is bigger of bounds.\nPress 'Enter' key.";
                ConsIO.Write(s);
                ConsIO.ReadLine();
            }
            WhatToDo(ref Circle.OffsetBottom, ref rects);
        }

        /// <summary>
        /// Creates new Circle and checks is it inside our limits of window
        /// </summary>
        /// <param name="i">Index of array element</param>
        /// <param name="Circles">An array of Circles we work with</param>
        private static void CreateCircle(ref int i, ref Circle[] Circles)
        {
            int centerX;
            int centerY;
            int radius;

            ConsIO.WriteLine($"Enter for Circle {i + 1}:\n");
            EnterInt("\r center X: ", out centerX);
            EnterInt("\r center Y: ", out centerY);
            EnterIntPositive("\r Radius: ", out radius);
            Circles[i] = new Circle(centerX, centerY, radius);
            while (WindowChecker.CirclesAreInWindow(Circle.OffsetHorizontal, Circle.OffsetVertical, Circles.Take(i + 1).ToArray()) == false)
            {
                ConsIO.WriteLine($"Current Circle {i + 1} is out of our bounds. Try one more time.");
                CreateCircle(ref i, ref Circles);
            }
        }

        /// <summary>
        /// Resizes Circle (and redraws all) after asking number of Circle,
        /// offsets along X and Y axises. If it will be out of the bounds
        /// you will be asked to set new values before resizing.
        /// </summary>
        /// <param name="rects">An array of Circles</param>
        private static void ResizeCircle(ref Circle[] rects)
        {
            int i, dX, dY;
            string vertex;
            int lowerBound = rects.GetLowerBound(0) + 1;
            int upperBound = rects.GetUpperBound(0) + 1;
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rEnter number of Circle you want to Resize:  ", out i);
            i = Validators.GetCorrectIndexInsideBounds(i, ref lowerBound, ref upperBound) - 1;
            ConsIO.ClearBottom(ref Circle.OffsetBottom);

            vertex = EnterVertex();
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rEnter dX:  ", out dX);
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rEnter dY:  ", out dY);
            rects[i].Resize(vertex, dX);
            while (WindowChecker.CirclesAreInWindow(Circle.OffsetHorizontal, Circle.OffsetVertical, rects) == false)
            {
                rects[i].Resize(vertex, -dX);
                ConsIO.ClearBottom(ref Circle.OffsetBottom);
                ConsIO.Write("\rWe are going outside the bounds. Enter new values for ");
                EnterInt("dX:  ",out dX);
                ConsIO.SetCursorPosition(0, ConsIO.WindowHeight - Circle.OffsetBottom);
                ConsIO.ClearBottom(ref Circle.OffsetBottom);
                EnterInt("  dY:  ", out dY);
                ResizeCircle(ref rects);
            }
            ConsIO.Clear();
            foreach (var rect in rects)
            {
                ConsIO.WriteLine($"{rect.X},{rect.Y},{rect.Diameter},{rect.Diameter}");
            }
            
        }

        /// <summary>
        /// Returns string with correct value that corresponds to
        /// names of vertexes: L - left, T - top,
        /// B - bottom, R - right.
        /// If entered incorrect value
        /// you will be asked to enter new.
        /// </summary>
        /// <returns></returns>
        private static string EnterVertex()
        {
            string s;
            string[] vertexes = { "L", "T", "B", "R", "C" };
            ConsIO.Write("\rEnter vertex [L]eft, [T]op, [B]ottom," +
                         "\n [R]ight, [C]enter:  ");
            s = ConsIO.ReadLine();
            while (Validators.IsCorrectStringValue(ref s, vertexes) == false)
            {
                ConsIO.ClearBottom(ref Circle.OffsetBottom);
                ConsIO.Write("\rEntered incorrect value! Allowed only L,T, B, R, C:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
            }

            return s;
        }

        /// <summary>
        /// Displays specified string in current line and
        /// gets correct integer.
        /// If entered incorrect value
        /// you will be asked to enter new.
        /// </summary>
        /// <param name="description">String that have to be displayed</param>
        /// <param name="result"></param>
        private static void EnterInt(string description, out int result)
        {
            ConsIO.Write(description);
            description = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref description);
            result = Validators.GetIntNumber(description);
        }
        /// <summary>
        /// Displays specified string in current line and
        /// gets correct positive integer.
        /// If entered incorrect value
        /// you will be asked to enter new.
        /// </summary>
        /// <param name="description">String that have to be displayed</param>
        /// <param name="result"></param>
        private static void EnterIntPositive(string description, out int result)
        {
            ConsIO.Write(description);
            description = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref description);
            result = Validators.GetIntPositiveNumber(description);
        }

        /// <summary>
        /// Moves Circle (and redraws all) after asking number of Circle,
        /// offsets along X and Y axises. If it will be out of the bounds
        /// you will be asked to set new values before moving.
        /// </summary>
        /// <param name="circs">An array of Circles we work with</param>
        private static void MoveCircle(ref Circle[] circs)
        {
            int i, dX, dY;
            int lowerBound = circs.GetLowerBound(0) + 1;
            int upperBound = circs.GetUpperBound(0) + 1;
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rEnter number of Circle you want to Move:  ", out i);
            i = Validators.GetCorrectIndexInsideBounds(i, ref lowerBound, ref upperBound) - 1;
            
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rFor Circle you want to move enter dX:  ", out dX);
            ConsIO.ClearBottom(ref Circle.OffsetBottom);
            EnterInt("\rEnter dY:  ", out dY);
            circs[i].Move(dX, dY);
            while (WindowChecker.CirclesAreInWindow(Circle.OffsetHorizontal, Circle.OffsetVertical, circs) == false)
            {
                circs[i].Move(-dX, -dY);
                ConsIO.ClearBottom(ref Circle.OffsetBottom);
                EnterInt("\rWe are going outside the bounds. Enter new values for dX:  ", out dX);
                ConsIO.SetCursorPosition(0, ConsIO.WindowHeight - Circle.OffsetBottom);
                ConsIO.ClearBottom(ref Circle.OffsetBottom);
                EnterInt("\r  for dY:  ", out dY);
                MoveCircle(ref circs);
            }
            ConsIO.Clear();
            foreach (var circle in circs)
            {
                ConsIO.WriteLine($"{circle.X}, {circle.Y}, {circle.Radius}");
            }
        }
    }

    public static partial class WindowChecker
    {
        /// <summary>
        /// Checks if Circle is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="circle"></param>
        /// <returns></returns>
        public static bool CircleIsInWindow(int offsetHorizontal, int offsetVertical, Circle circle)
        {
            return (circle.Diameter < ConsIO.WindowHeight - offsetVertical) && (circle.Diameter < ConsIO.WindowWidth - offsetHorizontal);
        }

        /// <summary>
        /// Checks if Circle is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="diameter"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static bool CircleIsInWindow(int offsetHorizontal, int offsetVertical, int diameter)
        {
            return (diameter < ConsIO.WindowHeight - offsetVertical) && 
                   (diameter < ConsIO.WindowWidth - offsetHorizontal);
        }

        /// <summary>
        /// Checks if all Circles are inside current Window (based on coordinates)
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="circles">An array of Circles</param>
        /// <returns></returns>
        public static bool CirclesAreInWindow(int offsetHorizontal, int offsetVertical, params Circle[] circles)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            Circle.GetBounds(ref x1, ref x2, ref y1, ref y2, circles);
            int tempWidth = x2 - x1;
            int tempHeight = y2 - y1;
            return (tempHeight < ConsIO.WindowHeight - offsetVertical) && 
                   (tempWidth < ConsIO.WindowWidth - offsetHorizontal);
        }
    }

    
    public class Circle : Figure
    {
        public bool DrawFrom00;
        public static int LeftOffsetX;
        public static int TopOffsetY;
        public static int OffsetHorizontal;
        public static int OffsetVertical;
        public static int OffsetBottom;
        public static readonly int[,] Empty;

        private static double Pi = Math.PI;
        private static int _minY;
        private static int _absMinY;
        private static int _minX;
        private static int _absMinX;
        
        #region For Smallest Circle from Both Circles

        private static int _width1;
        private static int _height1;
        private static int _width2;
        private static int _height2;
        //private static int _area1;
        //private static int _area2;
        private static int _tempValue;
        private static int _tempWidth;
        private static int _tempHeight;
        private static int _tempArea;
        private static int _firstWidth;
        private static int _firstHeight;
        private static int _secondWidth;
        private static int _secondHeight;
        private static int _smDiameter;
        private static int _smHeight;
        private static int _smArea;

        #endregion

        private int x;
        private int y;
        private int _radius;
        private int _diameter;



        #region Properties

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets or sets width of the rectangular
        /// region defined by this "Circle"
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                _diameter = 2 * value; 
            }
        }

        /// <summary>
        /// Gets or sets height of the rectangular
        /// region defined by this "Circle"
        /// </summary>
        public int Diameter
        {
            get { return _diameter; }
            set
            {
                _diameter = value;
                _radius = value / 2;
            }
        }

        /// <summary>
        /// Gets the x-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int Left
        {
            get { return X - Radius; }
        }

        /// <summary>
        /// Gets the y-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int Top
        {
            get { return Y - Radius; }
        }

        /// <summary>
        /// Gets the x-coordinate of the lower-right corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int Right
        {
            get { return X + Radius; }
        }

        /// <summary>
        /// Gets the y-coordinate of the lower-right corner
        /// of the rectangular region defined by this "Circle"
        /// </summary>
        public int Bottom
        {
            get { return Y + Radius; }
        }

        /// <summary>
        /// Gets area of Circle
        /// </summary>
        public double Area
        {
            get { return Pi * Radius * Radius; }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the "Circle" class with the
        /// specified location and size.
        /// </summary>
        /// <param name="x">Left X</param>
        /// <param name="y">Top Y</param>
        /// <param name="radius"></param>
        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
        
        /// <summary>
        /// Moves Circle.
        /// </summary>
        /// <param name="dX">Distance to move along X</param>
        /// <param name="dY">Distance to move along Y</param>
        public void Move(int dX = 0, int dY = 0)
        {
            X += dX;
            Y += dY;
        }

        /// <summary>
        /// Tests whether "obj" is a "Circle" with 
        /// the same location and size of this Circle.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Circle))
                return false;

            Circle comp = (Circle)obj;

            return (comp.X == X) &&
                   (comp.Y == Y) &&
                   (comp.Radius == Radius) &&
                   (comp.Diameter == Diameter);
        }

        /// <summary>
        /// Determines if the rectangular region represented by 
        /// "rect" is entirely contained within the
        /// rectangular region represented by this "Circle".
        /// </summary>
        /// <param name="otherCircle"></param>
        /// <returns></returns>
        public bool Contains(Circle otherCircle)
        {
            return (Left < otherCircle.Left) &&
                   ((otherCircle.Right) < (Right)) &&
                   (Bottom > otherCircle.Bottom) &&
                   ((otherCircle.Top) < (Top));
        }

        /// <summary>
        /// Creates a Circle that represents the intersection between this Circle and rect.
        /// </summary>
        /// <param name="otherCircle"></param>
        public void Intersect(Circle otherCircle)
        {
            int[,] result = Intersect(otherCircle, this);

            //X = result.X;
            //Y = result.Y;
            //Radius = result.Radius;
        }

        /// <summary>
        /// Creates a Circle that represents the intersection between a
        ///   and b. If there is no intersection, null is returned.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[,] Intersect(Circle a, Circle b)
        {
            var aPath = a.CirclePath();
            var bPath = b.CirclePath();
            int[,] path;
            int minX, maxX;
            int yForMin, yForMax;

            if (a.FindCircleCircleIntersections(b, out var x1, out var y1,
                    out var x2, out var y2) == 2)
            {
                if (x1 < x2 || (x1==x2 & y1 < y2))
                {
                    minX = x1;
                    yForMin = y1;
                    maxX = x2;
                    yForMax = y2;
                }
                else if (x2 < x1 || (x1 == x2 & y2 < y1))
                {
                    minX = x2;
                    yForMin = y2;
                    maxX = x1;
                    yForMax = y1;
                }
                
                for (int i = 0; i < aPath.GetLength(0); i++)
                {
                    //if (aPath[i,0])
                    {
                        
                    }
                }
            }


            if (x2 >= x1
                && y2 >= y1)
            {

                return new int[2,2]; //(x1, y1, x2 - x1);
            }

            return Empty;
        }

        /// <summary>
        /// Finds the points where the two circles intersect.
        /// Result 0 if no intersection or 1 point. Else result 2.
        /// </summary>
        /// <param name="circle">The second circle</param>
        /// <param name="x1">X coordinate of 1st point</param>
        /// <param name="y1">Y coordinate of 1st point</param>
        /// <param name="x2">X coordinate of 2st point</param>
        /// <param name="y2">Y coordinate of 2st point</param>
        /// <returns></returns>
        private int FindCircleCircleIntersections(Circle circle,
            out int x1, out int y1, out int x2, out int y2)
        {
            // Find the distance between the centers.
            int dx = this.X - circle.X;
            int dy = this.Y - circle.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > this.Radius + circle.Radius)
            {
                // No solutions, the circles are too far apart.
                x1 = 0; y1 = 0;
                x2 = 0; y2 = 0;
                return 0;
            }
            else if (dist < Math.Abs(this.Radius - circle.Radius))
            {
                // No solutions, one circle contains the other.
                x1 = 0; y1 = 0;
                x2 = 0; y2 = 0;
                return 0;
            }
            else if ((dist == 0) && (this.Radius == circle.Radius))
            {
                // No solutions, the circles coincide.
                x1 = 0; y1 = 0;
                x2 = 0; y2 = 0;
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (this.Radius * this.Radius -
                            circle.Radius * circle.Radius + dist * dist) / (2 * dist);
                double h = Math.Sqrt(this.Radius * this.Radius - a * a);

                // Find P2.
                double cx2 = this.X + a * (circle.X - this.X) / dist;
                double cy2 = this.Y + a * (circle.Y - this.Y) / dist;

                // Get the points P3.
                x1 = (int) (cx2 + h * (circle.Y - this.Y) / dist);
                y1 = (int) (cy2 - h * (circle.X - this.X) / dist);
                x2 = (int) (cx2 - h * (circle.Y - this.Y) / dist);
                y2 = (int) (cy2 + h * (circle.X - this.X) / dist);

                // See if we have 1 or 2 solutions.
                if (dist == this.Radius + circle.Radius) return 0;
                return 2;
            }
        }


        /// <summary>
        /// Determines if this Circle intersects with rect.
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        public bool IntersectsWith(Circle circle)
        {
            return FindCircleCircleIntersections(circle, out var x1, out var y1,
                out var x2, out var y2)==2;
        }

        /// <summary>
        /// Creates a Circle that represents the union between a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Circle Union(Circle a, Circle b)
        {
            int x1 = Math.Min(a.X, b.X);
            int x2 = Math.Max(a.X + a.Radius, b.X + b.Radius);
            int y1 = Math.Min(a.Y, b.Y);
            
            return new Circle(x1, y1, x2 - x1);
        }
        /// <summary>
        /// Creates a Circle that represents the union between a and b.
        /// </summary>
        /// <param name="rects"></param>
        /// <returns></returns>
        public static Circle UnionFew(params Circle[] rects)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            GetBounds(ref x1, ref x2, ref y1, ref y2, rects);

            return new Circle(x1, y1, x2 - x1);
        }


        #region Smallest Circle for two Circles

        /// <summary>
        /// Returns new smallest Circle for two Circles.
        /// Call this method only after using "IsInWindowSmallestForBoth".
        /// </summary>
        /// <returns></returns>
        public static Circle GetSmallestCircle()
        {
            return new Circle(_smDiameter / 2, _smDiameter / 2, _smDiameter / 2);
        }

        /// <summary>
        /// Checks if smallest Circle for both Circles
        /// will be in our bounds (window).
        /// </summary>
        /// <param name="circle1"></param>
        /// <param name="circle2"></param>
        /// <returns></returns>
        public static bool IsInWindowSmallestForBoth(ref Circle circle1, ref Circle circle2)
        {
            _smDiameter = circle1.Diameter + circle2.Diameter;
            
            // Checking if we can draw Circle inside ConsIO.Window
            return WindowChecker.CircleIsInWindow(OffsetHorizontal, OffsetVertical, _smDiameter);
        }

        #endregion


        /// <summary>
        /// Changes dimensions of Circle for specified values.
        /// </summary>
        /// <param name="vertex">"L" - to left, "T" - to top,
        /// "B" - to bottom, "R" - to right</param>
        /// <param name="dDiam">Along X</param>
        public void Resize(string vertex, int dDiam)
        {
            if (vertex.ToLower() == "t")
            {
                X -= dDiam / 2;
                Y -= dDiam / 2;
            }
            else if (vertex.ToLower() == "r")
            {
                X += dDiam / 2;
            }
            else if (vertex.ToLower() == "l")
            {
                X -= dDiam / 2;
            }
            else if (vertex.ToLower() == "b")
            {
                Y += dDiam / 2;
            }
            else if (vertex.ToLower() == "c")
            {
                Radius += dDiam / 2;
            }
        }


        /// <summary>
        /// Gets bounds of the space needed for entered Circles
        /// </summary>
        /// <param name="x1">Left</param>
        /// <param name="x2">Right</param>
        /// <param name="y1">Top in console window (y1 smaller y2)</param>
        /// <param name="y2">Bottom in console window</param>
        /// <param name="circles"></param>
        public static void GetBounds(ref int x1, ref int x2, ref int y1, ref int y2, params Circle[] circles)
        {
            int[] minsY = new int[circles.Length];
            int[] minsX = new int[circles.Length];
            int[] maxsY = new int[circles.Length];
            int[] maxsX = new int[circles.Length];

            for (int i = 0; i < circles.Length; i++)
            {
                minsX[i] = circles[i].Left;
                minsY[i] = circles[i].Top;
                maxsX[i] = circles[i].Right;
                maxsY[i] = circles[i].Bottom;
            }

            x1 = MyMath.Min(minsX);
            x2 = MyMath.Max(maxsX);
            y1 = MyMath.Min(minsY);
            y2 = MyMath.Max(maxsY);
        }


        #region Drawing Circle(s)

        /// <summary>
        /// Draws only current Circle.
        /// </summary>
        public new void Draw()
        {
            // Drawing in the current view
            DrawInView(this);
        }
        
        /// <summary>
        /// Draws specified Circle in the view (cursor at 0,0 + offsets)
        /// </summary>
        /// <param name="circle"></param>
        private void DrawInView(Circle circle)
        {
            var circlePath = CirclePath();
            for (int i = 0; i < circlePath.GetLength(0); i++)
            {
                ConsIO.SetCursorPosition(LeftOffsetX + circlePath[i,0], 
                    TopOffsetY + circlePath[i, 1]);
                ConsIO.Write("*");
            }
        }
        
        
        /// <summary>
        /// Draws every Circle from array
        /// </summary>
        /// <param name="circles"></param>
        public static void Draw(params Circle[] circles)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            int[] minsY = new int[circles.Length];
            int[] minsX = new int[circles.Length];
            
            for (int i = 0; i < circles.Length; i++)
            {
                minsY[i] = circles[i].Top;
                minsX[i] = circles[i].Left;
            }
            _minY = MyMath.Min(minsY);
            _absMinY = Math.Abs(_minY);
            _minX = MyMath.Min(minsX);
            _absMinX = Math.Abs(_minX);

            // Setting coordinates to start from 0,0
            SetCoordsTo0(circles);
            GetBounds(ref x1, ref x2, ref y1, ref y2, circles);
            
            // Drawing Circles
            foreach (var circle in circles)
            {
                circle.DrawFrom00 = true;
                circle.Draw();
            }
            // Resetting coordinates to original value
            ResetCoordsFrom0(circles);
            ConsIO.SetCursorPosition(0, y2 + 1);
        }

        /// <summary>
        /// Returns an int[n,2] array with coordinates
        /// where to draw a circle. 
        /// </summary>
        /// <returns></returns>
        private int[,] CirclePath()
        {
            var n = Diameter;
            int[,] pathTop = new int[n + 1, 2];
            int[,] pathBottom = new int[n + 1, 2];
            var path = new int[2 * (n + 1), 2];
            for (int i = 1; i <= n; i++)
            {
                pathTop[i, 0] = Left + i;
                pathTop[i, 1] = Y - (int)Math.Sqrt(Radius * Radius - (Left + i - X) * (Left + i - X));
                pathBottom[i-1, 0] = Left + i;
                pathBottom[i-1, 1] = Y + (int) Math.Sqrt(Radius * Radius - (Left + i - X) * (Left + i - X));
            }
            pathTop[0, 0] = Left;
            pathTop[0, 1] = Y;
            pathBottom[n, 0] = Right;
            pathBottom[n, 1] = Y;
            // Getting full path
            for (int i = 0; i < n + 1; i++)
            {
                path[i, 0] = pathTop[i, 0];
                path[i, 1] = pathTop[i, 1];
            }
            for (int i = n + 1; i < 2 * (n + 1); i++)
            {
                int temp = pathBottom[i - n - 1, 0];
                path[i, 0] = pathBottom[i - n - 1, 0];
                path[i, 1] = pathBottom[i - n - 1, 1];
            }
            
            return path;
        }

        #endregion


        /// <summary>
        /// "Moves" Circles for drawing them from 0,0 of outstream.
        /// </summary>
        /// <param name="circles">An array of Circles</param>
        private static void SetCoordsTo0(params Circle[] circles)
        {
            // Setting coordinates to start from 0,0
            if (_minY >= 0)
            {
                foreach (var circle in circles) circle.Y -= _absMinY;
            }
            else
            {
                foreach (var circle in circles) circle.Y += _absMinY;
            }
            if (_minX >= 0)
            {
                foreach (var circle in circles) circle.X -= _absMinX;
            }
            else
            {
                foreach (var circle in circles) circle.X += _absMinX;
            }
        }
        /// <summary>
        /// "Moves" Circles to their original position.
        /// </summary>
        /// <param name="circles">An array of Circles</param>
        private static void ResetCoordsFrom0(params Circle[] circles)
        {
            // Resetting coordinates to original value
            if (_minY >= 0)
            {
                foreach (var circle in circles) circle.Y += _absMinY;
            }
            else
            {
                foreach (var circle in circles) circle.Y -= _absMinY;
            }
            if (_minX >= 0)
            {
                foreach (var circle in circles) circle.X += _absMinX;
            }
            else
            {
                foreach (var circle in circles) circle.X -= _absMinX;
            }
        }

    }
}
