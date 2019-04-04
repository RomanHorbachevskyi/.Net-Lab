using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class Task3 : IRunnable
    {
        const int linesOnPage = 5;
        const string CharsForString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static readonly Random randomGen = new Random();
        static List<string> strElements;

        public void Run()
        {
            List<string> tempList;
            int stringsInList, j;
            int stringLength = 4;
            int stringsCount = 200;
            int pagesCount;
            int pageToPrint = 0;
            string tempStr;
            string str = "*** Now you are in Lesson6.Task3 ***";
            str = str + "\n    Work with List<T>, Part 3\n" +
                  "     Create list with randomly generated strings (n>100), string length = 4,\n" +
                  "     all letters are capital. Remove elements: all repeated and which starts with 'Z'.\n" +
                  "     Sort descending. Print list before and after modifications.\n" +
                  "     Create method DisplayPage() that prints specified page of modified list.\n" +
                  "     If entered value invalid - break task.";
            ConsIO.WriteLine(str);
            

            strElements = new List<string>();

            // Adding random strings into the list strElements.
            for (int i = 0; i < stringsCount; i++)
            {
                strElements.Add(GetRandomStr(CharsForString, stringLength));
            }

            ConsIO.WriteLine($"Old count of elements (before deleting duplicates): {stringsCount}");

            // Removing duplicate elements from the list strElements.
            for (int i = 0; i < strElements.Count; i++)
            {
                tempStr = strElements[i];
                for (int n = 0; n < strElements.Count; n++)
                {
                    if (tempStr== strElements[n])
                    {
                        strElements.RemoveAll(s =>s==tempStr );
                    }
                }
            }

            ConsIO.WriteLine($"Count before deleting elements with first 'Z': {strElements.Count}");

            // Removing elements that begin from 'Z'.
            try
            {
                strElements.RemoveAll(s => s[0] == 'Z');
            }
            // if get exception then we have not any string with first letter 'Z'
            // ignore and go next
            catch (Exception) {}

            ConsIO.WriteLine($"New count of elements: {strElements.Count}");

            // Creating temporary list for sorting.
            tempList=new List<string>();
            tempList.AddRange(strElements);
            tempList.Sort();
            j = strElements.Count;
            stringsInList = j;

            ConsIO.WriteLine($"First and last elements before sorting: {strElements[0]}; {strElements[j-1]}");
            
            for (var i = 0; i < stringsInList; i++)
            {
                j -= 1;
                strElements[i] = tempList[j];
            }

            ConsIO.WriteLine($"First and last elements after sorting: {strElements[0]}; {strElements[stringsInList-1]}\n");

            #region Printing from the list

            if (stringsInList % linesOnPage == 0)
            {
                pagesCount = stringsInList / linesOnPage;
            }
            else
            {
                pagesCount = stringsInList / linesOnPage + 1;
            }
            ConsIO.Write($"We have {pagesCount} pages. Enter the number of page you want to print(>0):");
            
            try
            {
                pageToPrint =int.Parse(ConsIO.ReadLine());
            }
            catch (Exception)
            {
                ConsIO.WriteLine("Entered incorrect value, exiting the Task after you press Enter-key");
                ConsIO.ReadLine();
                Environment.Exit(0);
            }
            
            DisplayPage(pageToPrint, strElements);

            #endregion
            ConsIO.ReadLine();
        }

        /// <summary>
        /// This method prints needed page from the list.
        ///  Pages quantity calculated basing on the constant linesOnPage (strings on page)
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="listToPrint"></param>
        public static void DisplayPage(int pageNumber, List<string> listToPrint)
        {
            if (pageNumber <= 0)
            {
                ConsIO.WriteLine("Entered incorrect value, exiting the Task after you press Enter-key");
                ConsIO.ReadLine();
                Environment.Exit(0);
            }

            int pStart = (pageNumber-1) * linesOnPage;
            int pEnd = pStart + linesOnPage;
            if (pEnd > listToPrint.Count)
                pEnd = listToPrint.Count;
            for (int i = pStart; i < pEnd; i++)
            {
                ConsIO.WriteLine(listToPrint[i]);
            }
            ConsIO.WriteLine("Printing successful.");
            ConsIO.ReadLine();
        }

        /// <summary>
        /// This method generates random strings
        /// from characters in constant CharsForString.
        /// </summary>
        /// <param name="charsForString"></param>
        /// <param name="stringLength"></param>
        /// <returns></returns>
        public static string GetRandomStr(string charsForString, int stringLength)
        {
            char[] str=new char[stringLength];
            for (int i = 0; i < stringLength; i++)
            {
                str[i] = charsForString[randomGen.Next(charsForString.Length)];
            }
            return new string(str);
        }
    }
}
