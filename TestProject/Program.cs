using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using TestProject.Common.Core.Interfaces;
using TestProject.TaskLibrary.Tasks.Lesson1;
using TestProject.TaskLibrary.Tasks.Lesson2;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of .NetLab Tasks
            var tasks = new IRunnable[]
            {
                new TaskLibrary.Tasks.Lesson1.Task1(),
                new TaskLibrary.Tasks.Lesson1.Task2(),
                new TaskLibrary.Tasks.Lesson2.Task1(),
                new TaskLibrary.Tasks.Lesson2.Task2(),
                new TaskLibrary.Tasks.Lesson2.Task3(),

            };
            
            Console.WriteLine("***** Instructions *****");
            Console.WriteLine("When you are in the Task, to Quit testing press \"q\" or \"b\".\n" +
                              "To proceed next press 'Enter' key.");
            Console.ReadLine();

            NextTask:
            Console.WriteLine("What do you want to do, check All Tasks (\"a\") or some specific (\"s\"):");
            string s = Console.ReadLine().ToLower();
            
            //checking entered text(letter)
            while ((s != "a") & (s != "s"))
            {
                if ((s == "q") | (s == "b"))
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Entered incorrect value.\nEnter \"q\" or \"a\" or \"s\"");
                s = Console.ReadLine();
            }
            
            //creating the array to make possible Task selection
            string[] ATasks = new string[tasks.Length];

            
            int i = 0;
            if (s == "s")
            {
                Console.WriteLine("\n*** There are {0} Tasks: ***", tasks.Length);
                foreach (var task in tasks)
                {
                    Console.WriteLine(i+ ":   "+ task.ToString());
                    ATasks[i] = task.ToString();
                    ++i;
                    //task.ToString();
                }
                Console.WriteLine("\nChoose needed one:");
                s = Console.ReadLine();
                while ((!Int32.TryParse(s, out i)))
                {
                    Console.WriteLine("Entered incorrect value.\nEnter only digits: ");
                    s = Console.ReadLine();
                }

                foreach (var task in tasks)
                {
                    if (ATasks[i] != task.ToString())
                    {
                        /*ATasks[i].ToString();
                        task.ToString(); */
                    }
                    else
                    {
                        task.Run();
                        break;
                    }
                }

                goto NextTask;
            }
            else if (s == "a")
            {
                //Console.ReadLine();
                foreach (var task in tasks)
                {
                    task.Run();
                }

                Console.ReadLine();
            }
        }
    }
}
