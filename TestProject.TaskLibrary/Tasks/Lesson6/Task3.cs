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
        static readonly Random rndGen =new Random();
        const int strsOnPage = 5;
        const string strChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static List<string> strElements;

        public void Run()
        {
            string str = "*** Now you are in Lesson6.Task3 ***";
            str = str + "\n    Work with List<T>, Part 3";
            ConsIO.WriteLine(str);
            int strLength = 4;
            int strCount = 200;
            string tempStr;

            strElements = new List<string>();

            // Adding rundom strings into the list strElements.
            for (int i = 0; i < strCount; i++)
            {
                strElements.Add(GetRundomStr(strChars,strLength));
            }

            ConsIO.WriteLine($"Old count of elements (before deleting duplicates): {strCount}");

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
            catch (Exception e) {}

            ConsIO.WriteLine($"New count of elements: {strElements.Count}");

            // Creating temporary list for sorting.
            List<string> tempList=new List<string>();
            tempList.AddRange(strElements);
            tempList.Sort();
            int j = strElements.Count;
            int it =j;

            ConsIO.WriteLine($"First and last elements before sorting: {strElements[0]}; {strElements[j-1]}");
            
            for (var i = 0; i < it; i++)
            {
                j-=1;
                strElements[i] = tempList[j];
            }

            ConsIO.WriteLine($"First and last elements after sorting: {strElements[0]}; {strElements[it-1]}\n");

            #region Printing from the list
            int pCount;
            if (it%strsOnPage==0)
            {
                pCount = it / strsOnPage;
            }
            else
            {
                pCount = it / strsOnPage + 1;
            }
            ConsIO.Write($"We have {pCount} pages. Enter the number of page you want to print(>0):");
            int pPrint=0;
            try
            {
                pPrint =Int32.Parse(ConsIO.ReadLine());
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }
            //Int32.TryParse(ConsIO.Read(), out pPrint);
            
            DisplayPage(pPrint, strElements);
            #endregion
        }

        /// <summary>
        /// This method prints needed page from the list.
        ///  Pages quantity calculated basing on the constant strsOnPage (strings on page)
        /// </summary>
        /// <param name="pageNumber"></param>
        public static void DisplayPage(int pageNumber, List<string> listToPrint)
        {
            if (pageNumber <= 0)
            {
                ConsIO.WriteLine("Entered incorrect value, exiting the Task after you press Enter-key");
                ConsIO.ReadLine();
                Environment.Exit(0);
            }

            int pStart = (pageNumber-1) * strsOnPage;
            int pEnd = pStart + strsOnPage;
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
        /// This method generates rundom strings
        /// from characters in constant strChars.
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public static string GetRundomStr(string ch, int strLength)
        {
            char[] str=new char[strLength];
            for (int i = 0; i < strLength; i++)
            {
                str[i] = ch[rndGen.Next(ch.Length)];
            }
            return new string(str);
        }
    }
}
