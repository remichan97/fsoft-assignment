using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
