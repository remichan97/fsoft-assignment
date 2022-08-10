using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPLC.Assignment5.Exercise3
{
    internal static class ExtensionClass
    {
        internal static int LastIndexOf<T>(this T[] arr, T elementValue)
        {
			return arr.LastIndexOf(elementValue);
		}
    }
}