using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;
using TestProject.TaskLibrary.Tasks.Lesson4;

namespace TestProject.TaskLibrary.Tasks.Lesson8
{
    public class OptTask1 : IRunnable
    {
        public void Run()
        {
            int leftOffsetX;
            int topOffsetY;
            int OffsetBottom=4;
            int RectanglesCount;
            int windowWidth = ConsIO.WindowWidth;
            int windowHeight = ConsIO.WindowHeight;
            int[] tempTopLeftX, tempTopLeftY, tempWidth, tempHeight;
            //Parallelepiped[] parallelepipeds;
            int xBoundLeft = 0, xBoundRight = 0, yBoundTop = 0, yBoundBottom = 0;
            int dX, dY;
            int index;

            int tempX, tempY, tempW, tempH;

            string s = "*** Now you are in Lesson8.OptTask1 ***\n    Draw Parallelepiped";
            ConsIO.WriteLine(s);
            //ConsIO.Write("How many rectangles do you want to draw?:  ");
            //s = ConsIO.ReadLine();
            //ConsIO.CheckForExitTask(ref s);
            //RectanglesCount = GetIntPositiveNumber(s);

            //tempTopLeftX = new int[RectanglesCount];
            //tempTopLeftY = new int[RectanglesCount];
            //tempWidth = new int[RectanglesCount];
            //tempHeight = new int[RectanglesCount];
            //parallelepipeds = new Parallelepiped[RectanglesCount];

            ConsIO.WriteLine("\n***  Window dimensions: " + windowWidth + "; " + windowHeight + "  ***\n");

            //for (int i = 0; i < RectanglesCount; i++)
            //{
            //    Parallelepiped.Create(ref i, ref tempTopLeftX[i], ref tempTopLeftY[i], ref tempWidth[i],
            //        ref tempHeight[i], ref parallelepipeds);
                
            //}

            
            Parallelepiped par = new Parallelepiped(0, 0, 0, 10 ,10, 10);

            ConsIO.Clear();

            Parallelepiped.LeftOffsetX = 11;
            Parallelepiped.TopOffsetY = 3;
            Parallelepiped.OffsetHorizontal = Parallelepiped.LeftOffsetX + 0;
            Parallelepiped.OffsetVertical = Parallelepiped.TopOffsetY + OffsetBottom;
            Parallelepiped.OffsetBottom = OffsetBottom;

            ConsIO.WriteLine("\n\n\n");
            //foreach (var rect in parallelepipeds)
            {
                ConsIO.WriteLine($"{par.X},{par.Y},{par.Z},{par.Width},{par.Length},{par.Height}");
            }
            par.DrawFrom00 = true;
            par.Draw();

            //Parallelepiped.Draw(parallelepipeds);
            
            //WhatToDo(ref OffsetBottom, ref parallelepipeds);

            ConsIO.ClearBottom(ref OffsetBottom);

            //ConsIO.Clear();

            ConsIO.ReadLine();

            
        }


        private static void WhatToDo(ref int offsetBottom, ref Parallelepiped[] parallelepipeds)
        {
            string s;
            int index;
            int dX, dY;
            ConsIO.ClearBottom(ref offsetBottom);
            ConsIO.Write($"What to do now? [M]ove rectangle, [R]esize or [Q]uit?:  ");
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);

            if (s.ToLower() == "m")
            {
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\rEnter number of rectangle:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                index = Task1.GetIntPositiveNumber(s);
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\rEnter values for dX:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                dX = Task1.GetIntNumber(s);
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\r  for dY:");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                dY = Task1.GetIntNumber(s);
                //Parallelepiped.Move(index - 1, ref parallelepipeds, dX, dY);
            }
            else if (s.ToLower() == "r")
            {
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\rEnter number of rectangle:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                index = Task1.GetIntPositiveNumber(s);
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\rEnter values for dX:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                dX = Task1.GetIntNumber(s);
                ConsIO.ClearBottom(ref offsetBottom);
                ConsIO.Write("\r  for dY:");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                dY = Task1.GetIntNumber(s);
                //Parallelepiped.Resize(index - 1, ref parallelepipeds, dX, dY);
            }
            
            
            WhatToDo(ref offsetBottom, ref parallelepipeds);
        }

        
        public static class WindowChecker
        {
            /// <summary>
            /// Checks if rectangle is inside current Window
            /// </summary>
            /// <param name="offsetHorizontal"></param>
            /// <param name="offsetVertical"></param>
            /// <param name="rec"></param>
            /// <returns></returns>
            public static bool RectangleIsInWindow(int offsetHorizontal, int offsetVertical, Parallelepiped rec)
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
            public static bool RectanglesAreInWindow(int offsetHorizontal, int offsetVertical, params Parallelepiped[] rects)
            {
                int x1 = 0;
                int x2 = 0;
                int y1 = 0;
                int y2 = 0;
                
                //Parallelepiped.GetBounds(ref x1, ref x2, rects);
                int tempWidth = x2-x1;
                int tempHeight = y2-y1;
                return (tempHeight < ConsIO.WindowHeight - offsetVertical) && (tempWidth < ConsIO.WindowWidth - offsetHorizontal);
            }
        }
        
