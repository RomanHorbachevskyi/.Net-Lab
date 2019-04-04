using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson4.Task2 ***\n";
            s = s + "       Using previous task add readonly properties X and Y to class Figure.\n" +
                "   Add constructor with parameters to set these properties.";
            ConsIO.WriteLine(s);
            var sq = new SquareByAbstract(10,10);
            sq.Draw();
            var rc = new RectangleByAbstract(15,15);
            rc.Draw();
            ConsIO.ReadLine();
        }
    }

    public abstract partial class FigureAbstract
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// An abstract constructor to initialize an instance
        /// of inherited class and set properties.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        protected FigureAbstract(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public partial class SquareByAbstract : FigureAbstract
    {
        /// <summary>
        /// Initializes new instance of Square.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public SquareByAbstract(int x, int y):base(x, y)
        {
            
        }
    }
    public partial class RectangleByAbstract : FigureAbstract
    {
        /// <summary>
        /// Initializes new instance of Rectangle.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public RectangleByAbstract(int x, int y) : base(x, y)
        {

        }
    }
}
