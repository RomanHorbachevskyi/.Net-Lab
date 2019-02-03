using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task5 : IRunnable
    {
        public void Run() // main method
        {
            Console.WriteLine("*** Now you are in Lesson2.Task5 ***");
            Console.WriteLine("\n* Task5: Implement class ComplexNumber. Overload operators \" * \" and \" / \".");
            //initializing variables
            double temp1;
            double temp2;
            string S;

            temp1 = 0;
            temp2 = 0;

            #region Enter 1st ComplexNumber
            
            //enter First complex number
            Console.WriteLine("Enter Real part of the 1st Complex number:");
            S = Console.ReadLine();
            SetNum(ref S,ref temp1);
            Console.WriteLine("Enter Imaginary part of the 1st Complex number:");
            S = Console.ReadLine();
            SetNum(ref S, ref temp2);
            ComplexNumber c1 = new ComplexNumber(temp1, temp2);
            #endregion

            #region Enter 2nd ComplexNumber

            //enter 2nd complex number
            Console.WriteLine("Enter Real part of the 2st Complex number:");
            S = Console.ReadLine();
            SetNum(ref S, ref temp1);
            Console.WriteLine("Enter Imaginary part of the 2st Complex number:");
            S = Console.ReadLine();
            SetNum(ref S, ref temp2);
            ComplexNumber c2 = new ComplexNumber(temp1,temp2);
            #endregion
            ComplexNumber c3 = new ComplexNumber(0,0);
            ComplexNumber c4 = new ComplexNumber(0, 0);
            c3 = c1 * c2;
            c4 = c1 / c2;

            #region Formatting Output

            string c1_im;
            string c2_im;
            string c3_im;
            string c4_im;
            if (c1.im_ry < 0)
                c1_im = c1.im_ry.ToString();
            else
                c1_im = "+" + c1.im_ry;
            if (c2.im_ry < 0)
                c2_im = c2.im_ry.ToString();
            else
                c2_im = "+" + c2.im_ry;
            if (c3.im_ry < 0)
                c3_im = c3.im_ry.ToString();
            else
                c3_im = "+" + c3.im_ry;
            if (c4.im_ry < 0)
                c4_im = c4.im_ry.ToString();
            else
                c4_im = "+" + c4.im_ry;
            #endregion

            #region Output
            Console.WriteLine("({0}{1}i)*({2}{3}i)==({4}{5}i)", c1.real, c1_im, c2.real,c2_im, c3.real, c3_im);
            Console.ReadLine();
            Console.WriteLine("({0}{1}i)/({2}{3}i)==({4}{5}i)", c1.real, c1_im, c2.real, c2_im, c4.real, c4_im);
            Console.ReadLine();
            #endregion
        }
        private void SetNum(ref string S, ref double Num)
        {//setting Number or Exit
            if ((S == "q") | (S == "b"))
            {
                Environment.Exit(0);
            }
            while (!double.TryParse(S, out Num))
            {
                Console.WriteLine("Entered incorrect value.\nEnter only numbers (without \" i \"):");
                S = Console.ReadLine().ToLower();
                this.SetNum(ref S, ref Num);
            }
        }
    }

    public class ComplexNumber
    {
        //constructor
        public ComplexNumber(double Real, double Im_ry)
        {
            real = Real;
            im_ry = Im_ry;
        }

        #region Properties
        //properties
        public double real { get; set; }
        public double im_ry { get; set; }
        #endregion

        #region Operators
        //operators
        public static ComplexNumber operator *(ComplexNumber  n1, ComplexNumber n2)
        {
            return new ComplexNumber((n1.real*n2.real-n1.im_ry*n2.im_ry), (n1.real*n2.im_ry+n1.im_ry*n2.real) );
        }
        public static ComplexNumber operator /(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber((n1.real * n2.real + n1.im_ry * n2.im_ry)/
                                     (n2.real* n2.real+ n2.im_ry* n2.im_ry),
                       (n1.im_ry * n2.real-n1.real * n2.im_ry)/ (n2.real * n2.real + n2.im_ry * n2.im_ry));
        }
        #endregion
    }


}
