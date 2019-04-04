
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TestProject.Common.Core.Classes
{
    public static class TasksInProjectByDictionary
    {
        private static string parentPath = @"d:\!_Documents_!\_EPAM_\_Training_\GIT\"+
                                           @"Repository_Template\.Net-Lab\TestProject.TaskLibrary\Tasks\";
        private static SortedDictionary<string, SortedDictionary<string, string>> lessonsAndTasks =
            new SortedDictionary<string, SortedDictionary<string, string>>();

        /// <summary>
        /// Gets Lessons(folders) list of nested
        /// Tasks(files) lists.
        /// </summary>
        /// <returns></returns>
        public static SortedDictionary<string, SortedDictionary<string, string>> GetLessonsAndTasks()
        {
            //lessonsAndTasks = new Dictionary<string, Dictionary<string, string>>();
            DirectoryInfo dirs = new DirectoryInfo(parentPath);
            DirectoryInfo fTaks;
            SortedDictionary<string, string> tasks;
            foreach (var dir in dirs.GetDirectories())
            {
                fTaks  = new DirectoryInfo(dir.FullName);
                fTaks.GetFiles();
                tasks = new SortedDictionary<string, string>();
                foreach (var file in fTaks.GetFiles())
                {
                    tasks.Add(file.Name, file.FullName);
                }
                lessonsAndTasks.Add(dir.Name, tasks);
            }

            return lessonsAndTasks;
        }
    }
}
