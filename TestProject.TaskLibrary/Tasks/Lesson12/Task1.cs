using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities.Enumerators;

namespace TestProject.TaskLibrary.Tasks.Lesson12
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            DirectoryInfo dirInfo;
            //DirectoryInfo[] subDirs;
            List<string> subDirs;
            //FileInfo[] filesInDir;
            List<string> filesInDir;
            //DirectoryInfo[] tempSubDirs;
            List<string> tempSubDirs;
            //FileInfo[] tempFilesInDir;
            List<string> tempFilesInDir;

            ConsIO.Clear();
            string s = "*** Now you are in Lesson12.Task1 ***\n    Show contents of the specified folder as list of files," +
                       "\n      subdirectories and their contents.\n" +
                       "\n  Enter the directory path you want work with.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            dirInfo = new DirectoryInfo(s);
            while (dirInfo.Exists == false)
            {
                ConsIO.Write($"Entered directory does not exist, enter new path:  ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                dirInfo = new DirectoryInfo(s);
            }
            ConsIO.WriteLine($"Now we are at the directory: {dirInfo}");
            
            subDirs =(List<string>)  SafeFileEnumerator.EnumerateDirectories(dirInfo.FullName, "*", SearchOption.TopDirectoryOnly);
            
            filesInDir = (List<string>) SafeFileEnumerator.EnumerateFiles(dirInfo.FullName, "*",
                SearchOption.TopDirectoryOnly);

            ConsIO.WriteLine($"It includes {subDirs.Count} subdirectories and {filesInDir.Count} files.\n\n");
            foreach (var dir in subDirs)
            {
                ConsIO.WriteLine(dir + "\\");
            }
            foreach (var file in filesInDir)
            {
                ConsIO.WriteLine(file);
            }
            ConsIO.WriteLine();
            foreach (var dir in subDirs)
            {
                tempSubDirs = (List<string>)
                    SafeFileEnumerator.EnumerateDirectories(dir, "*",
                        SearchOption.TopDirectoryOnly);
                tempFilesInDir = (List<string>)SafeFileEnumerator.EnumerateFiles(dir, "*",
                    SearchOption.TopDirectoryOnly);
                

                ConsIO.WriteLine("\n\n" + dir + "\\" + "    has " + tempSubDirs.Count + " directories\n" +
                                 "  and " + tempFilesInDir.Count + " files.");

                foreach (var tempSubDir in tempSubDirs)
                {
                    ConsIO.WriteLine(tempSubDir + "\\");
                }
                foreach (var tempFile in tempFilesInDir)
                {
                    ConsIO.WriteLine(tempFile);
                }

            }
            
            ConsIO.WriteLine("\n\n");
        }
    }
}
