using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Properties;

namespace TestProject.Classes
{
    public class Validators
    {
        /// <summary>
        /// Checks entered value do we want to break current task.
        /// </summary>
        /// <param name="tmpS">Entered string from the outstream</param>
        public static void CheckForExitTask(ref string tmpS)
        {
            if ((tmpS.ToLower() == Resources.qToQuitTesting) | (tmpS.ToLower() == Resources.bToQuitTesting))
            {
                Environment.Exit(0);
            }
        }
    }
}
