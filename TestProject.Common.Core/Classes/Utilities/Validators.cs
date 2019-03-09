
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TestProject.Common.Core.Classes.Utilities
{
    public static class Validators
    {
        /// <summary>
        /// Returns integer number >0
        /// </summary>
        /// <param name="s">String to read number(parse) from</param>
        /// <returns></returns>
        public static int GetIntPositiveNumber(string s)
        {
            ConsIO.CheckForExitTask(ref s);
            int value;
            while ((Int32.TryParse(s, out value) == false) || (value <= 0))
            {
                ConsIO.WriteLine("Entered incorrect value. Enter only positive integer numbers.");
                s = ConsIO.ReadLine();
                GetIntPositiveNumber(s);
            }
            return value;
        }

        /// <summary>
        /// Returns integer quantity (number)
        /// </summary>
        /// <param name="s">String to read number(parse) from</param>
        /// <returns></returns>
        public static int GetIntNumber(string s)
        {
            ConsIO.CheckForExitTask(ref s);
            int value;
            while ((Int32.TryParse(s, out value) == false))
            {
                ConsIO.WriteLine("Entered incorrect value. Enter only integer numbers.");
                s = ConsIO.ReadLine();
                GetIntNumber(s);
            }
            return value;
        }

        /// <summary>
        /// Returns double number >0
        /// </summary>
        /// <param name="s">String to read number(parse) from</param>
        /// <returns></returns>
        public static double GetDoublePositiveNumber(string s)
        {
            ConsIO.CheckForExitTask(ref s);
            double value;
            while ((double.TryParse(s, out value) == false) || (value <= 0))
            {
                ConsIO.WriteLine("Entered incorrect value. Enter only positive double numbers.");
                s = ConsIO.ReadLine();
                GetDoublePositiveNumber(s);
            }
            return value;
        }

        /// <summary>
        /// Returns double quantity (number)
        /// </summary>
        /// <param name="s">String to read number(parse) from</param>
        /// <returns></returns>
        public static double GetDoubleNumber(string s)
        {
            ConsIO.CheckForExitTask(ref s);
            double value;
            while ((double.TryParse(s, out value) == false))
            {
                ConsIO.WriteLine("Entered incorrect value. Enter only double numbers.");
                s = ConsIO.ReadLine();
                GetDoubleNumber(s);
            }
            return value;
        }

        /// <summary>
        /// Returns index iniside bounds else asks to enter value one more time.
        /// </summary>
        /// <param name="i">Index</param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static int GetCorrectIndexInsideBounds(int i, ref int lowerBound, ref int upperBound)
        {
            string s;
            while ((i < lowerBound) | (i > upperBound))
            {
                ConsIO.WriteLine($"Entered incorrect value. Enter number between {lowerBound} and {upperBound} including both.");
                s = ConsIO.ReadLine();
                i = GetIntNumber(s);
            }

            return i;
        }

        public static bool IsCorrectStringValue(ref string value, params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (value.ToLower()==values[i].ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
