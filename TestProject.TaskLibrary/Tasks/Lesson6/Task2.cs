using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson6.Task2 ***";
            s = s + "\n    Work with List<T>, Part 2\n" +
                "   Add to list 2 more persons using method \"AddRange\".\n" +
                "   Print phone numbers of all persons without LINQ.";
            ConsIO.WriteLine(s);

            List<Person> persons = new List<Person>()
            {
                new Person("Person1", 10, new string[] {"1234", "16543","19876"}),
                new Person("Person2", 20, new string[] {"2234", "26543","29876"}),
                new Person("Person3", 30, new string[] {"3234", "36543","39876"}),
                new Person("Person4", 40, new string[] {"4234", "46543","49876"}),
                new Person("Person5", 50, new string[] {"5234", "56543","59876"}),
                new Person("Person6", 60, new string[] {"6234", "66543","69876"}),
            };
            List<Person> persons2 = new List<Person>()
            {
                new Person("Person7", 70, new string[] {"7234", "76543", "79876"}),
                new Person("Person8", 80, new string[] {"8234", "86543", "89876"})
            };
            persons.AddRange(persons2);
            
            foreach (var person in persons)
            {
                ConsIO.Write($"{person.Name} has these phone numbers: ");
                foreach (var personPhN in person.PhoneNumbers)
                {
                    ConsIO.Write($" {personPhN};");
                }
                ConsIO.WriteLine("");
            }

            ConsIO.ReadLine();
        }
    }
}
