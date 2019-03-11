using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson9
{
    public class CW_LINQ : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson9.CW_LINQ ***";
            s = s + "\n    Work with LINQ. Checking at home an example from the lecture. (query -> .TakeWhile() )";
            ConsIO.WriteLine(s);
            var numbers = new int[] {1, 1, 1, 2, 2, 1, 3, 3, 2};

            var query = numbers.TakeWhile(n => n == 3);
            // getting blank string
            ConsIO.WriteLine("query: " + string.Join(" ", query));
            
            ConsIO.ReadLine();
        }
    }
}
