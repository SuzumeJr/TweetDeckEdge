using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtentionTweetDeckEdge
{
    static public class ExtentionMethod
    {
        static public int ToInt(this string value)
        {
            return int.Parse(value);
        }

        static public double ToDouble(this string value)
        {
            return double.Parse(value);
        }
    }
}
