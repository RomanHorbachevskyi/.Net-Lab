using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestProject.Common.Core.Classes
{
    public class TasksInProjectByReflection
    {

        public static string NameOfAssemblyToLoad { get; set; } = "TestProject.TaskLibrary";

        private static Assembly loadedAssembly = Assembly.Load(NameOfAssemblyToLoad);

        public static IEnumerable<Type> LoadedTypes { get; } = loadedAssembly
            .GetExportedTypes()
            .OrderBy(typ => typ.FullName)
            .Where(typ => typ.Namespace != null && typ.Namespace.StartsWith(NameOfAssemblyToLoad)
                                                && typ.Namespace.Contains("Lesson")
                                                && typ.GetMember("Run").Length == 1);


        // Names of lessons without another namespaces
        public static string[] LoadedLessons { get; } = LoadedTypes
            //.Where(tsk => tsk.Namespace.Contains("Lesson"))
            .OrderBy(lsn => lsn.FullName)
            .Select(lsn => lsn.Namespace).Distinct().ToArray();
    }
}
