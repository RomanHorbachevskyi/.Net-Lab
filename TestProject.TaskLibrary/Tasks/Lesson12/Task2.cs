using System.IO;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Classes.Utilities.Enumerators;

namespace TestProject.TaskLibrary.Tasks.Lesson12
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string partialName;
            string extension;
            DirectoryInfo dirInfo;
            string folderPath;
            SearchOption searchOption;

            ConsIO.Clear();
            string s = "*** Now you are in Lesson12.Task2 ***\n    Create an application that can search a '.txt' file," +
                       "\n      with specified partial name of the file.\n" +
                       "\n  Enter the partial name you want to look for.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            partialName = "*" + s + "*";
            ConsIO.Write("Enter an extension for files you are looking for (e.g. '.txt'):  ");
            extension = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref extension);

            ConsIO.Write($"Enter the directory you want to search in:  ");
            folderPath = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref folderPath);
            dirInfo = new DirectoryInfo(folderPath);
            while (dirInfo.Exists==false)
            {
                ConsIO.Write($"Entered directory does not exist, enter new path:  ");
                folderPath = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref folderPath);
                dirInfo = new DirectoryInfo(folderPath);
            }
            
            ConsIO.Write("\nDo you want to search in the subdirectories too? [Y]es or [N]o:  ");
            s = ConsIO.ReadLine().ToLower();
            ConsIO.CheckForExitTask(ref s);
            while (Validators.IsCorrectStringValue(ref s, "y", "n")==false)
            {
                ConsIO.Write("\nEntered incorrect value. Only 'Y' or 'N':  ");
                s = ConsIO.ReadLine().ToLower();
                ConsIO.CheckForExitTask(ref s);
            }
            
            searchOption = s.ToLower()=="y" ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (string file in SafeFileEnumerator.EnumerateFiles(dirInfo.FullName, 
                partialName + extension, searchOption))
            {
                ConsIO.WriteLine(file);
            }
            
            ConsIO.WriteLine("\n\n");
            ConsIO.ReadLine();
        }
    }
}
