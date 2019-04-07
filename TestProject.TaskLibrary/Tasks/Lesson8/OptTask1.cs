using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson8
{
    public class OptTask1 : IRunnable
    {
        public void Run()
        {
            int offsetBottom = 4;
            int windowWidth = ConsIO.WindowWidth;
            int windowHeight = ConsIO.WindowHeight;
            
            int X, Y, Z, Width, Height, Length;

            ConsIO.Clear();
            string s = "*** Now you are in Lesson8.OptTask1 ***\n    Draw Parallelepiped";
            ConsIO.WriteLine(s);
            
            ConsIO.WriteLine("\n***  Window dimensions: " + windowWidth + "; " + windowHeight + "  ***\n");
            
            ConsIO.Write("Enter coordinates and dimensions of parallelepiped.\n  X: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            X = Validators.GetIntNumber(s);
            ConsIO.Write("  Y: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            Y = Validators.GetIntNumber(s);
            ConsIO.Write("  Z: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            Z = Validators.GetIntNumber(s);
            ConsIO.Write("  Width: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            Width = Validators.GetIntNumber(s);
            ConsIO.Write("  Length: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            Length = Validators.GetIntNumber(s);
            ConsIO.Write("  Height: ");
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            Height = Validators.GetIntNumber(s);

            Parallelepiped.LeftOffsetX = 11;
            Parallelepiped.TopOffsetY = 3;
            Parallelepiped.OffsetHorizontal = Parallelepiped.LeftOffsetX + 0;
            Parallelepiped.OffsetVertical = Parallelepiped.TopOffsetY + offsetBottom;
            Parallelepiped.OffsetBottom = offsetBottom;

            WindowChecker.ParallelepipedIsInWindow(Parallelepiped.OffsetHorizontal, Parallelepiped.OffsetVertical,
                Width, Length, Height);

            Parallelepiped par = new Parallelepiped(X, Y, Z, Width ,Length, Height);

            ConsIO.Clear();

            ConsIO.WriteLine($"Parallelepiped has X={par.X}, Y={par.Y}, Z={par.Z}, " +
                             $"Width={par.Width}, Length={par.Length}, Height={par.Height}");
            par.Draw();

            ConsIO.ClearBottom(ref offsetBottom);
            ConsIO.ReadLine();
        }
        
    }

    public static partial class WindowChecker
    {
        /// <summary>
        /// Checks if parallelepiped is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static bool ParallelepipedIsInWindow(int offsetHorizontal, int offsetVertical, Parallelepiped par)
        {
            return (par.Height + par.Length < ConsIO.WindowHeight - offsetVertical) &&
                   (par.Height + par.Width < ConsIO.WindowWidth - offsetHorizontal);
        }

        /// <summary>
        /// Checks if parallelepiped is inside current Window
        /// </summary>
        /// <param name="offsetHorizontal"></param>
        /// <param name="offsetVertical"></param>
        /// <param name="width">Along X</param>
        /// <param name="length">Along Y</param>
        /// <param name="height">Along Z</param>
        /// <returns></returns>
        public static bool ParallelepipedIsInWindow(int offsetHorizontal, int offsetVertical, int width, int length, int height)
        {
            return (height + length < ConsIO.WindowHeight - offsetVertical) &&
                   (width + height < ConsIO.WindowWidth - offsetHorizontal);
        }

    }

    public class Parallelepiped : Figure
    {
        public static int LeftOffsetX;
        public static int TopOffsetY;
        public static int OffsetHorizontal;
        public static int OffsetVertical;
        public static int OffsetBottom;
        
        private int x;
        private int y;
        private int z;
        private int width;
        private int height;
        private int length;


        #region Properties

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Parallelepiped"
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Parallelepiped"
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the upper-left corner
        /// of the rectangular region defined by this "Parallelepiped"
        /// </summary>
        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Gets or sets width of the rectangular
        /// region defined by this "Parallelepiped"
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Gets or sets height of the parallelepiped
        /// defined by this "Parallelepiped"
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


        #endregion


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
                end - start);
        }


        #region Drawing parallelepiped

        /// <summary>
        /// Draws only current Parallelepiped.
        /// </summary>
        public new void Draw()
        {
            // Drawing in the current view
            DrawInView(this);
        }

        /// <summary>
        /// Draws specified parallelepiped in the view (cursor at 0,0 + offsets)
        /// </summary>
        /// <param name="par"></param>
        private void DrawInView(Parallelepiped par)
        {
            DrawOnStart(par, LeftOffsetX + Height, TopOffsetY);
            DrawHeight(par);
            DrawOnEnd(par);
        }

        /// <summary>
        /// Draws bottom side (smaller Z) of a parallelepiped.
        /// </summary>
        /// <param name="par"></param>
        /// <param name="tempOffsetX"></param>
        /// <param name="tempOffsetY"></param>
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

        /// <summary>
        /// Draws top side (greater Z) of a parallelepiped.
        /// </summary>
        /// <param name="par"></param>
        private void DrawOnEnd(Parallelepiped par)
        {
            for (int i = 0; i <= par.Length; i++)
            {
                for (int j = 0; j <= par.Width; j++)
                {
                    if (i == 0)
                    {
                        ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + i);
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
                        ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + i);
                        if (j == 0) ConsIO.Write("└"); //"└" "╚"
                        if (j == par.Width) ConsIO.Write("┘"); //"┘" "╝"
                        else ConsIO.Write("─"); //"─" "═"
                    }
                    else
                    {
                        if (j == 0)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + i);
                            ConsIO.Write("│"); //"│" "║"
                        }
                        if (j == par.Width)
                        {
                            ConsIO.SetCursorPosition(LeftOffsetX + j, TopOffsetY + par.Y + i);
                            ConsIO.Write("│"); //"│" "║"
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws edges (from z0 to z1) of a parallelepiped.
        /// </summary>
        /// <param name="par"></param>
        private void DrawHeight(Parallelepiped par)
        {
            for (int i = 1; i < par.Height; i++)
            {
                ConsIO.SetCursorPosition(LeftOffsetX + par.Height - i, TopOffsetY + i);
                ConsIO.Write("/");
                ConsIO.SetCursorPosition(LeftOffsetX + par.Height + par.Width - i, TopOffsetY + i);
                ConsIO.Write("/");
                ConsIO.SetCursorPosition(LeftOffsetX + par.Height - i, TopOffsetY + par.Length + i);
                ConsIO.Write("/");
                ConsIO.SetCursorPosition(LeftOffsetX + par.Height + par.Width - i, TopOffsetY + par.Length + i);
                ConsIO.Write("/");
            }
        }

        #endregion

        /// <summary>
        /// Moves parallelepiped.
        /// </summary>
        /// <param name="dX">Distance to move along X</param>
        /// <param name="dY">Distance to move along Y</param>
        /// <param name="dZ">Distance to move along Z</param>
        public void Move(int dX = 0, int dY = 0, int dZ = 0)
        {
            X += dX;
            Y += dY;
            Z += dZ;
        }
    }
}
