using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task3 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson4.Task3 ***";
            ConsIO.WriteLine(s);
            Console.WriteLine("*  Drawing Squares *");
            Square43 sq = new Square43(10, 10);
            sq.Draw();
            (sq as Figure43).Draw();
            Figure43 fig = sq;
            fig.Draw();
            (fig as Square43).Draw();
            Console.WriteLine("-----");
            Console.WriteLine("drawing figure:");
            Figure43 sq1 = sq;//new Figure43(5,5);
            //((Figure43)sq1).Draw();
            Console.WriteLine("* drawing rectangle");
            Rectangle43 rc = new Rectangle43(15, 15);
            rc.Draw();
        }
    }

    public class Figure43
    {
        //private string Name;// = "Figure";
        public virtual void Draw()
        {
            string s = "Drawing Figure from class Figure43";
            ConsIO.WriteLine(s);
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Name { get; set; }

        public Figure43(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Figure43(string name)
        {
            Name = name;
        }
    }

    public class Square43 : Figure43
    {
        //private int x, y;
        //private static string Name = "Square";
        public Square43(int x, int y):base(x,y)
        {
            
        }
        //public Square43(string name) : base(Name) { }
        public override void Draw()
        {
            string s = "Drawing Square from class Square43";
            ConsIO.WriteLine(s);
        }
    }
    public class Rectangle43 : Figure43
    {
        //private static string Name = "Rectangle";
        public Rectangle43(int x, int y) : base(x, y)
        {

        }
        //public Rectangle43(string name) : base(Name) { }
        public override void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle43";
            ConsIO.WriteLine(s);
        }
    }
}
