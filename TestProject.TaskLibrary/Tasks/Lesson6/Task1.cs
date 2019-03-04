using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson6
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Person1", 10, new string[] {"1234", "16543","19876"}),
                new Person("Person2", 20, new string[] {"2234", "26543","29876"}),
                new Person("Person3", 30, new string[] {"3234", "36543","39876"}),
                new Person("Person4", 40, new string[] {"4234", "46543","49876"}),
                new Person("Person5", 50, new string[] {"5234", "56543","59876"}),
                new Person("Person6", 60, new string[] {"6234", "66543","69876"}),
            };
            
            foreach (var person in persons)
            {
                ConsIO.WriteLine($"{person.Name} is {person.Age} years old.");
            }
            
            ConsIO.ReadLine();
            //Task1MainBody();
        }

        /*public static void Task1MainBody()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Person1", 10, new string[] {"1234", "16543","19876"}),
                new Person("Person2", 20, new string[] {"2234", "26543","29876"}),
                new Person("Person3", 30, new string[] {"3234", "36543","39876"}),
                new Person("Person4", 40, new string[] {"4234", "46543","49876"}),
                new Person("Person5", 50, new string[] {"5234", "56543","59876"}),
                new Person("Person6", 60, new string[] {"6234", "66543","69876"}),
            };

            foreach (var person in persons)
            {
                ConsIO.WriteLine($"{person.Name} is {person.Age} years old.");
            }

            ConsIO.Read();
        }*/
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }

        public Person(string name, int age, string[] num)
        {
            Name = name;
            Age = age;
            PhoneNumbers = num;
            
        }
    }
}
