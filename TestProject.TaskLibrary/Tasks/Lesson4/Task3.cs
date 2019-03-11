using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task3 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson4.Task3 ***\n";
            s = s + "       Using previous task change abstract method Draw() to virtual.\n" +
                "       Make sure that 3 implementations of method Draw() work.";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("*  Drawing Squares *");
            var sq = new SquareByVirtual(10, 10);
            ConsIO.WriteLine("  as Square ");
            sq.Draw();
            ConsIO.WriteLine("  as Figure ");
            ((FigureVirtual) sq).Draw();
            
            ConsIO.WriteLine("* drawing rectangle");
            var rc = new RectangleByVirtual(15, 15);
            ConsIO.WriteLine("  as Rectangle ");
            rc.Draw();
            ConsIO.WriteLine("  as Figure ");
            ((FigureVirtual) rc).Draw();
        }
    }

    public class FigureVirtual
    {
        /// <summary>
        /// Initializes new instance of Figure
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public FigureVirtual(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X coordinate.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y { get; private set; }
        
        /// <summary>
        /// Print figure from class Figure
        /// </summary>
        public virtual void Draw()
        {
            string s = "Drawing Figure from class Figure";
            ConsIO.WriteLine(s);
        }
    }

    public class SquareByVirtual : FigureVirtual
    {
        /// <summary>
        /// Initializes new instance of
        /// square inherited from Figure
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public SquareByVirtual(int x, int y):base(x,y)
        {
            
        }

        /// <summary>
        /// Print square from class Square
        /// </summary>
        public override void Draw()
        {
            string s = "Drawing Square from class Square";
            ConsIO.WriteLine(s);
        }
    }
    public class RectangleByVirtual : FigureVirtual
    {
        /// <summary>
        /// Initializes new instance of
        /// rectangle inherited from Figure
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public RectangleByVirtual(int x, int y) : base(x, y)
        {

        }

        /// <summary>
        /// Print rectangle from class Rectangle
        /// </summary>
        public override void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle";
            ConsIO.WriteLine(s);
        }
    }
}
