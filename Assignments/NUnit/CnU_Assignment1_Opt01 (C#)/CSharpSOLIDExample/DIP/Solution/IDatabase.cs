using System.Collections.Generic;

namespace CSharpSOLIDExample.DIP.Solution
{
	public interface IDatabase
	{
		IEnumerable<T> GetAllShape<T>();
	}
}