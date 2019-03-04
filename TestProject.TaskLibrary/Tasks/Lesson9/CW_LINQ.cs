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
            var numbers = new int[] {1, 1, 1, 2, 2, 1, 3, 3, 2};

            var query = numbers.TakeWhile(n => n == 3);
            ConsIO.WriteLine("query: " + string.Join(" ", query));
            //Console.WriteLine(string.Join(String.Empty, query.Select(p => $"Name: {p.Name}, Age: {p.Age}\n")));

            

            ConsIO.ReadLine();
        }


    }

    
}
