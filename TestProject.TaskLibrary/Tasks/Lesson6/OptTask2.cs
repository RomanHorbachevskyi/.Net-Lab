using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class OptTask2 : IRunnable
    {
        public void Run()
        {

            string s = "*** Now you are in Lesson6.OptTask2 ***";
            s = s + "\n    Work with Observable Collection. Checking at home an example from the lecture.";
            ConsIO.WriteLine(s);

            var observableCollection = new ObservableCollection<MyClass>();
            observableCollection.Add(new MyClass{Id=1});

            observableCollection.CollectionChanged += ObservableCollection_CollectionChanged;
            
            observableCollection.Add(new MyClass{Id=2});
            observableCollection.RemoveAt(0);

            ConsIO.ReadLine();
        }

        public static void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ConsIO.WriteLine("Action: "+ e.Action);
            if (e.OldItems != null)
            {
                ConsIO.WriteLine("Old items: ");
                foreach (var item in e.OldItems) ConsIO.WriteLine((item as MyClass).Id.ToString());
            }

            if (e.NewItems != null)
            {
                ConsIO.WriteLine("New items:");
                foreach (var item in e.NewItems) ConsIO.WriteLine((item as MyClass).Id.ToString());
            }
        }
    }

    
}
