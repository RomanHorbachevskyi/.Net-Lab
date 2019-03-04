using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class OptTask1 : IRunnable
    {
        public void Run()
        {

            string s = "*** Now you are in Lesson6.OptTask1 ***";
            s = s + "\n    Work with Dictionary";
            ConsIO.WriteLine(s);
            
            var dictionary=new Dictionary<MyClass,string>();
            var obj1 = new MyClass { Prop = "s1"};
            var obj2 = new MyClass { Prop = "s2"};

            dictionary.Add(obj1, "some value 1");
            dictionary.Add(obj2, "some value 2");

            var obj3 = new MyClass { Prop = "s1" };

            dictionary.Add(obj3, "some value 1");

            ConsIO.WriteLine("value is: " + dictionary[obj1]);
            ConsIO.WriteLine("value is: " + dictionary[obj3]);

            //ConsIO.WriteLine();
            ConsIO.ReadLine();
        }
    }

    public class MyClass
    {
        public string Prop { get; set; }
        public int Id { get; set; }
    }
}
