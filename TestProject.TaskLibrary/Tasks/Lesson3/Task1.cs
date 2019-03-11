using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;


namespace TestProject.TaskLibrary.Tasks.Lesson3
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            string s;
            
            s = "*** Now you are in Lesson3.Task1 ***" +
                "\n    Create structure Person and compare Age with entered number (age)";
            ConsIO.WriteLine(s);

            var p1 = new Person();

            #region Setting properties for person

            s = "Set Name:";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            p1.Name = s;

            s = "Set Surname:";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            p1.Surname = s;

            s = "Set Age:";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            p1.Age = Validators.GetIntPositiveNumber(s);

            #endregion

            s = "\nEnter value to compare age:";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            p1.CompareAge(Validators.GetIntPositiveNumber(s));
        }
    }

    public struct Person
    {
        #region Properties

        /// <summary>
        /// Name of Person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of Person.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Age of Person.
        /// </summary>
        public int Age { get; set; }
        
        #endregion

        /// <summary>
        /// Compares age of person with specified.
        /// </summary>
        /// <param name="age">Age to compare with</param>
        public void CompareAge(int age)
        {
            string s;
            if (Age > age)
            {
                s = "{0} {1} older than {2}";
                ConsIO.WriteLine(s,Name, Surname, age);
            }
            else if (Age< age)
            {
                s = "{0} {1} younger than {2}";
                ConsIO.WriteLine(s, Name, Surname, age);
            }
            else
            {
                s = "{0} {1} age equals {2}";
                ConsIO.WriteLine(s, Name, Surname, age);
            }
        }
    }
}
