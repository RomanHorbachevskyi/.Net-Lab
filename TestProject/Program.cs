using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.TaskLibrary.Tasks.Lesson1;
using TestProject.TaskLibrary.Tasks.Lesson2;
using TestProject.TaskLibrary.Tasks.Lesson3;
using TestProject.TaskLibrary.Tasks.Lesson4;
using TestProject.TaskLibrary.Tasks.Lesson5;
using TestProject.TaskLibrary.Tasks.Lesson6;
using TestProject.TaskLibrary.Tasks.Lesson8;

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
                new TaskLibrary.Tasks.Lesson2.Task4(),
                new TaskLibrary.Tasks.Lesson2.Task5(),
                new TaskLibrary.Tasks.Lesson3.Task1(),
                new TaskLibrary.Tasks.Lesson3.Task2(),
                new TaskLibrary.Tasks.Lesson4.OptTask1(),
                new TaskLibrary.Tasks.Lesson4.Task1(),
                new TaskLibrary.Tasks.Lesson4.Task2(),
                new TaskLibrary.Tasks.Lesson4.Task3(),
                new TaskLibrary.Tasks.Lesson4.Task4(),
                new TaskLibrary.Tasks.Lesson5.CW_Task1(),
                new TaskLibrary.Tasks.Lesson5.Task1(),
                new TaskLibrary.Tasks.Lesson5.Task2(),
                new TaskLibrary.Tasks.Lesson5.Task3(),
                new TaskLibrary.Tasks.Lesson5.Task4(),
                new TaskLibrary.Tasks.Lesson5.Task5(),
                new TaskLibrary.Tasks.Lesson6.CW_Task1(),
                new TaskLibrary.Tasks.Lesson6.CW_Task2(),
                new TaskLibrary.Tasks.Lesson6.Task1(),
                new TaskLibrary.Tasks.Lesson6.Task2(),
                new TaskLibrary.Tasks.Lesson6.Task3(),
                new TaskLibrary.Tasks.Lesson6.OptTask1(),
                new TaskLibrary.Tasks.Lesson6.OptTask2(),
                new TaskLibrary.Tasks.Lesson8.OptTask1(),
                new TaskLibrary.Tasks.Lesson8.Task1(),
                new TaskLibrary.Tasks.Lesson9.Task1_4(),
                new TaskLibrary.Tasks.Lesson9.Task5(),
                
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
                while ((!Int32.TryParse(s, out i)) | (i-1>tasks.Length))
                {
                    Console.WriteLine("Entered incorrect value.\nEnter only digits inside bounds: ");
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
