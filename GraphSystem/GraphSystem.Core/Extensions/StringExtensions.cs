using System;
using System.Collections.Generic;
using System.Text;

namespace GraphSystem.Core.Extensions
{
    public static class StringExtentions
    {
        public static double ToDouble(this string value)
        {
            //double temp=0;
            value = value.Trim();
            if (double.TryParse(value, out double temp))
            {
                return Convert.ToDouble(value);
            }
            else
            {
                return Double.NaN;
            }
        }
    }
}
