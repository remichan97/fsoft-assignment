using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPLC.Assignment5.Exercise4
{
	internal static class ExtensionOrder
	{
		internal static int ElementOfOrder2(this int[] arr)
		{
			var order = (from int data in arr orderby data descending select data).Distinct().ToArray();

			return order[1];
		}

		internal static T ElementOfOrder<T>(this T[] arr, int order) where T : struct
		{
			if (order < 1 && order > arr.Length)
			{
				throw new ArgumentException("Selected order is out of range.");
			}

			var orderArr = (from T data in arr orderby data descending select data).Distinct().ToArray();
			return orderArr[order - 1];
		}
	}
}