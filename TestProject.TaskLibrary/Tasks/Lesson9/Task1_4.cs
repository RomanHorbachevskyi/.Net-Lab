using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
//using TestProject.TaskLibrary;
using TestProject.TaskLibrary.Tasks.Lesson6;

namespace TestProject.TaskLibrary.Tasks.Lesson9
{
    public class Task1_4 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson9.Task1 ***\n    Work with List<T>, LINQ, Part 1";
            ConsIO.WriteLine(s);

            #region Task1

            var persons = new List<Lesson6.Person>()
            {
                new Lesson6.Person("Person1", 10, new string[] {"1234", "16543","19876"}),
                new Lesson6.Person("Person2", 20, new string[] {"2234", "26543","29876"}),
                new Lesson6.Person("Person3", 30, new string[] {"3234", "36543","39876"}),
                new Lesson6.Person("Person4", 40, new string[] {"4234", "46543","49876"}),
                new Lesson6.Person("Person5", 50, new string[] {"5234", "56543","59876"}),
                new Lesson6.Person("Person6", 60, new string[] {"6234", "66543","69876"}),
            };
            
            foreach (var person in persons)
            {
                ConsIO.WriteLine($"{person.Name} is {person.Age} years old.");
            }
            
            #endregion

            //*** Now you are in Lesson9.Task2 *** Work with List<T>, LINQ, Part 2
            ConsIO.WriteLine("*** Now you are in Lesson9.Task2 ***\n    Work with List<T>, LINQ, Part 2");

            #region Task2
            
            var persons2 = new List<Lesson6.Person>()
            {
                new Lesson6.Person("Person7", 70, new string[] {"7234", "76543", "79876"}),
                new Lesson6.Person("Person8", 80, new string[] {"8234", "86543", "89876"})
            };
            persons.AddRange(persons2);

            PrintPhoneNumbers(ref persons);
            
            #endregion

            //*** Now you are in Lesson9.Task3 *** Work with List<T>, LINQ, Part 3
            ConsIO.WriteLine("*** Now you are in Lesson9.Task3 ***\n    Work with List<T>, LINQ, Part 3");

            #region Task3
            
            persons2 = new List<Lesson6.Person>()
            {
                new Lesson6.Person("Person9", 10, new string[] {"9234", "96543", "99876"}),
                new Lesson6.Person("Person10", 10, new string[] {"10234", "106543", "109876"})
            };
            persons.AddRange(persons2);

            PrintPhoneNumbers(ref persons);
            
            #endregion

            //*** Now you are in Lesson9.Task4 *** Work with List<T>, LINQ, Part 4
            ConsIO.WriteLine("*** Now you are in Lesson9.Task4 ***\n    Work with List<T>, LINQ, Part 4");

            #region Task4

            var query = persons
                .Where(p => p.Age<20)
                .OrderBy(p => p.Name)
                .Select(p => p);
            
            foreach (var person in query)
            {
                ConsIO.Write($"{person.Name} has these phone numbers: ");
                foreach (var phoneNumber in person.PhoneNumbers)
                {
                    ConsIO.Write(" " + phoneNumber);
                }
                ConsIO.WriteLine("");
            }
            
            #endregion

            ConsIO.ReadLine();
        }

        public static void PrintPhoneNumbers(ref IEnumerable<Lesson6.Person> persons)
        {
            foreach (var person in persons)
            {
                ConsIO.Write($"{person.Name} has these phone numbers: ");
                foreach (var personPhN in person.PhoneNumbers)
                {
                    ConsIO.Write($" {personPhN};");
                }
                ConsIO.WriteLine("");
            }
        }
        public static void PrintPhoneNumbers(ref List<Lesson6.Person> persons)
        {
            foreach (var person in persons)
            {
                ConsIO.Write($"{person.Name} has these phone numbers: ");
                foreach (var personPhN in person.PhoneNumbers)
                {
                    ConsIO.Write($" {personPhN};");
                }
                ConsIO.WriteLine("");
            }
        }
    }
}
