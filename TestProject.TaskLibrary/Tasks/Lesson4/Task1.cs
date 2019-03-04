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

            string s = "*** Now you are in Lesson4.Task1 ***";
            ConsIO.WriteLine(s);
            Square sq=new Square();
            sq.Draw();
            Rectangle rc=new Rectangle();
            rc.Draw();
        }
    }

    public abstract class Figure
    {
        public abstract void Draw();

    }

    public class Square : Figure
    {
        public override void Draw()
        {
            string s = "Drawing Square from class Square";
            ConsIO.WriteLine(s);
        }
    }
    public class Rectangle : Figure
    {
        public override void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle";
            ConsIO.WriteLine(s);
        }
    }
}
