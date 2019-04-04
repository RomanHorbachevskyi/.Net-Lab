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
using TestProject.TaskSelector;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
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
            if (!String.IsNullOrEmpty(culture))
            {
                CultureInfo ci = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                ConsIO.OutputEncoding = Encoding.Unicode;
            }

            ConsIO.WriteLine($"***** {Resources.Instructions} *****");
            ConsIO.WriteLine($"{Resources.WhenYouAreInTheTasktoQuitTestingPressQOrB}\n");

            string nameOfAssembly = "TestProject.TaskLibrary";
            TasksInProjectByReflection.NameOfAssemblyToLoad = nameOfAssembly;
            
            var loadedTypes = TasksInProjectByReflection.LoadedTypes;

            // Names of lessons without another namespaces
            string[] loadedLessons = TasksInProjectByReflection.LoadedLessons;

            string s;

            NextTask:
            s = Selector.WhatToDO();

            //ConsIO.WriteLine($"{Resources.WhatDoYouWantToDoCheckAllTasksOrSomeSpecific}");

            //s = ConsIO.ReadLine().ToLower();

            ////checking entered text(letter)
            //while ((s.ToLower() != Resources.aToCheckAllTasks) & (s.ToLower() != Resources.sToCheckSpecificTask))
            //{
            //    ConsIO.CheckForExitTask(ref s);
            //    ConsIO.WriteLine(Resources.EnteredIncorrectValue);
            //    ConsIO.WriteLine(Resources.EnterQOrAOrS);
            //    s = ConsIO.ReadLine();
            //}

            if (s== Resources.sToCheckSpecificTask)
            {
                ConsIO.WriteLine();

                int counter = 0;
                string[] lessons = new string[loadedLessons.Length];
                
                foreach (var loadedLesson in loadedLessons)
                {
                    lessons[counter] = loadedLesson.Substring(loadedLesson.IndexOf("Lesson"))
                        .Replace("Lesson", $"{Resources.Lesson} ");
                    counter += 1;
                    ConsIO.WriteLine(counter + ". " + lessons[counter - 1]);
                }
                
                int i = 0;
                int t = 0;
                
                ConsIO.Write($"\n{Resources.ChooseNeededLessonFromListAbove} ({Resources.numbersOnLeft}): ");
                
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                while ((!Int32.TryParse(s, out i)) | (i > lessons.Length))
                {
                    ConsIO.WriteLine(Resources.EnteredIncorrectValue);
                    ConsIO.WriteLine($"{Resources.EnterOnlyDigitsInsideBounds} ");
                    s = ConsIO.ReadLine();
                    ConsIO.CheckForExitTask(ref s);
                }

                var loadedTasks = loadedTypes
                    .Where(typ => typ.Namespace != null && typ.Namespace.StartsWith(nameOfAssembly)
                                                        && typ.Namespace.EndsWith(loadedLessons[i-1]))
                    .OrderBy(tsk => tsk.Name);

                var taskNames = new string[loadedTasks.Count()];

                counter = 0;
                foreach (var task in loadedTasks)
                {
                    taskNames[counter] = task.Name.Replace("Task", $"{Resources.Task} ");
                    counter += 1;
                    ConsIO.WriteLine($"   {counter}. {taskNames[counter - 1]}");
                }
                
                ConsIO.Write($"\n{Resources.ChooseNeededTaskFromListAbove} {Resources.numbersOnLeft} ",
                    taskNames.Length);
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                while ((!int.TryParse(s, out t)) | (t > taskNames.Length))
                {
                    ConsIO.WriteLine(Resources.EnteredIncorrectValue);
                    ConsIO.WriteLine($"{Resources.EnterOnlyDigitsInsideBounds} ");
                    s = ConsIO.ReadLine();
                    ConsIO.CheckForExitTask(ref s);
                }

                counter = 0;
                foreach (var loadedTask in loadedTasks)
                {
                    if (counter == t-1)
                    {
                        Type type = loadedTypes.First(typ => typ == loadedTask);
                        
                        var instance = Activator.CreateInstance(type);
                        MethodInfo taskInfo = loadedTask.GetMethod("Run", BindingFlags.Instance | BindingFlags.Public);
                        taskInfo.Invoke(instance, null);
                        break;
                    }

                    counter += 1;
                }
                
            }
            else if (s==Resources.aToCheckAllTasks)
            {
                foreach (var task in loadedTypes)
                {
                    Type type = loadedTypes.First(typ => typ == task);
                    var instance = Activator.CreateInstance(type);
                    MethodInfo taskInfo = task.GetMethod("Run", BindingFlags.Instance | BindingFlags.Public);
                    taskInfo.Invoke(instance, null);
                }
                ConsIO.ReadLine();
            }
            goto NextTask;
        }
    }
}
