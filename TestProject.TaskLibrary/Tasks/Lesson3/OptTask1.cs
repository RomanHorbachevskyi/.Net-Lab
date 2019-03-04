using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson3
{
    public class OptTask1 : IRunnable
    {
        public void Run()
        {
            string s;
            s = "*** Now you are in Lesson3.OptTask1 ***\n    Work with [Flags] enum";
            ConsIO.WriteLine(s);

            var day = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine((day & Days.Friday) == Days.Friday); //True
            Console.WriteLine((day & Days.Sunday) == Days.Sunday); //False
            Console.WriteLine(day);

            var strDays = "Monday, Wednesday, Sun, Thursday";
            Days days;
            bool success = Enum.TryParse<Days>(strDays, out days);
            Console.WriteLine(string.Empty);
            if (success)
            {
                Console.WriteLine(days + "\n");
            }
            foreach (int i in Enum.GetValues(typeof(Days)))
                Console.WriteLine(i);
            foreach (string i in Enum.GetNames(typeof(Days)))
                Console.WriteLine(i);
            ConsIO.ReadLine();
        }
        [Flags]
        public enum Days
        {
            Sunday = 64,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32
        }

    }

    
}
