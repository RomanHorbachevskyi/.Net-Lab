using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class Task4 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson4.Task3 ***";
            ConsIO.WriteLine(s);
            s = "Doing method Draw()";
            ConsIO.WriteLine(s);
            Square44 sq = new Square44(10, 10);
            sq.Draw();
            Figure44 sq1 = new Figure44(5,5);
            (sq1 as Figure44).Draw();
            Rectangle44 rc = new Rectangle44(15, 15);
            rc.Draw();
            s = "Doing method DrawAll() in class Lesson4.Task4";
            ConsIO.WriteLine(s);
            Task4.DrawAll(sq,rc,(sq1 as Figure44));
        }
        public static void DrawAll(params IDrawable[] array)
        {
            int l;
            string s;
            try
            {
                l = array.Length;
                foreach (IDrawable item in array)
                {
                    if (item is Square44)
                        item.Draw();
                    else if (item is Rectangle44)
                        item.Draw();
                    else
                    {
                        (item as Figure44).Draw();
                    }
                }
            }
            catch (Exception e)
            {
                s = "There is nothing to draw.";
                ConsIO.WriteLine(s);

            }


        }

    }

    public interface IDrawable
    {
        void Draw();
    }
    public class Figure44:IDrawable
    {
        public virtual void Draw()
        {
            string s = "Drawing Figure from class Figure44";
            ConsIO.WriteLine(s);
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Figure44(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Square44 : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Square44(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw()
        {
            string s = "Drawing Square from class Square44";
            ConsIO.WriteLine(s);
        }
    }
    public class Rectangle44 : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle44(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw()
        {
            string s = "Drawing Rectangle from class Rectangle44";
            ConsIO.WriteLine(s);
        }
    }
}
