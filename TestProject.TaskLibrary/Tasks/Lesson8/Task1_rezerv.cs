using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson8
{
    public class Task1_rezerv: IRunnable
    {
        //public static int WindowWidth = ConsIO.WindowWidth;
        public void Run()
        {
            #region Fields

            int rectCount;
            int windowWidth = ConsIO.WindowWidth;
            int windowHeight = ConsIO.WindowHeight;
            int tempTX1, tempTY1, tempBX1, tempBY1;
            int tempTX2, tempTY2, tempBX2, tempBY2;

            #region fields for rectangle created by Intersection

            int TopLeftX;
            int TopLeftY;
            int BottomRightX;
            int BottomRightY;

            #endregion

            #endregion
            
            string s = "*** Now you are in Lesson8.Task1 ***\n Drawing rectangles and modifying them.";
            ConsIO.WriteLine(s);

            ConsIO.WriteLine("\n" +
                             "    Y ^\n" +
                             "      |         \n" +
                             "      |         \n" +
                             "      |         \n" +
                             "      +-----+   \n" +
                             "   +--+----+|   \n" +
                             "   |  +----++-----------> X \n" +
                             "   |       |    \n" +
                             "   |       |    \n" +
                             "   +-------+    \n" +
                             "                \n" +
                             "             \n");
            

            ConsIO.WriteLine("\n" +
                             "    Y ^\n" +
                             "      |         \n" +
                             "      ┌───────┐ \n" +
                             "     /|      /│ \n" +
                             "    / |     / │ \n" +
                             "   +=======+  │ \n" +
                             "   │  +----│--+---------> X \n" +
                             "   │ /     │ /  \n" +
                             "   │/      │/   \n" +
                             "   +=======+    \n" +
                             "  /             \n" +
                             " /           \n" +
                             "\\/ Z");
            /*ConsIO.WriteLine("\nHow many rectangles do you want to create?");
            //rectCount = 0;
            s = ConsIO.ReadLine();
            rectCount= GetQuantity(s);*/
            ConsIO.ReadLine();
            
            ConsIO.WriteLine("Window dimensions: "+windowWidth + "; " + windowHeight + "\n");
            
            ConsIO.WriteLine("Enter for rectangle 1:\n top left X:");
            Int32.TryParse(ConsIO.ReadLine(),out tempTX1);
            ConsIO.WriteLine(" top left Y:");
            Int32.TryParse(ConsIO.ReadLine(), out tempTY1);
            ConsIO.WriteLine(" bottom right X:");
            Int32.TryParse(ConsIO.ReadLine(), out tempBX1);
            ConsIO.WriteLine(" bottom right Y:");
            Int32.TryParse(ConsIO.ReadLine(), out tempBY1);

            ConsIO.WriteLine("Enter for rectangle 2:\n top left X:");
            Int32.TryParse(ConsIO.ReadLine(), out tempTX2);
            ConsIO.WriteLine(" top left Y:");
            Int32.TryParse(ConsIO.ReadLine(), out tempTY2);
            ConsIO.WriteLine(" bottom right X:");
            Int32.TryParse(ConsIO.ReadLine(), out tempBX2);
            ConsIO.WriteLine(" bottom right Y:");
            Int32.TryParse(ConsIO.ReadLine(), out tempBY2);

            /*Rectangle Rec1=new Rectangle(32,10,42,0);
            Rectangle Rec2=new Rectangle(21,5,31,-5);
            */
            Rectangle Rec1 = new Rectangle(tempTX1, tempTY1, tempBX1, tempBY1);
            Rectangle Rec2 = new Rectangle(tempTX2, tempTY2, tempBX2, tempBY2);

            FigureModifier.DrawFigures(Rec1,Rec2);
            //Rec1.Draw();
            ConsIO.ReadLine();

            ConsIO.WriteLine($"Rec1: {Rec1.TopLeftX}, {Rec1.TopLeftY}, {Rec1.BottomRightX}, {Rec1.BottomRightY}");

            //Rec1.CheckIntersection(Rec2) // bool 

            if (IntersectedRectangles.CheckIntersection(Rec1,Rec2)==true)
            {
                IntersectedRectangles.GetIntersectionCoords(Rec1,Rec2, out TopLeftX, out TopLeftY,
                                                    out BottomRightX, out BottomRightY);
                Rectangle IntersectRec = new Rectangle(TopLeftX, TopLeftY, BottomRightX, BottomRightY);
                ConsIO.WriteLine("Rectangles are intersecting.");
                IntersectRec.Draw();
            }
            else
            {
                ConsIO.WriteLine("Rectangles are not intersecting.");
            }

            TopLeftX=0;
            TopLeftY=0;
            BottomRightX=0;
            BottomRightY=0;
            FigureModifier.SortCoords(ref Rec1,ref Rec2);
            SmallestRectangleCoords.RectangleIsInWindow(Rec1, Rec2, ref TopLeftX, ref TopLeftY,
                ref BottomRightX, ref BottomRightY);
            
            ConsIO.WriteLine($"Smallest rectangle coordinates: {TopLeftX}, {TopLeftY}; " +
                             $"{BottomRightX}, {BottomRightY}");
            Rectangle sRec =new SmallestRectangle(TopLeftX,TopLeftY,BottomRightX,BottomRightY);
            FigureModifier.SortCoords(ref sRec);
            sRec.Draw();
            ConsIO.ReadLine();

            ConsIO.WriteLine($"Rec1 Area: {Rec1.Area}");
            FigureModifier.Move(Rec1,5,5);
            ConsIO.WriteLine($"Rec1: {Rec1.TopLeftX}, {Rec1.TopLeftY}, {Rec1.BottomRightX}, {Rec1.BottomRightY}");
            FigureModifier.Resize(Rec1,5,5);
            ConsIO.WriteLine($"Rec1: {Rec1.TopLeftX}, {Rec1.TopLeftY}, {Rec1.BottomRightX}, {Rec1.BottomRightY}");
            
            FigureModifier.DrawFigures(Rec1,Rec2);

            //SmallestRectangleCoords(Rec1, Rec2);

            /*sq.Draw();
            Rectangle rc=new Rectangle();
            rc.Draw();
            */
        }

        /// <summary>
        /// Returns integer quantity >0
        /// </summary>
        /// <param name="s">String to read number(parse) from</param>
        /// <returns></returns>
        private int GetQuantity(string s)
        {
            ConsIO.CheckForExitTask(ref s);
            int value;
            while ((Int32.TryParse(s, out value) == false) || (value<=0))
            {
                ConsIO.WriteLine("Entered incorrect value. Enter only positive integer numbers.");
                s = ConsIO.ReadLine();
                GetQuantity(s);
            }
            return value;
        }
    }

    
    // Class Rectangle  +++
    // 

    // Class SmallestRectangle:Rectangle
    // The smallest rectangle based on previous two rectangles

    // Class IntersectionRectangle:Rectangle    +++
    // Rectangle is the result of intersection of both rectangles.

    // Class RectangleModifier:Rectangle
    // This class can Move rectangle or Change dimensions of rectangle




    /*public abstract class Figure
    {
        public abstract void Draw();

    }*/

    #region Classes

    public class Rectangle : Lesson4.Rectangle
    {
        // constructors
        public Rectangle(int topLeftX,int topLeftY, int bottomRightX, int bottomRightY)
        {

            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
        }

        // properties

        #region Properties

        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }
        public int Width
        {
            get
            {
                if ((BottomRightX - TopLeftX) < 0)
                {
                    return (TopLeftX - BottomRightX);
                }
                else
                {
                    return (BottomRightX - TopLeftX);
                }
            }
        }
        public int Height
        {
            get
            {
                if ((TopLeftY-BottomRightY) < 0)
                {
                    return (BottomRightY - TopLeftY);
                }
                else
                {
                    return (TopLeftY - BottomRightY);
                }
            }
        }

        public int Area
        {
            get { return Width * Height; }
        }
    

        #endregion

        #region Methods

        // methods
        public override void Draw()
        {   //"̸"
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Height; j++)
            {
                for (var i = 0; i < Width; i++)
                {
                    if (j == 0)
                    {
                        if (i == 0) sb.Append("╔"); //"┌"
                        if (i == Width - 1) sb.Append("╗" + "\n"); //"┐"
                        else sb.Append("═"); //"─"
                    }
                    else if (j == Height - 1)
                    {
                        if (i == 0) sb.Append("╚"); //"└"
                        if (i == Width - 1) sb.Append("╝" + "\n"); //"┘"
                        else sb.Append("═"); //"─"
                    }
                    else
                    {
                        if (i == 0) sb.Append("║"); //"│"
                        if (i == Width - 1) sb.Append("║" + "\n"); //"│"
                        else sb.Append(" ");
                    }
                }
            }
            
            string s = $"Drawing Rectangle: {TopLeftX}, {TopLeftY}; {BottomRightX}, {BottomRightY}";
            ConsIO.WriteLine(s);

            ConsIO.WriteLine(sb.ToString());
        }

        public bool HasIntersection(ref Rectangle rec2)
        {
            //#region Fields

            int TopLeftX1;
            int TopLeftY1;
            int BottomRightX1;
            int BottomRightY1;
            int TopLeftX2;
            int TopLeftY2;
            int BottomRightX2;
            int BottomRightY2;
            
            //#endregion
            System.Drawing.Rectangle rect1 =new System.Drawing.Rectangle(this.TopLeftX,this.BottomRightY,this.Width,this.Height);
            rect1.ToString();
            //FigureModifier.SortCoords(ref , ref rec2);

            TopLeftX1 = this.TopLeftX;
            TopLeftY1 = this.TopLeftY;
            BottomRightX1 = this.BottomRightX;
            BottomRightY1 = this.BottomRightY;
            TopLeftX2 = rec2.TopLeftX;
            TopLeftY2 = rec2.TopLeftY;
            BottomRightX2 = rec2.BottomRightX;
            BottomRightY2 = rec2.BottomRightY;
            return false;
        }
        
        #endregion
    }

    public static class MaxMinRectangleCoords
    {
        private static int TempX, TempY;

        #region Max and Min coordinates (in 1 figure)

        public static int MinX(Rectangle rect)
        {
            TempX = rect.TopLeftX;
            if (TempX > rect.BottomRightX) TempX = rect.BottomRightX;
            return TempX;
        }
        public static int MinY(Rectangle rect)
        {
            TempY = rect.TopLeftY;
            if (TempY > rect.BottomRightY) TempY = rect.BottomRightY;
            return TempY;
        }
        public static int MaxX(Rectangle rect)
        {
            TempX = rect.TopLeftX;
            if (TempX < rect.BottomRightX) TempX = rect.BottomRightX;
            return TempX;
        }
        public static int MaxY(Rectangle rect)
        {
            TempY = rect.TopLeftY;
            if (TempY < rect.BottomRightY) TempY = rect.BottomRightY;
            return TempY;
        }

        #endregion
        
        #region Max and Min coordinates (based on 2 figures)
        // Get Max/Min coordinates for New minimal rectangle around two existing (based on Coordinates).
        
        public static int MinX(Rectangle rect1, Rectangle rect2)
        {
            TempX = rect1.TopLeftX;
            if (TempX > rect1.BottomRightX) TempX = rect1.BottomRightX;
            if (TempX > rect2.BottomRightX) TempX = rect2.BottomRightX;
            if (TempX > rect2.TopLeftX) TempX = rect2.TopLeftX;
            return TempX;
        }
        public static int MinY(Rectangle rect1, Rectangle rect2)
        {
            TempY = rect1.TopLeftY;
            if (TempY > rect1.BottomRightY) TempY = rect1.BottomRightY;
            if (TempY > rect2.BottomRightY) TempY = rect2.BottomRightY;
            if (TempY > rect2.TopLeftY) TempY = rect2.TopLeftY;
            return TempY;
        }
        public static int MaxX(Rectangle rect1, Rectangle rect2)
        {
            TempX = rect1.TopLeftX;
            if (TempX < rect1.BottomRightX) TempX = rect1.BottomRightX;
            if (TempX < rect2.BottomRightX) TempX = rect2.BottomRightX;
            if (TempX < rect2.TopLeftX) TempX = rect2.TopLeftX;
            return TempX;
        }
        public static int MaxY(Rectangle rect1, Rectangle rect2)
        {
            TempY = rect1.TopLeftY;
            if (TempY < rect1.BottomRightY) TempY = rect1.BottomRightY;
            if (TempY < rect2.BottomRightY) TempY = rect2.BottomRightY;
            if (TempY < rect2.TopLeftY) TempY = rect2.TopLeftY;
            return TempY;
        }

        #endregion
        
    }

    public abstract class SmallestRectangleCoords
    {
        /*private static int TopLeftX;
        private static int TopLeftY;
        private static int BottomRightX;
        private static int BottomRightY;
        */
        #region Fields

        private static int width1;
        private static int height1;
        private static int width2;
        private static int height2;
        private static int area1;
        private static int area2;
        private static int Width;
        private static int Height;
        private static int Area;

        private static int windowWidth;
        private static int windowHeight;

        //private static int TempX, TempY;
        private static int firstWidth;
        private static int firstHeight;
        private static int secondWidth;
        private static int secondHeight;
        private static int tempValue;
        private static int tempWidth;
        private static int tempHeight;
        private static int tempArea;

        #endregion

        
        #region Methods

        /// <summary>
        /// This method checks if new smallest rectangle is in current window.
        /// The smallest rectangle is based on Dimensions (not coordinates! ) of current rectangles.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        /// <returns></returns>
        public static bool RectangleIsInWindow(object obj1, object obj2, ref int topLeftX, ref int topLeftY, 
                                                    ref int bottomRightX, ref int bottomRightY)
        {
            windowWidth = ConsIO.WindowWidth;
            windowHeight = ConsIO.WindowHeight;

            if (obj1 is Rectangle & obj2 is Rectangle)
            {
                // Setting bigger sides to widths.
                tempValue = ((Rectangle)obj1).Width;
                if (tempValue >= ((Rectangle) obj1).Height)
                {
                    width1 = tempValue;
                    height1 = ((Rectangle)obj1).Height;
                }
                else
                {
                    height1 = tempValue;
                    width1 = ((Rectangle)obj1).Height;
                }

                tempValue = ((Rectangle)obj2).Width;
                if (tempValue >= ((Rectangle)obj2).Height)
                {
                    width2 = tempValue;
                    height2 = ((Rectangle)obj2).Height;
                }
                else
                {
                    height2 = tempValue;
                    width2 = ((Rectangle)obj2).Height;
                }

                area1 = ((Rectangle) obj1).Area;
                area2 = ((Rectangle) obj2).Area;

                // We have few cases to check rectangles to be the smallest.
                // Bottom (first) rectangle will be with bigger width

                #region Cases

                if (width1>=width2)
                {
                    firstWidth = width1;
                    firstHeight = height1;
                    secondWidth = width2;
                    secondHeight = height2;
                }
                else
                {
                    firstWidth = width2;
                    firstHeight = height2;
                    secondWidth = width1;
                    secondHeight = height1;
                }

                tempWidth = firstWidth;
                tempHeight = firstHeight + secondHeight;
                tempArea = tempHeight * tempWidth;

                // Make assumption that first case is the smallest rectangle.
                Area = tempArea;
                Width = tempWidth;
                Height = tempHeight;

                // Case 2
                tempHeight = firstHeight + secondWidth;
                tempArea = tempHeight * tempWidth;

                // Checking if Case 2 is worst.
                if (Area > tempArea)
                {
                    Height = tempHeight;
                    Area = tempArea;
                }

                // Case 3.
                tempWidth = firstWidth + secondWidth;
                tempHeight = firstHeight >= secondHeight ? firstHeight : secondHeight;
                tempArea = tempHeight * tempWidth;

                // Checking if Case 3 is worst.
                if (Area > tempArea)
                {
                    Width = tempWidth;
                    Height = tempHeight;
                    Area = tempArea;
                }
                // Case 4.
                tempWidth = firstWidth + secondHeight;
                tempHeight = firstHeight >= secondWidth ? firstHeight : secondWidth;
                tempArea = tempHeight * tempWidth;

                // Checking if Case 4 is worst.
                if (Area > tempArea)
                {
                    Width = tempWidth;
                    Height = tempHeight;
                    Area = tempArea;
                }

                #endregion

                // Checking if we can draw rectangle inside ConsIO.Window
                if ((windowHeight-5 > Height) & (windowWidth-10 > Width))
                {
                    topLeftX = 0;
                    topLeftY = Height;
                    bottomRightX = Width;
                    bottomRightY = 0;
                    return true;
                }
                else
                {
                    /*
                    topLeftX = 0;
                    topLeftY = 0;
                    bottomRightX = 0;
                    bottomRightY = 0;
                    */
                    ConsIO.WriteLine("The smallest rectangle that includes both previous has dimensions" +
                                     "\ngreater then current window." +
                                     "\nMake smaller rectangles or bigger window.");
                    return false;
                }
            }
            else
            {
                // They are not rectangles
                return false;
            }
        }

        #endregion
        
    }

    public static class IntersectedRectangles
    {
        /* 1) get TopLeftX1, TopLeftY1, BottomRightX1, BottomRightY1 of Rec1
         * 2) get TopLeftX2, TopLeftY2, BottomRightX2, BottomRightY2 of Rec2
         *
         * 3) check ((TopLeftX1<=TopLeftX2<=BottomRightX1) | (TopLeftX2<=TopLeftX1<=BottomRightX2) &&
         *           (TopLeftY1<=TopLeftY2<=BottomRightY1) | (TopLeftY2<=TopLeftY1<=BottomRightY2))
         */

        #region Fields

        private static int topLeftX;
        private static int topLeftY;
        private static int bottomRightX;
        private static int bottomRightY;
        private static int TempX, TempY;

        private static int TopLeftX1;
        private static int TopLeftY1;
        private static int BottomRightX1;
        private static int BottomRightY1;
        private static int TopLeftX2;
        private static int TopLeftY2;
        private static int BottomRightX2;
        private static int BottomRightY2;
        //private static bool IsIntersection=false;

        #endregion
        
        #region Methods

        /*
        /// <summary>
        /// Method SortXY sorts coordinates to real Top and Bottom
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <param name="TX1"></param>
        /// <param name="TY1"></param>
        /// <param name="BX1"></param>
        /// <param name="BY1"></param>
        /// <param name="TX2"></param>
        /// <param name="TY2"></param>
        /// <param name="BX2"></param>
        /// <param name="BY2"></param>
        private static void SortCoords(Rectangle rec1, Rectangle rec2, out int TX1, out int TY1,
                      out int BX1, out int BY1, out int TX2, out int TY2, out int BX2, out int BY2)
        {
            TX1 = MaxMinRectangleCoords.MinX(rec1);
            TY1 = MaxMinRectangleCoords.MaxY(rec1);
            BX1 = MaxMinRectangleCoords.MaxX(rec1);
            BY1 = MaxMinRectangleCoords.MinY(rec1);
            TX2 = MaxMinRectangleCoords.MinX(rec2);
            TY2 = MaxMinRectangleCoords.MaxY(rec2);
            BX2 = MaxMinRectangleCoords.MaxX(rec2);
            BY2 = MaxMinRectangleCoords.MinY(rec2);
        }
        */

        /// <summary>
        /// Method CheckIntersection checks if two rectangles are intersecting. 
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public static bool CheckIntersection(Rectangle rec1, Rectangle rec2)
        {
            FigureModifier.SortCoords(ref rec1, ref rec2);
            
            TopLeftX1 = rec1.TopLeftX;
            TopLeftY1 = rec1.TopLeftY;
            BottomRightX1 = rec1.BottomRightX;
            BottomRightY1 = rec1.BottomRightY;
            TopLeftX2 = rec2.TopLeftX;
            TopLeftY2 = rec2.TopLeftY;
            BottomRightX2 = rec2.BottomRightX;
            BottomRightY2 = rec2.BottomRightY;
            /*TopLeftX1 = MaxMinRectangleCoords.MinX(rec1);
            TopLeftY1 = MaxMinRectangleCoords.MaxY(rec1);
            BottomRightX1 = MaxMinRectangleCoords.MaxX(rec1);
            BottomRightY1 = MaxMinRectangleCoords.MinY(rec1);
            TopLeftX2 = MaxMinRectangleCoords.MinX(rec2);
            TopLeftY2 = MaxMinRectangleCoords.MaxY(rec2);
            BottomRightX2 = MaxMinRectangleCoords.MaxX(rec2);
            BottomRightY2 = MaxMinRectangleCoords.MinY(rec2);
            */
            if (
                (((TopLeftX1 <= TopLeftX2) & (TopLeftX2 <= BottomRightX1)) |
                 ((TopLeftX2 <= TopLeftX1) & (TopLeftX1 <= BottomRightX2))) &&
                (((TopLeftY1 <= TopLeftY2) & (TopLeftY2 <= BottomRightY1)) |
                 ((TopLeftY2 <= TopLeftY1) & (TopLeftY1 <= BottomRightY2)))
                                                                                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void GetIntersectionCoords(Rectangle rec1, Rectangle rec2, out int TopLeftX,
                                out int TopLeftY, out int BottomRightX, out int BottomRightY)
        {
            FigureModifier.SortCoords(ref rec1, ref rec2);
            TopLeftX1 = rec1.TopLeftX;
            TopLeftY1 = rec1.TopLeftY;
            BottomRightX1 = rec1.BottomRightX;
            BottomRightY1 = rec1.BottomRightY;
            TopLeftX2 = rec2.TopLeftX;
            TopLeftY2 = rec2.TopLeftY;
            BottomRightX2 = rec2.BottomRightX;
            BottomRightY2 = rec2.BottomRightY;

            #region Setting X coordinates

            // Setting X coordinates 
            if ((TopLeftX1 <= TopLeftX2) & (BottomRightX2 <= BottomRightX1))
            {
                TopLeftX = TopLeftX2;
                BottomRightX = BottomRightX2;
            }
            else if ((TopLeftX2 <= TopLeftX1) & (BottomRightX1 <= BottomRightX2))
            {
                TopLeftX = TopLeftX1;
                BottomRightX = BottomRightX1;
            }
            else if ((TopLeftX1 <= TopLeftX2) & (TopLeftX2 <= BottomRightX1))
            {
                TopLeftX = TopLeftX2;
                BottomRightX = BottomRightX1;
            }
            else //if ((TopLeftX2 <= TopLeftX1) & (TopLeftX1 <= BottomRightX2))
            {
                TopLeftX = TopLeftX1;
                BottomRightX = BottomRightX2;
            }

            #endregion

            #region Setting Y coordinates

            // Setting Y coordinates
            if ((TopLeftY1 <= TopLeftY2) & (BottomRightY2 <= BottomRightY1))
            {
                TopLeftY = TopLeftY2;
                BottomRightY = BottomRightY2;
            }
            else if ((TopLeftY2 <= TopLeftY1) & (BottomRightY1 <= BottomRightY2))
            {
                TopLeftY = TopLeftY1;
                BottomRightY = BottomRightY1;
            }
            else if ((TopLeftY1 <= TopLeftY2) & (TopLeftY2 <= BottomRightY1))
            {
                TopLeftY = TopLeftY2;
                BottomRightY = BottomRightY1;
            }
            else //if ((TopLeftY2 <= TopLeftY1) & (TopLeftY1 <= BottomRightY2))
            {
                TopLeftY = TopLeftY1;
                BottomRightY = BottomRightY2;
            }

            #endregion
        }


        #endregion
    }


    public class SmallestRectangle: Rectangle
    {
        
        #region Constructors

        // Constructors
        /*private SmallestRectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
            //: base(topLeftX, topLeftY, bottomRightX, bottomRightY) { }
        {

        }
        */

        public SmallestRectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
            :base(topLeftX,topLeftY,bottomRightX, bottomRightY) 
            //: base(GetTopLeftX(Rect1, Rect2), GetTopLeftY(Rect1, Rect2), GetBottomRightX(Rect1, Rect2),
            //    GetBottomRightY(Rect1, Rect2))
        {
            /*topLeftX = MinX(Rect1,Rect2);
            topLeftY = MaxY(Rect1, Rect2);
            bottomRightX = MaxX(Rect1, Rect2);
            bottomRightY = MinY(Rect1, Rect2);
            */
        }
        
        #endregion

        #region Methods

        public override void Draw()
        {

        }
        
        #endregion
    }

    public abstract class FigureModifier
    {
        /// <summary>
        /// Method SortCoords sorts (assigns) coordinates to real Top, Bottom, Left, Right
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <param name="TX1"></param>
        /// <param name="TY1"></param>
        /// <param name="BX1"></param>
        /// <param name="BY1"></param>
        /// <param name="TX2"></param>
        /// <param name="TY2"></param>
        /// <param name="BX2"></param>
        /// <param name="BY2"></param>
        public static void SortCoords(ref Rectangle rec1, ref Rectangle rec2)
        {
            var TX1 = MaxMinRectangleCoords.MinX(rec1);
            var TY1 = MaxMinRectangleCoords.MaxY(rec1);
            var BX1 = MaxMinRectangleCoords.MaxX(rec1);
            var BY1 = MaxMinRectangleCoords.MinY(rec1);
            rec1.TopLeftX = TX1;
            rec1.TopLeftY = TY1;
            rec1.BottomRightX = BX1;
            rec1.BottomRightY = BY1;
            var TX2 = MaxMinRectangleCoords.MinX(rec2);
            var TY2 = MaxMinRectangleCoords.MaxY(rec2);
            var BX2 = MaxMinRectangleCoords.MaxX(rec2);
            var BY2 = MaxMinRectangleCoords.MinY(rec2);
            rec2.TopLeftX = TX2;
            rec2.TopLeftY = TY2;
            rec2.BottomRightX = BX2;
            rec2.BottomRightY = BY2;
        }
        
        /// <summary>
        /// Method SortCoords sorts (assigns) coordinates to real Top, Bottom, Left, Right
        /// </summary>
        /// <param name="rec"></param>
        public static void SortCoords(ref Rectangle rec)
        {
            var TX = MaxMinRectangleCoords.MinX(rec);
            var TY = MaxMinRectangleCoords.MaxY(rec);
            var BX = MaxMinRectangleCoords.MaxX(rec);
            var BY = MaxMinRectangleCoords.MinY(rec);
            rec.TopLeftX = TX;
            rec.TopLeftY = TY;
            rec.BottomRightX = BX;
            rec.BottomRightY = BY;
            
        }
        
        /// <summary>
        /// Moves object (rectangle) on dX (X axis) and dY (Y axis)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        public static void Move(object obj, int dX, int dY)
        {
            if (obj is Rectangle)
            {
                // Checking if we can move rectangle inside space

                // Moving Rectangle
                ((Rectangle) obj).BottomRightX += dX;
                ((Rectangle) obj).TopLeftX += dX;
                ((Rectangle) obj).BottomRightY += dY;
                ((Rectangle) obj).TopLeftY += dY;
                
                //((Rectangle) obj).Draw();
            }

            /*if (obj is Circle)
            {

            }
            */
        }

        /// <summary>
        /// This method checks if we can resize and resizes figure.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        public static void Resize(object obj, int dX, int dY=0)
        {
            if (obj is Rectangle)
            {
                // Checking if we can change rectangle inside space
                
                // Moving Rectangle
                ((Rectangle)obj).BottomRightX += dX;
                ((Rectangle)obj).TopLeftY += dY;
                //((Rectangle)obj).Draw();
            }
        }

        /// <summary>
        /// This method draws 1 or 2 figures inside current window.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void DrawFigures(object obj1, object obj2 = null, bool WithAxes=false)
        {
            int offsetHorizontalLeft=3;
            int offsetBetweenRectangles;
            StringBuilder sb = new StringBuilder();
            // If LeftX1 < LeftX2
            bool obj1IsOnLeft;

            if (obj2 == null)
            {

            }
            else
            {
                
                if (IntersectedRectangles.CheckIntersection(obj1 as Rectangle, obj2 as Rectangle) == false)
                {
                    // Rectangles are not intersecting.
                    // Looking which rectangle has greater Y coordinate.
                    int leftY1 = ((Rectangle) obj1).TopLeftY;
                    int leftX1 = ((Rectangle) obj1).TopLeftX;
                    int rightY1 = ((Rectangle) obj1).BottomRightY;
                    int rightX1 = ((Rectangle) obj1).BottomRightX;
                    int Height1 = ((Rectangle) obj1).Height;
                    int Width1 = ((Rectangle) obj1).Width;
                    int leftY2 = ((Rectangle) obj2).TopLeftY;
                    int leftX2 = ((Rectangle) obj2).TopLeftX;
                    int rightY2 = ((Rectangle) obj2).BottomRightY;
                    int rightX2 = ((Rectangle) obj2).BottomRightX;
                    int Height2 = ((Rectangle) obj2).Height;
                    int Width2 = ((Rectangle) obj2).Width;

                    int[,] arX = new int[4, 4];
                    int[,] arY = new int[4, 4];

                    int colsBetweenRectangles;
                    offsetBetweenRectangles = leftX1 - leftX2;
                    obj1IsOnLeft = leftX1 < leftX2 ? true : false;
                    if (obj1IsOnLeft == true)
                    {
                        offsetBetweenRectangles = -offsetBetweenRectangles;
                    }

                    // (Case 1) Rectangle 1 is fully above Rectangle 2
                    if (rightY1 > leftY2)
                    {
                        // Drawing rectangles
                        // Drawing rectangle 1
                        for (int j = 0; j < Height1; j++)
                        {
                            for (int n = 0; n < offsetHorizontalLeft; n++)
                                sb.Append(" ");
                            if (obj1IsOnLeft == false)
                            {
                                // Inserting space before Rectangle 1
                                for (int n = 0; n < offsetBetweenRectangles; n++)
                                    sb.Append(" ");
                            }
                            for (var i = 0; i < Width1; i++)
                            {
                                if (j == 0)
                                {
                                    if (i == 0) sb.Append("┌"); //"┌" "╔"
                                    if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else if (j == Height1 - 1)
                                {
                                    if (i == 0) sb.Append("└"); //"└" "╚"
                                    if (i == Width1 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else
                                {
                                    if (i == 0) sb.Append("│"); //"│" "║"
                                    if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                    else sb.Append(" ");
                                }
                            }
                        }
                        // Inserting lines between rectangles
                        for (int h = 0; h < (rightY1-leftY1); h++)
                            sb.Append("\n");
                        // Drawing rectangle 2
                        for (int j = 0; j < Height2; j++)
                        {
                            for (int n = 0; n < offsetHorizontalLeft; n++)
                                sb.Append(" ");
                            if (obj1IsOnLeft == true)
                            {
                                for (int n = 0; n < offsetBetweenRectangles; n++)
                                    sb.Append(" ");
                            }
                            for (var i = 0; i < Width2; i++)
                            {
                                if (j == 0)
                                {
                                    if (i == 0) sb.Append("┌"); //"┌" "╔"
                                    if (i == Width2 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else if (j == Height2 - 1)
                                {
                                    if (i == 0) sb.Append("└"); //"└" "╚"
                                    if (i == Width2 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else
                                {
                                    if (i == 0) sb.Append("│"); //"│" "║"
                                    if (i == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                    else sb.Append(" ");
                                }
                            }
                        }

                    }
                    // (Case 2) Rectangle 1 is fully under rectangle 2
                    else if (leftY1 < rightY2)
                    {
                        // Drawing rectangles
                        // Drawing rectangle 2
                        for (int j = 0; j < Height2; j++)
                        {
                            for (int n = 0; n < offsetHorizontalLeft; n++)
                                sb.Append(" ");
                            if (obj1IsOnLeft == true)
                            {
                                for (int n = 0; n < offsetBetweenRectangles; n++)
                                    sb.Append(" ");
                            }
                            for (var i = 0; i < Width2; i++)
                            {
                                if (j == 0)
                                {
                                    if (i == 0) sb.Append("┌"); //"┌" "╔"
                                    if (i == Width2 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else if (j == Height2 - 1)
                                {
                                    if (i == 0) sb.Append("└"); //"└" "╚"
                                    if (i == Width2 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else
                                {
                                    if (i == 0) sb.Append("│"); //"│" "║"
                                    if (i == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                    else sb.Append(" ");
                                }
                            }
                        }
                        // Inserting lines between rectangles
                        for (int h = 0; h < (rightY1 - leftY1); h++)
                            sb.Append("\n");
                        // Drawing rectangle 1
                        for (int j = 0; j < Height1; j++)
                        {
                            for (int n = 0; n < offsetHorizontalLeft; n++)
                                sb.Append(" ");
                            if (obj1IsOnLeft == false)
                            {
                                // Inserting space before Rectangle 1
                                for (int n = 0; n < offsetBetweenRectangles; n++)
                                    sb.Append(" ");
                            }
                            for (var i = 0; i < Width1; i++)
                            {
                                if (j == 0)
                                {
                                    if (i == 0) sb.Append("┌"); //"┌" "╔"
                                    if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else if (j == Height1 - 1)
                                {
                                    if (i == 0) sb.Append("└"); //"└" "╚"
                                    if (i == Width1 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                    else sb.Append("─"); //"─" "═"
                                }
                                else
                                {
                                    if (i == 0) sb.Append("│"); //"│" "║"
                                    if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                    else sb.Append(" ");
                                }
                            }
                        }
                    }
                    // (Cases 3..4) Bottom of rectangle 1 is in line with top of rectangle 2
                    // and rectangles are not intersecting.
                    else if (rightY1 == leftY2)
                    {
                        // (Case 3) Rectangle 1 is on left from rectangle 2
                        if (rightX1 <= leftX2)
                        {
                            // Drawing rectangles
                            // Drawing rectangle 1
                            for (int j = 0; j < Height1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                if (obj1IsOnLeft == false)
                                {
                                    // Inserting space before Rectangle 1
                                    for (int n = 0; n < offsetBetweenRectangles; n++)
                                        sb.Append(" ");
                                }
                                for (var i = 0; i < Width1; i++)
                                {
                                    if (j == 0)
                                    {
                                        if (i == 0) sb.Append("┌"); //"┌" "╔"
                                        if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else if (j == Height1 - 1)
                                    {
                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i < Width1 - 1) sb.Append("─"); // sb.Append("┘" + "\n"); //"┘" "╝"
                                        else
                                        {
                                            if (rightX1 == leftX2) sb.Append("+");
                                            else sb.Append("┘"); //"─" "═"
                                        }
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                            // Inserting columns between rectangles
                            colsBetweenRectangles = leftX2 - rightX1;
                            // Drawing rectangle 2
                            for (int c = rightX1 + 1; c < colsBetweenRectangles; c++) sb.Append(" ");
                            for (int j = 0; j < Height2; j++)
                            {
                                if (j > 0)
                                {
                                    for (int n = 0; n < offsetHorizontalLeft; n++)
                                        sb.Append(" ");
                                    if (obj1IsOnLeft == true)
                                    {
                                        for (int n = 0; n < (offsetBetweenRectangles); n++)
                                            sb.Append(" ");
                                    }
                                }
                                for (var i = 0; i < Width2; i++)
                                {
                                    if (j == 0)
                                    {
                                        if ((i == 0) & (rightX1==leftX2))
                                        {
                                            sb.Append("─"); //"─" "═"
                                            continue; //sb.Append("+"); //"┌" "╔"
                                        }
                                        if (i == 0) sb.Append("┌");
                                        if (i == Width2 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else if (j == Height2 - 1)
                                    {
                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i == Width2 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                            
                        }

                        // (Case 4) Rectangle 1 is on right from rectangle 2
                        if (rightX2 <= leftX1)
                        {
                            // Drawing rectangles
                            // Columns between rectangles
                            colsBetweenRectangles = leftX1 - rightX2;
                            // Drawing rectangle 1
                            for (int j = 0; j < Height1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                if (obj1IsOnLeft == false)
                                {
                                    // Inserting space before Rectangle 1
                                    if (j < Height1 - 1)
                                    {
                                        for (int n = 0; n < offsetBetweenRectangles; n++)
                                            sb.Append(" ");
                                    }
                                    // Drawing top of rectangle 2
                                    else
                                    {
                                        for (var i = 0; i < Width2; i++)
                                        {
                                            if (i == 0) sb.Append("┌");
                                            if (i == Width2 -1)
                                            {
                                                if (rightX2 == leftX1)
                                                    sb.Append("+"); //"─" "═"
                                                else sb.Append("┐"); //sb.Append("+"); //"┌" "╔"
                                            }
                                            else sb.Append("─");
                                        }
                                        // Inserting columns between rectangles
                                        for (int c = rightX2 + 1; c < colsBetweenRectangles; c++) sb.Append(" ");
                                    }
                                }
                                for (var i = 0; i < Width1; i++)
                                {
                                    if (j == 0)
                                    {
                                        if (i == 0) sb.Append("┌"); //"┌" "╔"
                                        if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else if (j == Height1 - 1)
                                    {
                                        if ((i == 0) & (rightX2 == leftX1))
                                        {
                                            sb.Append("─");
                                            continue;
                                        }
                                        else if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i < Width1 - 1) sb.Append("─"); // sb.Append("┘" + "\n"); //"┘" "╝"
                                        else
                                        {
                                            //if (rightX2 == leftX1) sb.Append("+");
                                            sb.Append("┘" + "\n"); //"─" "═"
                                        }
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                            // Drawing rectangle 2
                            for (int j = 1; j < Height2; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                if (obj1IsOnLeft == true)
                                {
                                    // Inserting space before Rectangle 1
                                    for (int n = 0; n < offsetBetweenRectangles; n++)
                                        sb.Append(" ");
                                }
                                for (var i = 0; i < Width2; i++)
                                {
                                    /*if (j == 0)
                                    {
                                        if (i == 0) sb.Append("┌"); //"┌" "╔"
                                        if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                        else sb.Append("─"); //"─" "═"
                                    }*/
                                    if (j == Height2 - 1)
                                    {
                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i < Width2 - 1) sb.Append("─"); // sb.Append("┘" + "\n"); //"┘" "╝"
                                        else
                                        {
                                            sb.Append("┘"); //"─" "═"
                                        }
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                        }
                    }
                    // (Case 5..6) Top of rectangle 1 above Top of rectangle 2
                    // and Bottom of rectangle 1 above bottom of rectangle 2
                    else if ((leftY1 > leftY2) && (leftY2 > rightY1) && (rightY1 > rightY2))
                    {
                        // (Case 5) rectangle 1 on left of rectangle 2
                        if (rightX1 < leftX2)
                        {
                            // Columns between rectangles
                            colsBetweenRectangles = leftX2 - rightX1;
                            // Drawing rectangles
                            // Drawing rectangle 1 (and part of rectangle 2)
                            for (int j = 0; j < Height1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                // Drawing Only Rectangle 1
                                if (leftY1 - j > leftY2)
                                {
                                    if (obj1IsOnLeft == false)
                                    {
                                        // Inserting space before Rectangle 1
                                        for (int n = 0; n < offsetBetweenRectangles; n++)
                                            sb.Append(" ");
                                    }
                                    for (var i = 0; i < Width1; i++)
                                    {
                                        if (j == 0)
                                        {
                                            if (i == 0) sb.Append("┌"); //"┌" "╔"
                                            if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                            else sb.Append("─"); //"─" "═"
                                        }
                                        /*else if (j == Height1 - 1)
                                        {
                                            if (i == 0) sb.Append("└"); //"└" "╚"
                                            if (i == Width1 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                            else sb.Append("─"); //"─" "═"
                                        }*/
                                        else
                                        {
                                            if (i == 0) sb.Append("│"); //"│" "║"
                                            if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                            else sb.Append(" ");
                                        }
                                    }
                                }
                                // Drawing both rectangles
                                else if ((leftY1 - j <= leftY2) | (leftY1 - j == rightY1))
                                {
                                    if (obj1IsOnLeft == false)
                                    {
                                        // Inserting space before Rectangle 1
                                        for (int n = 0; n < offsetBetweenRectangles; n++)
                                            sb.Append(" ");
                                    }
                                    for (var i = 0; i < Width1; i++)
                                    {
                                        /*if (j == 0)
                                        {
                                            if (i == 0) sb.Append("┌"); //"┌" "╔"
                                            if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                            else sb.Append("─"); //"─" "═"
                                        }*/
                                        
                                        //Drawing bottom of rectangle 1 + sides of rectangle 2
                                        if (j == Height1 - 1)
                                        {
                                            if (i == 0) sb.Append("└"); //"└" "╚"
                                            if (i == Width1 - 1)
                                            {
                                                sb.Append("┘"); //"┘" "╝"
                                                // Inserting columns between rectangles
                                                for (int c = rightX1 + 1; c < colsBetweenRectangles; c++)
                                                    sb.Append(" ");
                                                for (int i2 = 0; i2 < Width2; i2++)
                                                {
                                                    if (i2 == 0) sb.Append("│"); //"│" "║"
                                                    if (i2 == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                                    else sb.Append(" ");
                                                }
                                            }
                                            else sb.Append("─"); //"─" "═"
                                        }
                                        // Drawing left and right sides of rectangle 1
                                        // + rectangle 2
                                        else
                                        {
                                            if (i == 0) sb.Append("│"); //"│" "║"
                                            if (i == Width1 - 1)
                                            {
                                                sb.Append("│"); //"│" "║"
                                                // Drawing top of rectangle 2
                                                if (leftY1 - j == leftY2)
                                                {
                                                    // Inserting columns between rectangles
                                                    for (int c = rightX1 + 1; c < colsBetweenRectangles; c++) sb.Append(" ");
                                                    for (var i2 = 0; i2 < Width2; i2++)
                                                    {
                                                        if (i2 == 0) sb.Append("┌");
                                                        if (i2 == Width2 - 1)
                                                        {
                                                            if (rightX2 == leftX1)
                                                                ; //sb.Append("+"); //"─" "═"
                                                            else sb.Append("┐" + "\n"); //sb.Append("+"); //"┌" "╔"
                                                        }
                                                        else sb.Append("─");
                                                    }
                                                }
                                                // Drawing middle of rectangle 2
                                                else if (leftY1 - j < leftY2)
                                                {
                                                    // Inserting columns between rectangles
                                                    for (int c = rightX1 + 1; c < colsBetweenRectangles; c++)
                                                        sb.Append(" ");
                                                    for (int i2 = 0; i2 < Width2; i2++)
                                                    {
                                                        if (i2 == 0) sb.Append("│"); //"│" "║"
                                                        if (i2 == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                                        else sb.Append(" ");
                                                    }
                                                }
                                            }
                                            else sb.Append(" ");
                                        }
                                    }
                                }
                            }
                            // Drawing only rectangle 2
                            for (int j = rightY2; j < rightY1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft + offsetBetweenRectangles; n++)
                                    sb.Append(" ");
                                //for (int n = 0; n < offsetBetweenRectangles; n++)
                                  //  sb.Append(" ");
                                for (int i = 0; i < Width2; i++)
                                {
                                    if (j == rightY1 - 1)
                                    {
                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i == Width2 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                        }
                        // (Case 6) rectangle 1 on right of rectangle 2
                        if (rightX2 < leftX1)
                        {
                            
                            // Columns between rectangles
                            colsBetweenRectangles = leftX2 - rightX1;
                            // Drawing rectangles
                            // Drawing rectangle 1 (and part of rectangle 2)
                            for (int j = 0; j < Height1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                // Drawing Only Rectangle 1
                                if (leftY1 - j > leftY2)
                                {
                                    if (obj1IsOnLeft == false)
                                    {
                                        // Inserting space before Rectangle 1
                                        for (int n = 0; n < offsetBetweenRectangles; n++)
                                            sb.Append(" ");
                                    }
                                    for (var i = 0; i < Width1; i++)
                                    {
                                        if (j == 0)
                                        {
                                            if (i == 0) sb.Append("┌"); //"┌" "╔"
                                            if (i == Width1 - 1) sb.Append("┐" + "\n"); //"┐" "╗"
                                            else sb.Append("─"); //"─" "═"
                                        }
                                        /*else if (j == Height1 - 1)
                                        {
                                            if (i == 0) sb.Append("└"); //"└" "╚"
                                            if (i == Width1 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                            else sb.Append("─"); //"─" "═"
                                        }*/
                                        else
                                        {
                                            if (i == 0) sb.Append("│"); //"│" "║"
                                            if (i == Width1 - 1) sb.Append("│" + "\n"); //"│" "║"
                                            else sb.Append(" ");
                                        }
                                    }
                                }
                                // Drawing both rectangles
                                else if ((leftY1 - j <= leftY2) | (leftY1 - j == rightY1))
                                {
                                    
                                    if ((obj1IsOnLeft == false) & (leftY1 - j > leftY2))
                                    {
                                        // Inserting space before Rectangle 1
                                        for (int n = 0; n < offsetBetweenRectangles; n++)
                                            sb.Append(" ");
                                    }
                                    // Drawing top of rectangle 2
                                    if (leftY1 - j == leftY2)
                                    {
                                        for (var i2 = 0; i2 < Width2; i2++)
                                        {
                                            if (i2 == 0) sb.Append("┌");
                                            if (i2 == Width2 - 1)
                                            {
                                                if (rightX2 == leftX1)
                                                    ; //sb.Append("+"); //"─" "═"
                                                else
                                                {
                                                    sb.Append("┐"); //sb.Append("+"); //"┌" "╔"
                                                    // Inserting columns between rectangles
                                                    for (int c = rightX1 + 1; c < colsBetweenRectangles; c++)
                                                        sb.Append(" ");
                                                    for (var i = 0; i < Width1; i++)
                                                    {
                                                        if (i == 0) sb.Append("│"); //"│" "║"
                                                        if (i == Width1 - 1)
                                                            sb.Append("│" + "\n"); //"│" "║"
                                                        else sb.Append(" ");
                                                    }
                                                }
                                            }
                                            else sb.Append("─");
                                        }
                                    }
                                    //Drawing sides of rectangle 2 + bottom of rectangle 1
                                    else if (leftY1 - j < leftY2)
                                    {
                                        for (int i2 = 0; i2 < Width2; i2++)
                                        {
                                            if (i2 == 0) sb.Append("│"); //"│" "║"
                                            if (i2 == Width2 - 1)
                                            {
                                                sb.Append("│"); //"│" "║"
                                                // Inserting columns between rectangles
                                                for (int c = rightX2 + 1; c < colsBetweenRectangles; c++)
                                                    sb.Append(" ");
                                                for (int i = 0; i < Width1; i++)
                                                {
                                                    if (j == Height1 - 1)
                                                    {
                                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                                        if (i == Width1 - 1)
                                                        {
                                                            sb.Append("┘" + "\n"); //"┘" "╝"
                                                        }
                                                        else sb.Append("─"); //"─" "═"
                                                    }
                                                    // Drawing left and right sides of rectangle 2
                                                    // + rectangle 1
                                                    else
                                                    {
                                                        if (i == 0) sb.Append("│"); //"│" "║"
                                                        if (i == Width1 - 1)
                                                            sb.Append("│" + "\n"); //"│" "║"
                                                        else sb.Append(" ");
                                                    }
                                                }
                                            }
                                            else sb.Append(" ");
                                        }
                                    }
                                }
                            }
                            // Drawing only rectangle 2
                            for (int j = rightY2; j < rightY1; j++)
                            {
                                for (int n = 0; n < offsetHorizontalLeft; n++)
                                    sb.Append(" ");
                                //for (int n = 0; n < offsetBetweenRectangles; n++)
                                //  sb.Append(" ");
                                for (int i = 0; i < Width2; i++)
                                {
                                    if (j == rightY1 - 1)
                                    {
                                        if (i == 0) sb.Append("└"); //"└" "╚"
                                        if (i == Width2 - 1) sb.Append("┘" + "\n"); //"┘" "╝"
                                        else sb.Append("─"); //"─" "═"
                                    }
                                    else
                                    {
                                        if (i == 0) sb.Append("│"); //"│" "║"
                                        if (i == Width2 - 1) sb.Append("│" + "\n"); //"│" "║"
                                        else sb.Append(" ");
                                    }
                                }
                            }
                        }
                    }

                    // Top of rectangle 1 is in line with bottom of rectangle 2
                    // and rectangles are not intersecting
                    else //if (leftY1 == rightY2)
                    {
                        // Rectangle 1 is on left from rectangle 2
                        if (rightX1 < leftX2)
                        {
                            arY[0, 0] = leftY2;
                            arX[0, 0] = leftX2;
                            arY[0, 1] = leftY2;
                            arX[0, 1] = rightX2;

                            arY[3, 0] = rightY1;
                            arX[3, 0] = leftX1;
                            arY[3, 1] = rightY1;
                            arX[3, 1] = rightX1;

                            arY[1, 0] = leftY1;
                            arX[1, 0] = leftX1;
                            arY[1, 1] = leftY1;
                            arX[1, 1] = rightX1;

                            arY[2, 0] = rightY2;
                            arX[2, 0] = leftX2;
                            arY[2, 1] = rightY2;
                            arX[2, 1] = rightX2;
                        }

                        // Rectangle 1 is on right from rectangle 2
                        if (rightX2 < leftX1)
                        {
                            arY[2, 0] = leftY1;
                            arX[2, 0] = leftX1;
                            arY[2, 1] = leftY1;
                            arX[2, 1] = rightX1;

                            arY[0, 0] = leftY2;
                            arX[0, 0] = leftX2;
                            arY[0, 1] = leftY2;
                            arX[0, 1] = rightX2;

                            arY[3, 0] = rightY1;
                            arX[3, 0] = leftX1;
                            arY[3, 1] = rightY1;
                            arX[3, 1] = rightX1;

                            arY[1, 0] = rightY2;
                            arX[1, 0] = leftX2;
                            arY[1, 1] = rightY2;
                            arX[1, 1] = rightX2;
                        }
                    }
                    
                }
                // Rectangles are intersecting
                else
                {
                    // Looking which rectangle has greater Y coordinate.
                    int leftY1 = ((Rectangle)obj1).TopLeftY;
                    int leftX1 = ((Rectangle)obj1).TopLeftX;
                    int rightY1 = ((Rectangle)obj1).BottomRightY;
                    int rightX1 = ((Rectangle)obj1).BottomRightX;
                    int leftY2 = ((Rectangle)obj2).TopLeftY;
                    int leftX2 = ((Rectangle)obj2).TopLeftX;
                    int rightY2 = ((Rectangle)obj2).BottomRightY;
                    int rightX2 = ((Rectangle)obj2).BottomRightX;

                    int[,] arX = new int[4, 4];
                    int[,] arY = new int[4, 4];

                    // Top of rectangle 1 is above top of rectangle 2 and
                    // bottom of rectangle 1 is under top of rectangle 2 
                    if ((leftY1 > leftY2) & (leftY2 > rightY1))
                    {
                        arY[0, 0] = leftY1;
                        arX[0, 0] = leftX1;
                        arY[0, 1] = leftY1;
                        arX[0, 1] = rightX1;

                        arY[1, 0] = leftY2;
                        arX[1, 0] = leftX2;
                        arY[1, 1] = leftY2;
                        arX[1, 1] = rightX2;

                        // Bottom of rectangle 1 is above bottom of rectangle 2
                        if (rightY1 > rightY2)
                        {
                            arY[2, 0] = rightY1;
                            arX[2, 0] = leftX1;
                            arY[2, 1] = rightY1;
                            arX[2, 1] = rightX1;

                            arY[3, 0] = rightY2;
                            arX[3, 0] = leftX2;
                            arY[3, 1] = rightY2;
                            arX[3, 1] = rightX2;
                        }
                        // Bottom of rectangle 1 is under bottom of rectangle 2
                        else if (rightY1 < rightY2)
                        {
                            arY[3, 0] = rightY1;
                            arX[3, 0] = leftX1;
                            arY[3, 1] = rightY1;
                            arX[3, 1] = rightX1;

                            arY[2, 0] = rightY2;
                            arX[2, 0] = leftX2;
                            arY[2, 1] = rightY2;
                            arX[2, 1] = rightX2;
                        }
                        // Bottom of rectangle 1 in line with bottom of rectangle 2
                        else
                        {
                            // Left line of rectangle 2 is outside of rectangle 1
                            if (leftX2 < leftX1)
                            {
                                arY[2, 0] = rightY2;
                                arX[2, 0] = leftX2;
                                arY[2, 1] = rightY2;
                                arX[2, 1] = leftX1;

                                // Right line of rectangle 2 inside (or equals to right line) of rectangle 1
                                if (rightX2 <= rightX1)
                                {
                                    arY[3, 0] = rightY1;
                                    arX[3, 0] = leftX1;
                                    arY[3, 1] = rightY1;
                                    arX[3, 1] = rightX1;
                                }
                                // Right line of rectangle 2 outside of rectangle 1
                                else
                                {
                                    arY[3, 0] = rightY1;
                                    arX[3, 0] = rightX1;
                                    arY[3, 1] = rightY2;
                                    arX[3, 1] = rightX2;
                                }
                                
                            }
                        }
                    }
                    // Top of both rectangles are in one line.
                    else if (leftY1 == leftY2)
                    {
                        
                        // Looking from left to right


                    }
                    // Top of rectangle 2 is inline with bottom of rectangle 1
                    
                    else // (leftY1 < leftY2)
                    {
                        // Top of rectangle 2 is above top of rectangle 1
                        // виправити, додати перевірку на порядок
                        arY[0, 0] = leftY2;
                        arX[0, 0] = leftX2;
                        arY[0, 1] = leftY2;
                        arX[0, 1] = rightX2;


                    }
                }
            }
            ConsIO.WriteLine(sb.ToString());
        }
    }

    public static class WindowChecker
    {
        /// <summary>
        /// Checks if rectangle is inside current Window
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public static bool RectangleIsInWindow(Rectangle rec)
        {
            //int windowWidth = ConsIO.WindowWidth;
            //int windowHeight = ConsIO.WindowHeight;
            return (rec.Height < ConsIO.WindowHeight-5) && (rec.Width < ConsIO.WindowWidth-10);
        }
        /// <summary>
        /// Checks if both rectangles are inside current Window (based on coordinates)
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public static bool RectanglesAreInWindow(Rectangle rec1, Rectangle rec2)
        {
            //int windowWidth = ConsIO.WindowWidth;
            //int windowHeight = ConsIO.WindowHeight;
            int tempWidth = MaxMinRectangleCoords.MaxX(rec1, rec2) - MaxMinRectangleCoords.MinX(rec1, rec2);
            int tempHeight = MaxMinRectangleCoords.MaxY(rec1, rec2) - MaxMinRectangleCoords.MinY(rec1, rec2);
            return (tempHeight < ConsIO.WindowHeight-5) && (tempWidth < ConsIO.WindowWidth-10);
        }
    }

    #endregion
}
