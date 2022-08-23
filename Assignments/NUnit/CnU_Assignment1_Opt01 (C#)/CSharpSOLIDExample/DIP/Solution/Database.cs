using System.Collections.Generic;
using System.Linq;

namespace CSharpSOLIDExample.DIP.Solution
{
	public class Database : IDatabase
	{
		public IEnumerable<T> GetAllShape<T>()
		{
			return Enumerable.Empty<T>();
		}
	}
}