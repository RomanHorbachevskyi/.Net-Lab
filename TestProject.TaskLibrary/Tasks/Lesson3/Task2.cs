using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;


namespace TestProject.TaskLibrary.Tasks.Lesson3
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string s;
            s = "*** Now you are in Lesson3.Task2 ***" +
                "\n    Interfaces ISize, ICoordinates; structure Rectangle with these interfaces";
            ConsIO.WriteLine(s);
            Rectangle32 rec = new Rectangle32
            {
                Height = 10,
                Width = 20
            };
            s = "Rectangle perimeter = {0}";
            ConsIO.WriteLine(s, rec.Perimeter());
            ConsIO.ReadLine();
        }
    }

    #region Interfaces
    public interface ISize
    {
        int Width { get; set; }
        int Height { get; set; }

        int Perimeter();
    }

    public interface ICoordinates
    {
        int X { get; set; }
        int Y { get; set; }
    }
    #endregion

    public struct Rectangle32:ISize,ICoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width{get;set;}
        public int Height { get; set; }

        public int Perimeter()
        {
            return 2 * (Width + Height);
        }
    }

}
