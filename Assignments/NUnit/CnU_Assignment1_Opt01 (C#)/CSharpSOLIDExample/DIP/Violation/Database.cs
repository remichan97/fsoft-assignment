using System;
using System.Collections.Generic;

namespace CSharpSOLIDExample.DIP.Violation
{
	internal class Database
	{
		public IEnumerable<T> GetAllData<T>()
		{
			throw new NotImplementedException();
		}
	}
}