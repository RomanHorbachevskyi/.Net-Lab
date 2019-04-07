using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson11
{
    public class Task3 : IRunnable
    {
        public void Run()
        {
            ConsIO.Clear();
            string s = "*** Now you are in Lesson11.Task3 ***\n    Catch StackOverflowException and IndexOutOfRangeException." +
                       "\nTo continue press 'Enter' key.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            
            try
            {
                ConsIO.WriteLine("We did not get IndexOutOfRangeException. Value is: " +IndexRangeDestroyer.IndexOutOfRangeException().ToString());
                ConsIO.WriteLine("We did not get StackOverflowException. Value is: " + StackDestroyer.GetStackOverflowException().ToString());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("e.Data: " + e.Data);

                foreach (var dataKey in e.Data.Keys)
                {
                    Console.WriteLine("e.Data.Key: " + dataKey.ToString());
                }
                foreach (var dataValue in e.Data.Values)
                {
                    Console.WriteLine("e.Data.Value: " + dataValue.ToString());
                }
                Console.WriteLine("e.Data.Keys: " + e.Data.Keys.ToString());
                Console.WriteLine("e.Data.Values: " + e.Data.Values.ToString());
                Console.WriteLine("e.Message: " + e.Message);
                Console.WriteLine("e.Source: " + e.Source);
                Console.WriteLine("e.StackTrace: " + e.StackTrace);
                Console.WriteLine("e.TargetSite: " + e.TargetSite);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("e.Data: " + e.Data);

                foreach (var dataKey in e.Data.Keys)
                {
                    Console.WriteLine("e.Data.Key: " + dataKey.ToString());
                }
                foreach (var dataValue in e.Data.Values)
                {
                    Console.WriteLine("e.Data.Value: " + dataValue.ToString());
                }
                Console.WriteLine("e.Data.Keys: " + e.Data.Keys.ToString());
                Console.WriteLine("e.Data.Values: " + e.Data.Values.ToString());
                Console.WriteLine("e.Message: " + e.Message);
                Console.WriteLine("e.Source: " + e.Source);
                Console.WriteLine("e.StackTrace: " + e.StackTrace);
                Console.WriteLine("e.TargetSite: " + e.TargetSite);
                
            }
            finally
            {
                ConsIO.WriteLine("\nExecuting block Finally.\n");
            }

            try
            {
                ConsIO.WriteLine("We did not get StackOverflowException. Value is: " + StackDestroyer.GetStackOverflowException().ToString());
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("e.Data: " + e.Data);

                foreach (var dataKey in e.Data.Keys)
                {
                    Console.WriteLine("e.Data.Key: " + dataKey.ToString());
                }
                foreach (var dataValue in e.Data.Values)
                {
                    Console.WriteLine("e.Data.Value: " + dataValue.ToString());
                }
                Console.WriteLine("e.Data.Keys: " + e.Data.Keys.ToString());
                Console.WriteLine("e.Data.Values: " + e.Data.Values.ToString());
                Console.WriteLine("e.Message: " + e.Message);
                Console.WriteLine("e.Source: " + e.Source);
                Console.WriteLine("e.StackTrace: " + e.StackTrace);
                Console.WriteLine("e.TargetSite: " + e.TargetSite);

            }
            finally
            {
                ConsIO.WriteLine("\nExecuting block Finally.\n");
            }
            ConsIO.ReadLine();
        }
    }
}
