using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson8
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            int offsetBottom=4;
            int RectanglesCount;
            int windowWidth = ConsIO.WindowWidth;
            int windowHeight = ConsIO.WindowHeight;
            
            Rectangle[] rectangles;
            
            string s = "*** Now you are in Lesson8.Task1 ***\n    Style Coding. Work with Rectangle";
            ConsIO.WriteLine(s);
            ConsIO.Write("How many rectangles do you want to draw?:  ");
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            RectanglesCount = Validators.GetIntPositiveNumber(s);

            rectangles = new Rectangle[RectanglesCount];
            
            ConsIO.WriteLine("\n***  Window dimensions: " + windowWidth + "; " + windowHeight + "  ***\n");

            for (int i = 0; i < RectanglesCount; i++)
            {
                CreateRectangle(ref i, ref rectangles);
                
            }
            ConsIO.Clear();

            Rectangle.LeftOffsetX = 11;
            Rectangle.TopOffsetY = 3;
            Rectangle.OffsetHorizontal = Rectangle.LeftOffsetX + 0;
            Rectangle.OffsetVertical = Rectangle.TopOffsetY + offsetBottom;
            Rectangle.OffsetBottom = offsetBottom;

            ConsIO.WriteLine("\n\n\n");
            foreach (var rect in rectangles)
            {
                ConsIO.WriteLine($"{rect.X},{rect.Y},{rect.Width},{rect.Height}");
            }

            Rectangle.Draw(rectangles);
            
            WhatToDo(ref offsetBottom, ref rectangles);

            ConsIO.ClearBottom(ref offsetBottom);

            ConsIO.ReadLine();
        }

        /// <summary>
        /// Asks what to do next. Text is displayed in the line
        /// "offsetBottom" from the bottom of window.
        /// </summary>
        /// <param name="offsetBottom">Distance (number of lines)</param>
        /// <param name="rectangles">An array of rectangles we work with</param>
        private static void WhatToDo(ref int offsetBottom, ref Rectangle[] rectangles)
        {
            string s;
            int first;
            int second;
            ConsIO.ClearBottom(ref offsetBottom);
            ConsIO.Write($"What to do now? [M]ove rectangle, [R]esize, create [I]ntersected, [S]mallest or [Q]uit?:  ");
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);

            if (s.ToLower() == "m")
            {
                ConsIO.ClearBottom(ref offsetBottom);
                MoveRectangle(ref rectangles);
            }
            else if (s.ToLower() == "r")
            {
                ResizeRectangle(ref rectangles);
                Rectangle.Draw(rectangles);
            }
            else if (s.ToLower() == "i")
            {
                EnterIntPositive("\rEnter number of rectangle a:  ", out first);
                EnterIntPositive("\rEnter number of rectangle b:  ", out second);
                first -= 1;
                second -= 1;
                CreateIntersectedRectangle(first, second, ref rectangles);
                Rectangle.Draw(rectangles);
            }
            else if (s.ToLower() == "s")
            {
                EnterIntPositive("\rEnter number of rectangle a:  ", out first);
                EnterIntPositive("\rEnter number of rectangle b:  ", out second);
                first -= 1;
                second -= 1;
                CreateSmallestRectangle(first, second, ref rectangles);
            }
            
            WhatToDo(ref offsetBottom, ref rectangles);
        }

        /// <summary>
        /// Checks if rectangle "a" intersects with rectangle "b"
        /// and creates rectangle from intersection.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="rects"></param>
        private static void CreateIntersectedRectangle(int a, int b, ref Rectangle[] rects)
        {
            int offsetBottom = Rectangle.OffsetBottom;

            if (rects[a].IntersectsWith(rects[b]))
            {
                ConsIO.Clear();
                ConsIO.SetCursorPosition(0, 0);
                var intersectedRectangle = Rectangle.Intersect(rects[a],rects[b]);
                ConsIO.Write($"Rectangle on intersection of rect {a+1} and {b+1} " +
                                 $"has X: {intersectedRectangle.X}, " +
                                 $"Y: {intersectedRectangle.Y}, " +
                                 $"Width: {intersectedRectangle.Width}, " +
                                 $"Height: {intersectedRectangle.Height}");
                ConsIO.SetCursorPosition(0,0);
                intersectedRectangle.DrawFrom00=true;
                intersectedRectangle.Draw();
            }
            else
            {
                ConsIO.WriteLine("Rectangles are not intersecting. Press 'Enter' key and choose what to do.");
                ConsIO.ReadLine();
            }
            WhatToDo(ref offsetBottom, ref rects);
        }
        
        /// <summary>
        /// Checks smallest rectangle dimensions with our bounds and
        /// creates it if it is inside bounds. If no - asks what to do. 
        /// </summary>
        /// <param name="a">Index of element</param>
        /// <param name="b">Index of element</param>
        /// <param name="rects">An array with rectangles</param>
        private static void CreateSmallestRectangle(int a, int b, ref Rectangle[] rects)
        {
            string s;
            if (Rectangle.IsInWindowSmallestForBoth(ref rects[a], ref rects[b]))
            {
                var smRect = Rectangle.GetSmallestRectangle();
                ConsIO.Clear();
                ConsIO.SetCursorPosition(0, 0);
                ConsIO.Write($"The smallest rectangle for rect {a + 1} and {b + 1} " +
                             $"has X: {smRect.X}, " +
                             $"Y: {smRect.Y}, " +
                             $"Width: {smRect.Width}, " +
                             $"Height: {smRect.Height}");
                ConsIO.SetCursorPosition(0, 0);
                smRect.DrawFrom00 = true;
                smRect.Draw();
            }
            else
            {
                s = $"The smallest rectangle for rect {a + 1} and {b + 1} is bigger of bounds.\nPress 'Enter' key.";
                ConsIO.Write(s);
                ConsIO.ReadLine();
            }
            WhatToDo(ref Rectangle.OffsetBottom, ref rects);
        }

        /// <summary>
        /// Creates new rectangle and checks is it inside our limits of window
        /// </summary>
        /// <param name="i">Index of array element</param>
        /// <param name="rectangles">An array of rectangles we work with</param>
        private static void CreateRectangle(ref int i, ref Rectangle[] rectangles)
        {
            int tempTopLeftX;
            int tempTopLeftY;
            int tempWidth;
            int tempHeight;
            ConsIO.WriteLine($"Enter for rectangle {i + 1}:\n");
            EnterInt("\r top left X: ", out tempTopLeftX);
            EnterInt("\r top left Y: ", out tempTopLeftY);
            EnterIntPositive("\r Width: ", out tempWidth);
            EnterIntPositive("\r Height: ", out tempHeight);
            rectangles[i] = new Rectangle(tempTopLeftX, tempTopLeftY, tempWidth, tempHeight);
            while (WindowChecker.RectanglesAreInWindow(Rectangle.OffsetHorizontal, Rectangle.OffsetVertical, rectangles.Take(i + 1).ToArray()) == false)
            {
                ConsIO.WriteLine($"Current Rectangle {i + 1} is out of our bounds. Try one more time.");
                CreateRectangle(ref i, ref rectangles);
            }
        }

        /// <summary>
        /// Resizes rectangle (and redraws all) after asking number of rectangle,
        /// offsets along X and Y axises. If it will be out of the bounds
        /// you will be asked to set new values before resizing.
        /// </summary>
        /// <param name="rects">An array of rectangles</param>
        private static void ResizeRectangle(ref Rectangle[] rects)
        {
            int i, dX, dY;
            string vertex;
            int lowerBound = rects.GetLowerBound(0) + 1;
            int upperBound = rects.GetUpperBound(0) + 1;
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rEnter number of rectangle you want to Resize:  ", out i);
            i = Validators.GetCorrectIndexInsideBounds(i, ref lowerBound, ref upperBound) - 1;
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);

            vertex = EnterVertex();
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rEnter dX:  ", out dX);
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rEnter dY:  ", out dY);
            rects[i].Resize(vertex, dX, dY);
            while (WindowChecker.RectanglesAreInWindow(Rectangle.OffsetHorizontal, Rectangle.OffsetVertical, rects) == false)
            {
                rects[i].Resize(vertex, -dX, -dY);
                ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
                ConsIO.Write("\rWe are going outside the bounds. Enter new values for ");
                EnterInt("dX:  ",out dX);
                ConsIO.SetCursorPosition(0, ConsIO.WindowHeight - Rectangle.OffsetBottom);
                ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
                EnterInt("  dY:  ", out dY);
                ResizeRectangle(ref rects);
            }
            ConsIO.Clear();
            foreach (var rect in rects)
            {
                ConsIO.WriteLine($"{rect.X},{rect.Y},{rect.Width},{rect.Height}");
            }
            
        }

        /// <summary>
        /// Returns string with correct value that corresponds to
        /// names of vertexes: TL - top left, TR - top right,
        /// BL - bottom left, BR - bottom right.
        /// If entered incorrect value
        /// you will be asked to enter new.
        /// </summary>
        /// <returns></returns>
        private static string EnterVertex()
        {
            string s;
            string[] vertexes = { "TL", "TR", "BL", "BR" };
            ConsIO.Write("\rEnter vertex Top left (TL), Top right (TR)," +
                         "\nBottom left (BL), Bottom right (BR):  ");
            s = ConsIO.ReadLine();
            while (Validators.IsCorrectStringValue(ref s, vertexes) == false)
            {
                ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
                ConsIO.Write("\rEntered incorrect value! Allowed only TL,TR, BL, BR:  ");
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
        /// Moves rectangle (and redraws all) after asking number of rectangle,
        /// offsets along X and Y axises. If it will be out of the bounds
        /// you will be asked to set new values before moving.
        /// </summary>
        /// <param name="rects">An array of rectangles we work with</param>
        private static void MoveRectangle(ref Rectangle[] rects)
        {
            int i, dX, dY;
            int lowerBound = rects.GetLowerBound(0) + 1;
            int upperBound = rects.GetUpperBound(0) + 1;
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rEnter number of rectangle you want to Move:  ", out i);
            i = Validators.GetCorrectIndexInsideBounds(i, ref lowerBound, ref upperBound) - 1;
            
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rFor rectangle you want to move enter dX:  ", out dX);
            ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
            EnterInt("\rEnter dY:  ", out dY);
            rects[i].Move(dX, dY);
            while (WindowChecker.RectanglesAreInWindow(Rectangle.OffsetHorizontal, Rectangle.OffsetVertical, rects) == false)
            {
                rects[i].Move(-dX, -dY);
                ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
                EnterInt("\rWe are going outside the bounds. Enter new values for dX:  ", out dX);
                ConsIO.SetCursorPosition(0, ConsIO.WindowHeight - Rectangle.OffsetBottom);
                ConsIO.ClearBottom(ref Rectangle.OffsetBottom);
                EnterInt("\r  for dY:  ", out dY);
                MoveRectangle(ref rects);
            }
            ConsIO.Clear();
            foreach (var rect in rects)
            {
                ConsIO.WriteLine($"{rect.X},{rect.Y},{rect.Width},{rect.Height}");
            }
        }
    }

    public static partial class WindowChecker
    {
        /// <summary>
        /// Checks if rectangle is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="rec"></param>
        /// <returns></returns>
        public static bool RectangleIsInWindow(int offsetHorizontal, int offsetVertical, Rectangle rec)
        {
            return (rec.Height < ConsIO.WindowHeight - offsetVertical) && (rec.Width < ConsIO.WindowWidth - offsetHorizontal);
        }

        /// <summary>
        /// Checks if rectangle is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static bool RectangleIsInWindow(int offsetHorizontal, int offsetVertical, int width, int height)
        {
            return (height < ConsIO.WindowHeight - offsetVertical) && (width < ConsIO.WindowWidth - offsetHorizontal);
        }

        /// <summary>
        /// Checks if all rectangles are inside current Window (based on coordinates)
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="rects">An array of rectangles</param>
        /// <returns></returns>
        public static bool RectanglesAreInWindow(int offsetHorizontal, int offsetVertical, params Rectangle[] rects)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            Rectangle.GetBounds(ref x1, ref x2, ref y1, ref y2, rects);
            int tempWidth = x2 - x1;
            int tempHeight = y2 - y1;
            return (tempHeight < ConsIO.WindowHeight - offsetVertical) && (tempWidth < ConsIO.WindowWidth - offsetHorizontal);
        }
    }

    public abstract class Figure : IDrawable, IMovable
    {
        public void Draw() { }

        public void Move() { }
    }

    public class Rectangle : Figure
    {
        public bool DrawFrom00;
        public static int LeftOffsetX;
        public static int TopOffsetY;
        public static int OffsetHorizontal;
        public static int OffsetVertical;
        public static int OffsetBottom;
        public static readonly Rectangle Empty;

        private static int _minY;
        private static int _absMinY;
        private static int _minX;
        private static int _absMinX;
        
        #region For Smallest rectangle from Both rectangles

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
        private static int _smWidth;
        private static int _smHeight;
        private static int _smArea;

        #endregion

        private int x;
        private int y;
        private int width;
        private int height;



        #region Properties

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets or sets width of the rectangular
        /// region defined by this "Rectangle"
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Gets or sets height of the rectangular
        /// region defined by this "Rectangle"
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Gets the x-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int Left
        {
            get { return X; }
        }

        /// <summary>
        /// Gets the y-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int Top
        {
            get { return Y; }
        }

        /// <summary>
        /// Gets the x-coordinate of the lower-right corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int Right
        {
            get { return X + Width; }
        }

        /// <summary>
        /// Gets the y-coordinate of the lower-right corner
        /// of the rectangular region defined by this "Rectangle"
        /// </summary>
        public int Bottom
        {
            get { return Y + Height; }
        }

        /// <summary>
        /// Gets area of rectangle
        /// </summary>
        public int Area
        {
            get { return Width * Height; }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the "Rectangle" class with the
        /// specified location and size.
        /// </summary>
        /// <param name="x">Left X</param>
        /// <param name="y">Top Y</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a new "Rectangle" with the specified location and size.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        public static Rectangle FromLTRB(int left, int top, int right, int bottom)
        {
            return new Rectangle(left,
                top,
                right - left,
                bottom - top);
        }

        /// <summary>
        /// Moves rectangle.
        /// </summary>
        /// <param name="dX">Distance to move along X</param>
        /// <param name="dY">Distance to move along Y</param>
        public void Move(int dX, int dY = 0)
        {
            X += dX;
            Y += dY;
        }

        /// <summary>
        /// Tests whether "obj" is a "Rectangle" with 
        /// the same location and size of this Rectangle.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
                return false;

            Rectangle comp = (Rectangle)obj;

            return (comp.X == X) &&
                   (comp.Y == Y) &&
                   (comp.Width == Width) &&
                   (comp.Height == Height);
        }

        /// <summary>
        /// Determines if the rectangular region represented by 
        /// "rect" is entirely contained within the
        /// rectangular region represented by this "Rectangle".
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool Contains(Rectangle rect)
        {
            return (Left < rect.Left) &&
                   ((rect.Left + rect.Width) < (Left + Width)) &&
                   (Bottom > rect.Bottom) &&
                   ((rect.Bottom + rect.Height) < (Bottom + Height));
        }

        /// <summary>
        /// Creates a Rectangle that represents the intersection between this Rectangle and rect.
        /// </summary>
        /// <param name="rect"></param>
        public void Intersect(Rectangle rect)
        {
            Rectangle result = Intersect(rect, this);

            X = result.X;
            Y = result.Y;
            Width = result.Width;
            Height = result.Height;
        }

        /// <summary>
        /// Creates a rectangle that represents the intersection between a
        ///   and b. If there is no intersection, null is returned.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            var x1 = Math.Max(a.X, b.X);
            var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Max(a.Y, b.Y);
            var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1
                && y2 >= y1)
            {

                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }

            return Empty;
        }

        /// <summary>
        /// Determines if this rectangle intersects with rect.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public bool IntersectsWith(Rectangle rect)
        {
            return (rect.X < X + Width) &&
                   (X < (rect.X + rect.Width)) &&
                   (rect.Y < Y + Height) &&
                   (Y < rect.Y + rect.Height);
        }

        /// <summary>
        /// Creates a rectangle that represents the union between a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            int x1 = Math.Min(a.X, b.X);
            int x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            int y1 = Math.Min(a.Y, b.Y);
            int y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        /// <summary>
        /// Creates a rectangle that represents the union between a and b.
        /// </summary>
        /// <param name="rects"></param>
        /// <returns></returns>
        public static Rectangle UnionFew(params Rectangle[] rects)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            GetBounds(ref x1, ref x2, ref y1, ref y2, rects);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }


        #region Smallest Rectangle for two rectangles

        /// <summary>
        /// Returns new smallest rectangle for two rectangles.
        /// Call this method only after using "IsInWindowSmallestForBoth".
        /// </summary>
        /// <returns></returns>
        public static Rectangle GetSmallestRectangle()
        {
            return new Rectangle(0, 0, _smWidth, _smHeight);
        }

        /// <summary>
        /// Checks if smallest rectangle for both rectangles
        /// will be in our bounds (window).
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        /// <returns></returns>
        public static bool IsInWindowSmallestForBoth(ref Rectangle rect1, ref Rectangle rect2)
        {
            SetRectsBiggerSidesToWidth(ref rect1, ref rect2);
            CheckCasesForSmallestRect();
            // Checking if we can draw rectangle inside ConsIO.Window
            if (WindowChecker.RectangleIsInWindow(OffsetHorizontal, OffsetVertical, _smWidth, _smHeight))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets biggest sides of both rectangles to width
        /// to make possible creation of smallest rectangle.
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        private static void SetRectsBiggerSidesToWidth(ref Rectangle rect1, ref Rectangle rect2)
        {
            _tempValue = rect1.Width;
            if (_tempValue >= rect1.Height)
            {
                _width1 = _tempValue;
                _height1 = rect1.Height;
            }
            else
            {
                _height1 = _tempValue;
                _width1 = rect1.Height;
            }

            _tempValue = rect2.Width;
            if (_tempValue >= rect2.Height)
            {
                _width2 = _tempValue;
                _height2 = rect2.Height;
            }
            else
            {
                _height2 = _tempValue;
                _width2 = rect2.Height;
            }
        }

        /// <summary>
        /// Checks different cases of rectangles placement
        /// to find the smallest rectangle by sides and area.
        /// </summary>
        private static void CheckCasesForSmallestRect()
        {
            // Bottom (first) rectangle will be with bigger width
            if (_width1 >= _width2)
            {
                _firstWidth = _width1;
                _firstHeight = _height1;
                _secondWidth = _width2;
                _secondHeight = _height2;
            }
            else
            {
                _firstWidth = _width2;
                _firstHeight = _height2;
                _secondWidth = _width1;
                _secondHeight = _height1;
            }
            _tempWidth = _firstWidth;
            _tempHeight = _firstHeight + _secondHeight;
            _tempArea = _tempHeight * _tempWidth;

            // Make assumption that first case is the smallest rectangle.
            _smArea = _tempArea;
            _smWidth = _tempWidth;
            _smHeight = _tempHeight;

            // Case 2
            _tempHeight = _firstHeight + _secondWidth;
            _tempArea = _tempHeight * _tempWidth;

            // Checking if Case 2 is worst.
            if (_smArea > _tempArea)
            {
                _smHeight = _tempHeight;
                _smArea = _tempArea;
            }

            // Case 3.
            _tempWidth = _firstWidth + _secondWidth;
            _tempHeight = _firstHeight >= _secondHeight ? _firstHeight : _secondHeight;
            _tempArea = _tempHeight * _tempWidth;

            // Checking if Case 3 is worst.
            if (_smArea > _tempArea)
            {
                _smWidth = _tempWidth;
                _smHeight = _tempHeight;
                _smArea = _tempArea;
            }
            // Case 4.
            _tempWidth = _firstWidth + _secondHeight;
            _tempHeight = _firstHeight >= _secondWidth ? _firstHeight : _secondWidth;
            _tempArea = _tempHeight * _tempWidth;

            // Checking if Case 4 is worst.
            if (_smArea > _tempArea)
            {
                _smWidth = _tempWidth;
                _smHeight = _tempHeight;
                _smArea = _tempArea;
            }
        }

        #endregion


        /// <summary>
        /// Changes dimensions of rectangle for specified values.
        /// </summary>
        /// <param name="vertex">"TL" - top left, "TR" - top right,
        /// "BL" - bottom left, "BR" - bottom right</param>
        /// <param name="dX">Along X</param>
        /// <param name="dY">Along Y</param>
        public void Resize(string vertex, int dX, int dY)
        {
            if (vertex.ToLower() == "tl")
            {
                X += dX;
                Y += dY;
            }
            else if (vertex.ToLower() == "tr")
            {
                Width += dX;
                Y += dY;
            }
            else if (vertex.ToLower() == "bl")
            {
                X += dX;
                Height += dY;
            }
            else if (vertex.ToLower() == "br")
            {
                Width += dX;
                Height += dY;
            }
        }


        /// <summary>
        /// Gets bounds of the space needed for entered rectangles
        /// </summary>
        /// <param name="x1">Left</param>
        /// <param name="x2">Right</param>
        /// <param name="y1">Top in console window (y1 smaller y2)</param>
        /// <param name="y2">Bottom in console window</param>
        /// <param name="rects"></param>
        public static void GetBounds(ref int x1, ref int x2, ref int y1, ref int y2, params Rectangle[] rects)
        {
            int[] minsY = new int[rects.Length];
            int[] minsX = new int[rects.Length];
            int[] maxsY = new int[rects.Length];
            int[] maxsX = new int[rects.Length];

            for (int i = 0; i < rects.Length; i++)
            {
                minsX[i] = rects[i].X;
                minsY[i] = rects[i].Y;
                maxsX[i] = rects[i].X + rects[i].Width;
                maxsY[i] = rects[i].Y + rects[i].Height;
            }

            x1 = MyMath.Min(minsX);
            x2 = MyMath.Max(maxsX);
            y1 = MyMath.Min(minsY);
            y2 = MyMath.Max(maxsY);
        }


        #region Drawing rectangle(s)

        /// <summary>
        /// Draws only current Rectangle.
        /// </summary>
        public new void Draw()
        {
            // Drawing in the current view
            if (DrawFrom00)
            {
                DrawInView(this);
            }
            // Drawing in the last line
            else
            {
                DrawInLastLine(this);
            }
        }
        /// <summary>
        /// Draws specified rectangle in the view (cursor at 0,0 + offsets)
        /// </summary>
        /// <param name="rect"></param>
        private void DrawInView(Rectangle rect)
        {
            for (int i = 0; i <= rect.Height; i++)
            {
                for (int j = 0; j <= rect.Width; j++)
                {
                    if (i == 0)
                    {
                        ConsIO.SetCursorPosition(LeftOffsetX + rect.X + j, TopOffsetY + rect.Y + i);
                        if (j == 0)
                        {
                            ConsIO.Write("┌"); //"┌" "╔"
                        }
                        if (j == rect.Width)
                        {
                            ConsIO.Write("┐"); //"┐" "╗"
                        }
                        else
                        {
                            ConsIO.Write("─"); //"─" "═"
                        }
                    }
                    else if (i == rect.Height)
                    {
                        ConsIO.SetCursorPosition(LeftOffsetX + rect.X + j, TopOffsetY + rect.Y + i);
                        if (j == 0) ConsIO.Write("└"); //"└" "╚"
                        if (j == rect.Width) ConsIO.Write("┘"); //"┘" "╝"
                        else ConsIO.Write("─"); //"─" "═"
                    }
                    else
                    {
                        if (j == 0)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + rect.X + j, TopOffsetY + rect.Y + i);
                            ConsIO.Write("│"); //"│" "║"
                        }
                        if (j == rect.Width)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + rect.X + j, TopOffsetY + rect.Y + i);
                            ConsIO.Write("│"); //"│" "║"
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draws specified rectangle in the last line of window
        /// </summary>
        /// <param name="rect"></param>
        private void DrawInLastLine(Rectangle rect)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < rect.Height; j++)
            {
                for (var i = 0; i < rect.Width; i++)
                {
                    if (j == 0)
                    {

                        if (i == 0) sb.Append("┌"); //"┌" "╔"
                        if (i == rect.Width - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                        else sb.Append("─"); //"─" "═"
                    }
                    else if (j == rect.Height - 1)
                    {
                        if (i == 0) sb.Append("└"); //"└" "╚"
                        if (i == rect.Width - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                        else sb.Append("─"); //"─" "═"
                    }
                    else
                    {
                        if (i == 0) sb.Append("│"); //"│" "║"
                        if (i == rect.Width - 1) sb.Append("│" + "\n"); //"│" "║"
                        else sb.Append(" ");
                    }
                }
            }
            string s = $"Drawing Rectangle: {rect.X}, {rect.Y}; {rect.X - rect.Right}, {rect.Bottom}";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Draws every rectangle from array
        /// </summary>
        /// <param name="rects"></param>
        public static void Draw(params Rectangle[] rects)
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            int[] minsY = new int[rects.Length];
            int[] minsX = new int[rects.Length];

            for (int i = 0; i < rects.Length; i++)
            {
                minsY[i] = rects[i].Y;
                minsX[i] = rects[i].X;
            }
            _minY = MyMath.Min(minsY);
            _absMinY = Math.Abs(_minY);
            _minX = MyMath.Min(minsX);
            _absMinX = Math.Abs(_minX);

            // Setting coordinates to start from 0,0
            SetCoordsTo0(rects);
            GetBounds(ref x1, ref x2, ref y1, ref y2, rects);
            // Drawing rectangles
            foreach (var rect in rects)
            {
                rect.DrawFrom00 = true;
                rect.Draw();
            }
            // Resetting coordinates to original value
            ResetCoordsFrom0(rects);
            ConsIO.SetCursorPosition(0, y2 + 1);
        }

        #endregion


        /// <summary>
        /// "Moves" rectangles for drawing them from 0,0 of outstream.
        /// </summary>
        /// <param name="rects">An array of rectangles</param>
        private static void SetCoordsTo0(params Rectangle[] rects)
        {
            // Setting coordinates to start from 0,0
            if (_minY >= 0)
            {
                foreach (var rect in rects) rect.Y -= _absMinY;
            }
            else
            {
                foreach (var rect in rects) rect.Y += _absMinY;
            }
            if (_minX >= 0)
            {
                foreach (var rect in rects) rect.X -= _absMinX;
            }
            else
            {
                foreach (var rect in rects) rect.X += _absMinX;
            }
        }
        /// <summary>
        /// "Moves" rectangles to their original position.
        /// </summary>
        /// <param name="rects">An array of rectangles</param>
        private static void ResetCoordsFrom0(params Rectangle[] rects)
        {
            // Resetting coordinates to original value
            if (_minY >= 0)
            {
                foreach (var rect in rects) rect.Y += _absMinY;
            }
            else
            {
                foreach (var rect in rects) rect.Y -= _absMinY;
            }
            if (_minX >= 0)
            {
                foreach (var rect in rects) rect.X += _absMinX;
            }
            else
            {
                foreach (var rect in rects) rect.X -= _absMinX;
            }
        }

    }
}
