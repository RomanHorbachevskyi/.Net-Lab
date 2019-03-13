using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson12
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            DirectoryInfo dirInfo;
            DirectoryInfo[] subDirs;
            FileInfo[] filesInDir;
            DirectoryInfo[] tempSubDirs;
            FileInfo[] tempFilesInDir;

            ConsIO.Clear();
            string s = "*** Now you are in Lesson12.Task1 ***\n    Show contents of the specified folder as list of files," +
                       "\n      subdirectories and their contents.\n" +
                       "\n  Enter the directory path you want work with.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            dirInfo = new DirectoryInfo(s);
            ConsIO.WriteLine($"Now we are at the directory: {dirInfo}");
            subDirs = dirInfo.GetDirectories();
            filesInDir = dirInfo.GetFiles();

            ConsIO.WriteLine($"It includes {subDirs.Length} subdirectories and {filesInDir.Length} files.\n\n");
            foreach (var dir in subDirs)
            {
                ConsIO.WriteLine(dir.Name + "\\");
            }
            foreach (var file in filesInDir)
            {
                ConsIO.WriteLine(file.Name);
            }
            ConsIO.WriteLine();
            foreach (var dir in subDirs)
            {
                try
                {
                    tempSubDirs = dir.GetDirectories();
                    tempFilesInDir = dir.GetFiles();
                }
                catch (System.IO.IOException)
                {
                    continue;
                }
                catch (System.UnauthorizedAccessException)
                {
                    continue;
                }
                
                ConsIO.WriteLine("\n\n" + dir.FullName + "\\" + "    has " + tempSubDirs.Length + " directories\n" +
                                 "  and " + tempFilesInDir.Length + " files.");
                foreach (var tempSubDir in tempSubDirs)
                {
                    ConsIO.WriteLine(tempSubDir.Name + "\\");
                }
                foreach (var tempFile in tempFilesInDir)
                {
                    ConsIO.WriteLine(tempFile.Name);
                }

            }
            //ConsIO.WriteLine();

            ConsIO.WriteLine("\n\n");

        }

        

    }
    
    
}
