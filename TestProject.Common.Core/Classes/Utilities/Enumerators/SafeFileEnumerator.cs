
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace TestProject.Common.Core.Classes.Utilities.Enumerators
{
    public static class SafeFileEnumerator
    {
        /// <summary>
        /// Gets a List of IEnumerable(string) directories.
        /// Directories with UnauthorizedAccessException are ignored.
        /// </summary>
        /// <param name="parentDirectory">Directory where to search.</param>
        /// <param name="searchPattern">Pattern (mask) to search for.</param>
        /// <param name="searchOpt">Search option. AllDirectories or TopDirectoryOnly</param>
        /// <returns></returns>
        public static IEnumerable<string> EnumerateDirectories(string parentDirectory, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var directories = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    directories = Directory.EnumerateDirectories(parentDirectory)
                        .SelectMany(x => EnumerateDirectories(x, searchPattern, searchOpt));
                }
                return directories.Concat(Directory.EnumerateDirectories(parentDirectory, searchPattern)).ToList();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Enumerable.Empty<string>().ToList();
            }
        }

        /// <summary>
        /// Gets a List of IEnumerable(string) files.
        /// Directories/files with UnauthorizedAccessException are ignored.
        /// </summary>
        /// <param name="path">Directory where to search.</param>
        /// <param name="searchPattern">Pattern (mask) to search for.</param>
        /// <param name="searchOpt">Search option. AllDirectories or TopDirectoryOnly</param>
        /// <returns></returns>
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var dirFiles = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    dirFiles = Directory.EnumerateDirectories(path)
                        .SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));
                }
                return dirFiles.Concat(Directory.EnumerateFiles(path, searchPattern)).ToList();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Enumerable.Empty<string>().ToList();
            }
        }
    }
}
