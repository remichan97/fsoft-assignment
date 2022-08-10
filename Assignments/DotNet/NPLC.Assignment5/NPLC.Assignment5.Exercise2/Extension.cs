using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPLC.Assignment5.Exercise2
{
    public static class Extension
    {
        internal static int[] RemoveDuplicate(this int[] arr)
        {
			return (from int data in arr select data).Distinct().ToArray();
		}

        internal static T[] RemoveDuplicate<T>(this T[] arr)
        {
			return (from T data in arr select data).Distinct().ToArray();
		}
    }
}