using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class CW_Task1 : IRunnable
    {
        public void Run()
        {
            List<int> list1;
            string s = "*** Now you are in Lesson6.CW_Task1 ***";
            s = s + "\n    Checking how works example from lecture";
            ConsIO.WriteLine(s);
            list1=new List<int>();
            for (int i = 1; i < 3; i++)
            {
                list1.Add(1);

            }
            var list2 = new List<int>(list1) {4, 5};
            ConsIO.WriteLine("Capacity: " + list2.Capacity);
            ConsIO.WriteLine("Count: " + list2.Count + "\n");
            foreach (var item in list2)
            {
                ConsIO.WriteLine(item.ToString());
            }

            ConsIO.ReadLine();
        }
    }

    
    
}
