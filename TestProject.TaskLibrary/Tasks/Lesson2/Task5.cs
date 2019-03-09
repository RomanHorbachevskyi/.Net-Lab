using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson2
{
    public class Task5 : IRunnable
    {
        public void Run()
        {
            double temp1;
            double temp2;
            string S;

            #region Variables for Output of Complex number

            string c1_im;
            string c2_im;
            string c3_im;
            string c4_im;

            #endregion


            ConsIO.WriteLine("*** Now you are in Lesson2.Task5 ***");
            ConsIO.WriteLine("\n* Task5: Implement class ComplexNumber. Overload operators \" * \" and \" / \".");
            
            #region Enter 1st ComplexNumber
            
            ConsIO.WriteLine("Enter Real part of the 1st Complex number: ");
            S = ConsIO.ReadLine();
            temp1 = Validators.GetDoubleNumber(S);
            ConsIO.WriteLine("Enter Imaginary part of the 1st Complex number (without \"i\": ");
            S = ConsIO.ReadLine();
            temp2 = Validators.GetDoubleNumber(S);
            var c1 = new ComplexNumber(temp1, temp2);
            
            #endregion

            #region Enter 2nd ComplexNumber

            ConsIO.WriteLine("Enter Real part of the 2st Complex number:");
            S = ConsIO.ReadLine();
            temp1 = Validators.GetDoubleNumber(S);
            ConsIO.WriteLine("Enter Imaginary part of the 2st Complex number:");
            S = ConsIO.ReadLine();
            temp2 = Validators.GetDoubleNumber(S);
            var c2 = new ComplexNumber(temp1, temp2);

            #endregion

            var c3 = new ComplexNumber(0, 0);
            var c4 = new ComplexNumber(0, 0);
            c3 = c1 * c2;
            c4 = c1 / c2;

            #region Formatting Output

            if (c1.Im_ry < 0)
                c1_im = c1.Im_ry.ToString();
            else
                c1_im = "+" + c1.Im_ry;
            if (c2.Im_ry < 0)
                c2_im = c2.Im_ry.ToString();
            else
                c2_im = "+" + c2.Im_ry;
            if (c3.Im_ry < 0)
                c3_im = c3.Im_ry.ToString();
            else
                c3_im = "+" + c3.Im_ry;
            if (c4.Im_ry < 0)
                c4_im = c4.Im_ry.ToString();
            else
                c4_im = "+" + c4.Im_ry;
            #endregion

            #region Output

            ConsIO.WriteLine("({0}{1}i)*({2}{3}i)==({4}{5}i)", c1.Real, c1_im, c2.Real,c2_im, c3.Real, c3_im);
            ConsIO.ReadLine();
            ConsIO.WriteLine("({0}{1}i)/({2}{3}i)==({4}{5}i)", c1.Real, c1_im, c2.Real, c2_im, c4.Real, c4_im);
            ConsIO.ReadLine();
            
            #endregion
        }
    }

    public class ComplexNumber
    {
        //constructor
        /// <summary>
        /// Initializes new instance of Complex number.
        /// </summary>
        /// <param name="real">Real part of Complex number</param>
        /// <param name="im_ry">Imaginary part of Complex number (without "i")</param>
        public ComplexNumber(double real, double im_ry)
        {
            Real = real;
            Im_ry = im_ry;
        }

        #region Properties
        
        /// <summary>
        /// Real part of a Complex number
        /// </summary>
        public double Real { get; set; }

        /// <summary>
        /// Imaginary part (without "i") of a Complex number.
        /// </summary>
        public double Im_ry { get; set; }

        #endregion

        #region Operators

        /// <summary>
        /// Multiplication operator for Complex numbers.
        /// Returns new Complex number as result of
        /// multiplication.
        /// </summary>
        /// <param name="n1">The first Complex number</param>
        /// <param name="n2">The second Complex number</param>
        /// <returns></returns>
        public static ComplexNumber operator *(ComplexNumber  n1, ComplexNumber n2)
        {
            return new ComplexNumber((n1.Real * n2.Real - n1.Im_ry * n2.Im_ry), (n1.Real * n2.Im_ry + n1.Im_ry * n2.Real));
        }

        /// <summary>
        /// Division operator for Complex numbers.
        /// Returns new Complex number as result of
        /// division.
        /// </summary>
        /// <param name="n1">The first Complex number</param>
        /// <param name="n2">The second Complex number</param>
        /// <returns></returns>
        public static ComplexNumber operator /(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber((n1.Real * n2.Real + n1.Im_ry * n2.Im_ry)/
                                     (n2.Real * n2.Real + n2.Im_ry * n2.Im_ry),
                       (n1.Im_ry * n2.Real - n1.Real * n2.Im_ry)/ (n2.Real * n2.Real + n2.Im_ry * n2.Im_ry));
        }
        
        #endregion
    }


}
