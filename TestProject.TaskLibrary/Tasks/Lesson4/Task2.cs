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
            string s = "*** Now you are in Lesson4.Task2 ***";
            ConsIO.WriteLine(s);
            Square42 sq = new Square42(10,10);
            sq.Draw();
            Rectangle42 rc = new Rectangle42(15,15);
            rc.Draw();
        }
    }

    public abstract class Figure42
    {
        public abstract void Draw();
        public int X { get; private set; }
        public int Y { get; private set; }

        protected Figure42(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Square42 : Figure42
    {
        //private int x, y;

        public Square42(int x, int y):base(x,y)
        {
            
        }
        public override void Draw()
        {
            string s = "Drawing Square from class Square42";
            ConsIO.WriteLine(s);
        }
    }
    public class Rectangle42 : Figure42
    {
        public Rectangle42(int x, int y) : base(x, y)
        {

        }
        public override void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle42";
            ConsIO.WriteLine(s);
        }
    }
}
