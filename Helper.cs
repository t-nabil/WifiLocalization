﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiLocalization
{
    public static class Helper
    {
        public static Double[] Magnitude(Double[] x, Double[] y)
        {
            int length = x.Length;
            Double[] s = new Double[length];
            for (int i = 0; i < length; i++)
            {
                s[i] = Math.Sqrt(Math.Pow(x[i], 2) + Math.Pow(y[i], 2));
            }
            return s;
        }
        public static Double[] ObjectToDouble(Array values)
        {

            int length = values.Length;
            Double[] result = new Double[length];
            int i = 0;

            foreach (object value in values)
            {
                try
                {
                    result[i++] = Convert.ToDouble(value);
                    // Console.WriteLine("Converted the {0} value {1} to {2}.",
                    //                value.GetType().Name, value, result);
                }
                catch (FormatException)
                {
                    // Console.WriteLine("The {0} value {1} is not recognized as a valid Double value.",
                    //                value.GetType().Name, value);
                }
                catch (InvalidCastException)
                {
                    // Console.WriteLine("Conversion of the {0} value {1} to a Double is not supported.",
                    //                value.GetType().Name, value);
                }
            }
            return result;
        }

    }
}
