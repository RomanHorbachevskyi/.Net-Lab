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
            list1=new List<int>();
            for (int i = 1; i < 100; i++)
            {
                list1.Add(1);

            }

            ConsIO.WriteLine(list1.Capacity.ToString());
            ConsIO.WriteLine(list1.Count.ToString());
            ConsIO.ReadLine();
        }


    }

    public interface IMyInterface
    {
        string Prop { get; set; }
    }
    
}
