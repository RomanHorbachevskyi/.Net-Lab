
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TestProject.Common.Core.Classes
{
    public static class MyMath
    {
        private static int min, max;

        public static int Min(int[] values = null)
        {
            
            if (values!=null)
            {
                min = values[0];
                for (int i = 0; i < values.Length; i++)
                {
                    if (min>values[i])
                    {
                        min = values[i];
                    }
                }
            }
            return min;
        }

        public static int Max(int[] values = null)
        {
            if (values != null)
            {
                max = values[0];
                for (int i = 0; i < values.Length; i++)
                {
                    if (max < values[i])
                    {
                        max = values[i];
                    }
                }
            }
            return max;
        }
    }
}
