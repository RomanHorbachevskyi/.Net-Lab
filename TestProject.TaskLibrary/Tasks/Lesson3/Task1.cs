using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;


namespace TestProject.TaskLibrary.Tasks.Lesson3
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            string s;
            s = "*** Now you are in Lesson3.Task1 ***" +
                "\n    Create structure Person and compare Age with entered number";
            ConsIO.WriteLine(s);

            Person p1 = new Person();

            #region Setting properties for person
            s = "Set Name:";
            ConsIO.WriteLine(s);
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            p1.Name = ConsIO.ReadLine();
            s = "Set Surname:";
            ConsIO.WriteLine(s);
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            p1.Surname = ConsIO.ReadLine();
            s = "Set Age:";
            ConsIO.WriteLine(s);
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            s= ConsIO.ReadLine();
            int n;
            while (!Int32.TryParse(s, out n) || n <= 0)
            {
                s = "Incorrect value. Enter only positive integer number.";
                ConsIO.WriteLine(s);
                s = ConsIO.ReadLine();
            }
            p1.Age = n;
            s = "\nEnter value to compare age:";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            p1.CompAge(ref s);
            s = "";
            ConsIO.ReadLine();
            #endregion



            //int[] i = {1, 2, 3};
            /*ConsIO.Write(ref s,1,2,3 );
            string s1=ConsIO.Read();
            ConsIO.Write(ref s1);
            ConsIO.Read();
            Console.WriteLine("*** Now you are in Lesson3.Task1 ***");
            Console.WriteLine ("    Hello, world!\n");*/
        }
    }

    public struct Person
    {
        //private string Name;
        //private string SName;
        //private int Age;
        
        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        #endregion


        public void CompAge(ref string N)
        {
            int n;
            string s;
            if ((N == "q") | (N == "b"))
            {
                Environment.Exit(0);
            }
            while (!Int32.TryParse(N, out n)||n<=0)
            {
                s = "Incorrect value. Enter only positive integer number.";
                ConsIO.WriteLine(s);
                s = ConsIO.ReadLine();
                this.CompAge(ref s);
            }

            if (Age > n)
            {
                s = "{0} {1} older than {2}";
                ConsIO.WriteLine(s,Name,Surname,n);
            }
            else if (Age<n)
            {
                s = "{0} {1} younger than {2}";
                ConsIO.WriteLine(s, Name, Surname, n);
            }
            else
            {
                s = "{0} {1} age equals {2}";
                ConsIO.WriteLine(s, Name, Surname, n);
            }
        }
    }
}
