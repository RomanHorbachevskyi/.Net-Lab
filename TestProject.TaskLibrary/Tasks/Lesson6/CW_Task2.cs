using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class CW_Task2 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson6.CW_Task2 ***";
            s = s + "\n    Checking how works example from lecture";
            ConsIO.WriteLine(s);

            var alphabet=new SortedDictionary<string,int>();
            alphabet.Add("B",23);
            alphabet.Add("C", 11);
            alphabet.Add("A", 15);

            foreach (var key in alphabet.Keys) ConsIO.WriteLine($"key: {key}, value: {alphabet[key]}");

            ConsIO.ReadLine();
        }
    }
}
