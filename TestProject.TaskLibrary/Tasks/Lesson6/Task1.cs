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
            string s = "*** Now you are in Lesson6.Task1 ***";
            s = s + "\n    Work with List<T>, Part 1\n" +
                "   Create a list of persons (>5); Each person has >2 phone numbers.\n" +
                "   Print Name and Age of each person from the list.";
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
            
            foreach (var person in persons)
            {
                ConsIO.WriteLine($"{person.Name} is {person.Age} years old.");
            }
            
            ConsIO.ReadLine();
        }
    }
    
    public class Person
    {
        /// <summary>
        /// Initializes new instance of class Person.
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="age">Age of person</param>
        /// <param name="phoneNumbers">An array of phone numbers</param>
        public Person(string name, int age, string[] phoneNumbers)
        {
            Name = name;
            Age = age;
            PhoneNumbers = phoneNumbers;
        }

        /// <summary>
        /// Name of person
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Age of person
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Phone number(s) of person
        /// </summary>
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
