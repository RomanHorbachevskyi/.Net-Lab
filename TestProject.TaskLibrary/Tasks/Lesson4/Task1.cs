using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task1 : IRunnable
    {
        public void Run()
        {

            string s = "*** Now you are in Lesson4.Task1 ***\n  Work with inheritance.\n";
            s = s + "       Implement base class Figure with abstract method Draw();\n" +
                "       Create classes Rectangle and Square (inherited from Figure)\n" +
                "       with overloaded implementation of method Draw().";
            ConsIO.WriteLine(s);
            var sq=new SquareByAbstract();
            sq.Draw();
            var rc=new RectangleByAbstract();
            rc.Draw();
        }
    }

    public abstract partial class FigureAbstract
    {
        /// <summary>
        /// An abstract parameterless constructor to
        /// initialize an instance of inherited class.
        /// </summary>
        protected FigureAbstract() { }

        public abstract void Draw();

    }

    public partial class SquareByAbstract : FigureAbstract
    {
        /// <summary>
        /// Initializes an empty instance of Square.
        /// </summary>
        public SquareByAbstract() { }
        
        /// <summary>
        /// Prints name of the class Square
        /// </summary>
        public override void Draw()
        {
            string s = "Drawing Square from class Square";
            ConsIO.WriteLine(s);
        }
    }

    public partial class RectangleByAbstract : FigureAbstract
    {
        /// <summary>
        /// Initializes an empty instance of Rectangle.
        /// </summary>
        public RectangleByAbstract() { }

        /// <summary>
        /// Prints name of the class Rectangle.
        /// </summary>
        public override void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle";
            ConsIO.WriteLine(s);
        }
    }
}
