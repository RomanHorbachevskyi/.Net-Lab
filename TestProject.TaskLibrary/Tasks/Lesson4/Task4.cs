using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task4 : IRunnable
    {
        public void Run()
        {
            var s = "*** Now you are in Lesson4.Task3 ***\n";
            s = s + "       Using previous task elevate method Draw() into separate interface\n" +
                "       IDrawable. Create method DrawAll() which calls correct method Draw().";
            ConsIO.WriteLine(s);
            s = "Doing method Draw()";
            ConsIO.WriteLine(s);
            var sq = new SquareInterfaced(10, 10);
            sq.Draw();
            var fg = new FigureInterfaced(5,5);
            fg.Draw();
            var rc = new RectangleInterfaced(15, 15);
            rc.Draw();
            s = "Doing method DrawAll() in class Lesson4.Task4";
            ConsIO.WriteLine(s);
            DrawAll(sq,rc, fg);
            ConsIO.ReadLine();
        }
        public static void DrawAll(params IDrawable[] array)
        {
            try
            {
                foreach (var item in array)
                {
                    if (item is SquareInterfaced)
                        item.Draw();
                    else if (item is RectangleInterfaced)
                        item.Draw();
                    else
                    {
                        (item as FigureInterfaced).Draw();
                    }
                }
            }
            catch (Exception)
            {
                ConsIO.WriteLine("There is nothing to draw.");
            }
        }
    }

    
    public class FigureInterfaced:IDrawable
    {
        /// <summary>
        /// Initializes new instance of
        /// FigureInterfaced
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public FigureInterfaced(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Print Figure from class FigureInterfaced
        /// </summary>
        public virtual void Draw()
        {
            string s = "Drawing Figure from class FigureInterfaced";
            ConsIO.WriteLine(s);
        }
    }

    public class SquareInterfaced : IDrawable
    {
        /// <summary>
        /// Initializes new instance of
        /// SquareInterfaced
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public SquareInterfaced(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }
        

        /// <summary>
        /// Print SquareInterfaced
        /// </summary>
        public void Draw()
        {
            string s = "Drawing Square from class SquareInterfaced";
            ConsIO.WriteLine(s);
        }
    }
    public class RectangleInterfaced : IDrawable
    {
        /// <summary>
        /// Initializes new instance of
        /// RectangleInterfaced
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public RectangleInterfaced(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Print RectangleInterfaced
        /// </summary>
        public void Draw()
        {
            string s = "Drawing Rectangle from class RectangleInterfaced";
            ConsIO.WriteLine(s);
        }
    }
}
