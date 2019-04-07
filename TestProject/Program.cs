using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestProject.Classes.TaskSelector;
using TestProject.Classes;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Properties;
using TestProject.TaskLibrary.Tasks.Lesson1;
using TestProject.TaskLibrary.Tasks.Lesson2;
using TestProject.TaskLibrary.Tasks.Lesson3;
using TestProject.TaskLibrary.Tasks.Lesson4;
using TestProject.TaskLibrary.Tasks.Lesson5;
using TestProject.TaskLibrary.Tasks.Lesson6;
using TestProject.TaskLibrary.Tasks.Lesson8;
using TestProject.TaskLibrary.Tasks.Lesson9;
using TestProject.TaskLibrary.Tasks.Lesson11;

namespace TestProject
{
    class Program
    {
        public static volatile string CurrentCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public static Dictionary<string, string> CultureDictionary =
            new Dictionary<string, string>{{"uk", "uk-UA"}};

        static void Main(string[] args)
        {
            string culture = CultureDictionary[CurrentCulture];
            string tempS;

            if (!String.IsNullOrEmpty(culture))
            {
                CultureInfo ci = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                ConsIO.OutputEncoding = Encoding.Unicode;
            }

            ConsIO.WriteLine($"***** {Resources.Instructions} *****");
            ConsIO.WriteLine($"{Resources.WhenYouAreInTheTasktoQuitTestingPressQOrB}\n");
            
            var loader = new AssemblyLoader();
            var lNewTypes = loader.LoadedPublicRunnableTypes;
            var taskManager = new TaskManager(loader.AssemblyName, lNewTypes);
            var selector = new Selector(loader.AssemblyName, taskManager);

            do
            {
                tempS = selector.WhatToDo();

                if (tempS == Resources.LetterSForSpecificTask)
                {
                    ConsIO.WriteLine();
                    selector.Show();
                    
                    int i = 0;
                    
                    do
                    {
                        tempS = ConsIO.ReadLine();
                        Classes.Validators.CheckForExitTask(ref tempS);
                        selector.TryGetIndex(ref tempS, ref i);
                        selector.SelectMemberByIndex(i);
                    } while (selector.TaskWasRunning == false);
                }
                else if (tempS == Resources.LetterAToCheckAllTasks)
                {
                    foreach (var (key, task) in taskManager.AllTasks)
                    {
                        selector.Run(task);
                    }
                }
            } while (tempS.ToLower() != Resources.qToQuitTesting.ToLower() | tempS.ToLower() != Resources.bToQuitTesting.ToLower());
        }
    }
}
