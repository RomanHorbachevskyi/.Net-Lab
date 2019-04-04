using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using TestProject.Common.Core.Classes;
using TestProject.Properties;

namespace TestProject.TaskSelector
{
    public static class Selector
    {
        public static string nameOfAssembly;

        public static string[] loadedLessons { get; set; }

        public static IEnumerable<Type> loadedTypes;

        public static string WhatToDO()
        {
            ConsIO.WriteLine($"{Resources.WhatDoYouWantToDoCheckAllTasksOrSomeSpecific}");

            string s = ConsIO.ReadLine().ToLower();

            //checking entered text(letter)
            while ((s.ToLower() != Resources.aToCheckAllTasks) & (s.ToLower() != Resources.sToCheckSpecificTask))
            {
                ConsIO.CheckForExitTask(ref s);
                ConsIO.WriteLine(Resources.EnteredIncorrectValue);
                ConsIO.WriteLine(Resources.EnterQOrAOrS);
                s = ConsIO.ReadLine();
            }

            return s;
        }

        private static void ShowLessons()
        {
            int counter = 0;
            string[] lessons = new string[loadedLessons.Length];
            foreach (var loadedLesson in loadedLessons)
            {
                lessons[counter] = loadedLesson.Substring(loadedLesson.IndexOf("Lesson"))
                    .Replace("Lesson", $"{Resources.Lesson} ");
                counter += 1;
                ConsIO.WriteLine(counter + ". " + lessons[counter - 1]);
            }
        }

        private static void ShowTasks(int i, out IOrderedEnumerable<Type> loadedTasks, out string[] taskNames)
        {
            int counter;
            loadedTasks = loadedTypes
                .Where(typ => typ.Namespace != null && typ.Namespace.StartsWith(nameOfAssembly)
                                                    && typ.Namespace.EndsWith(loadedLessons[i - 1]))
                .OrderBy(tsk => tsk.Name);

            taskNames = new string[loadedTasks.Count()];

            counter = 0;
            foreach (var task in loadedTasks)
            {
                taskNames[counter] = task.Name.Replace("Task", $"{Resources.Task} ");
                counter += 1;
                ConsIO.WriteLine($"   {counter}. {taskNames[counter - 1]}");
            }
        }

        public static void RunSpecificTask(string nameOfAssembly)
        {
            int counter = 0;
            string s;
            string[] lessons = new string[loadedLessons.Length];
            ShowLessons();
            
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

            IOrderedEnumerable<Type> loadedTasks;
            string[] taskNames;
            ShowTasks(i,out loadedTasks, out taskNames);
            

            //var loadedTasks = loadedTypes
            //    .Where(typ => typ.Namespace != null && typ.Namespace.StartsWith(nameOfAssembly)
            //                                        && typ.Namespace.EndsWith(loadedLessons[i - 1]))
            //    .OrderBy(tsk => tsk.Name);

            //var taskNames = new string[loadedTasks.Count()];

            //counter = 0;
            //foreach (var task in loadedTasks)
            //{
            //    taskNames[counter] = task.Name.Replace("Task", $"{Resources.Task} ");
            //    counter += 1;
            //    ConsIO.WriteLine($"   {counter}. {taskNames[counter - 1]}");
            //}

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
                if (counter == t - 1)
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
    }
}
