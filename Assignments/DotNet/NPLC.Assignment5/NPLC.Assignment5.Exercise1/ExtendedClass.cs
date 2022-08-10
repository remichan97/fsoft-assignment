using System.Collections;

namespace NPLC.Assignment5.Exercise1
{
	internal static class ExtendedClass
	{
		internal static int CountInt(this ArrayList arr)
		{
			return arr.OfType<int>().Count();
		}

		internal static int CountOf(this ArrayList arr, Type dataType)
		{
			if (dataType == typeof(int))
			{
				return arr.OfType<int>().Count();
			}
			else if (dataType == typeof(double))
			{
				return arr.OfType<double>().Count();
			} else 
			{
				return arr.OfType<string>().Count();
			}
		}

		internal static int CountOf<T>(this ArrayList arr)
		{
			return arr.OfType<T>().Count();
		}

		internal static T MaxOf<T>(this ArrayList arr) where T : struct
		{
			var ofDataType = arr.OfType<T>();
			return ofDataType.Max();
		}
	}
}