        public class Parallelepiped : IDrawable
        {
            public bool DrawFrom00;
            public static int LeftOffsetX = 0;
            public static int TopOffsetY = 0;
            public static int OffsetHorizontal = 0;
            public static int OffsetVertical = 0;
            public static int OffsetBottom;
            public static readonly Parallelepiped Empty = new Parallelepiped();

            private static int _xBoundLeft = 0, _xBoundRight = 0, _yBoundTop = 0, _yBoundBottom = 0;
            private static int _minY;
            private static int _absMinY;
            private static int _minX;
            private static int _absMinX;
            private static Parallelepiped[] _tempRects;

            private int x;
            private int y;
            private int z;
            private int width;
            private int height;
            private int length;

            #region For Smallest rectangle from Both rectangles

            private static int _width1;
            private static int _height1;
            private static int _width2;
            private static int _height2;
            private static int _area1;
            private static int _area2;
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
            /// Gets or sets the z-coordinate of the upper-left corner
            /// of the rectangular region defined by this "Rectangle"
            /// </summary>
            public int Z
            {
                get { return z; }
                set { z = value; }
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
            /// Gets or sets length of the rectangular
            /// region defined by this "Parallelepiped"
            /// </summary>
            public int Length
            {
                get { return length; }
                set { length = value; }
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

            /*
            /// <summary>
            /// Gets area of rectangle
            /// </summary>
            public int Area
            {
                get { return Width * Height; }
            }
            */

            #endregion




            /// <summary>
            /// Initializes a new blank instance of the "Rectangle" class
            /// </summary>
            private Parallelepiped() { }

            /// <summary>
            /// Initializes a new instance of the "Parallelepiped" class with the
            /// specified location and size.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="z"></param>
            /// <param name="width">Along X</param>
            /// <param name="length">Along Y</param>
            /// <param name="height">Along Z</param>
            public Parallelepiped(int x, int y, int z, int width, int length, int height)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.width = width;
                this.height = height;
                this.length = length;
            }

            /// <summary>
            /// Creates a new "Parallelepiped" with the specified location and size.
            /// </summary>
            /// <param name="left">X1</param>
            /// <param name="top">Y1</param>
            /// <param name="start">Z1</param>
            /// <param name="right">X2</param>
            /// <param name="bottom">Y2</param>
            /// <param name="end">Z2</param>
            /// <returns></returns>
            public static Parallelepiped FromLTRB(int left, int top, int start, int right, int bottom, int end)
            {
                return new Parallelepiped(left,
                    top,
                    start,
                    right - left,
                    bottom - top,
                    end-start);
            }

            
            /// <summary>
            /// Gets bounds of the space needed for entered rectangles
            /// </summary>
            /// <param name="x1">Left</param>
            /// <param name="x2">Right</param>
            /// <param name="y1">Top in console window (y1 smaller y2)</param>
            /// <param name="y2">Bottom in console window</param>
            /// <param name="rects"></param>
            public static void GetBounds(ref int width, ref int height, Parallelepiped par)
            {
                width = par.Width + par.Height;
                height = par.Length + par.Height;
            }

            #region Drawing parallelepiped

            /// <summary>
            /// Draws only current Rectangle.
            /// </summary>
            public void Draw()
            {
                // Drawing in the current view
                if (DrawFrom00)
                {
                    DrawInView(this);
                }
                // Drawing in the last line
                else
                {
                    //DrawInLastLine(this);
                }
            }
            /// <summary>
            /// Draws specified rectangle in the view (cursor at 0,0 + offsets)
            /// </summary>
            /// <param name="par"></param>
            private void DrawInView(Parallelepiped par)
            {
                DrawOnStart(par, LeftOffsetX+Height, TopOffsetY);
                DrawHeight(par);
                DrawOnEnd(par);

                //for (int i = 0; i <= par.Height; i++)
                //{
                //    for (int j = 0; j <= par.Width; j++)
                //    {
                //        if (i == 0)
                //        {
                //            ConsIO.SetCursorPosition(LeftOffsetX + par.X + j, TopOffsetY + par.Y + i);
                //            if (j == 0)
                //            {
                //                ConsIO.Write("┌"); //"┌" "╔"
                //            }
                //            if (j == par.Width )
                //            {
                //                ConsIO.Write("┐"); //"┐" "╗"
                //            }
                //            else
                //            {
                //                ConsIO.Write("─"); //"─" "═"
                //            }
                //        }
                //        else if (i == par.Height )
                //        {
                //            ConsIO.SetCursorPosition(LeftOffsetX + par.X + j, TopOffsetY + par.Y + i);
                //            if (j == 0) ConsIO.Write("└"); //"└" "╚"
                //            if (j == par.Width ) ConsIO.Write("┘"); //"┘" "╝"
                //            else ConsIO.Write("─"); //"─" "═"
                //        }
                //        else
                //        {
                //            if (j == 0)
                //            {
                //                ConsIO.SetCursorPosition(LeftOffsetX + par.X + j, TopOffsetY + par.Y + i);
                //                ConsIO.Write("│"); //"│" "║"
                //            }
                //            if (j == par.Width )
                //            {
                //                ConsIO.SetCursorPosition(LeftOffsetX + par.X + j, TopOffsetY + par.Y + i);
                //                ConsIO.Write("│"); //"│" "║"
                //            }
                //        }
                //    }
                //}
            }

            private void DrawOnStart(Parallelepiped par, int tempOffsetX, int tempOffsetY)
            {
                for (int i = 0; i <= par.Length; i++)
                {
                    for (int j = 0; j <= par.Width; j++)
                    {
                        if (i == 0)
                        {
                            ConsIO.SetCursorPosition(tempOffsetX + j, tempOffsetY + i);
                            if (j == 0)
                            {
                                ConsIO.Write("┌"); //"┌" "╔"
                            }
                            if (j == par.Width)
                            {
                                ConsIO.Write("┐"); //"┐" "╗"
                            }
                            else
                            {
                                ConsIO.Write("─"); //"─" "═"
                            }
                        }
                        else if (i == par.Length)
                        {
                            ConsIO.SetCursorPosition(tempOffsetX + j, tempOffsetY + i);
                            if (j == 0) ConsIO.Write("+"); //"└" "╚"
                            if (j == par.Width) ConsIO.Write("+"); //"┘" "╝"
                            else ConsIO.Write("-"); //"─" "═"
                        }
                        else
                        {
                            if (j == 0)
                            {
                                ConsIO.SetCursorPosition(tempOffsetX + j, tempOffsetY + i);
                                ConsIO.Write("|"); //"│" "║"
                            }
                            if (j == par.Width)
                            {
                                ConsIO.SetCursorPosition(tempOffsetX + j, tempOffsetY + i);
                                ConsIO.Write("│"); //"│" "║"
                            }
                        }
                    }
                }
            }

            private void DrawOnEnd(Parallelepiped par)
            {
                for (int i = 0; i <= par.Length; i++)
                {
                    for (int j = 0; j <= par.Width; j++)
                    {
                        if (i == 0)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + Height + i);
                            if (j == 0)
                            {
                                ConsIO.Write("┌"); //"┌" "╔"
                            }
                            if (j == par.Width)
                            {
                                ConsIO.Write("┐"); //"┐" "╗"
                            }
                            else
                            {
                                ConsIO.Write("─"); //"─" "═"
                            }
                        }
                        else if (i == par.Length)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + Height + i);
                            if (j == 0) ConsIO.Write("└"); //"└" "╚"
                            if (j == par.Width) ConsIO.Write("┘"); //"┘" "╝"
                            else ConsIO.Write("─"); //"─" "═"
                        }
                        else
                        {
                            if (j == 0)
                            {
                                ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + Height + i);
                                ConsIO.Write("│"); //"│" "║"
                            }
                            if (j == par.Width)
                            {
                                ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + Height + i);
                                ConsIO.Write("│"); //"│" "║"
                            }
                        }
                    }
                }
            }

            private void DrawHeight(Parallelepiped par)
            {
                for (int i = 1; i < par.Height; i++)
                {
                    ConsIO.SetCursorPosition(LeftOffsetX + par.Height -i, TopOffsetY + par.Y + i);
                    ConsIO.Write("/");
                    ConsIO.SetCursorPosition(LeftOffsetX + par.Height + par.Width - i, TopOffsetY + par.Y + i);
                    ConsIO.Write("/");
                    ConsIO.SetCursorPosition(LeftOffsetX + par.Height - i, TopOffsetY + par.Y + par.Length + i);
                    ConsIO.Write("/");
                    ConsIO.SetCursorPosition(LeftOffsetX + par.Height + par.Width - i, TopOffsetY + par.Y + par.Length + i);
                    ConsIO.Write("/");
                }
            }
            
            #endregion
        }

    }
}
