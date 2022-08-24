using System.Collections.Generic;

namespace CSharpSOLIDExample.DIP.Solution
{
	public class ShapeRepo
	{
		private IDatabase _data = new Database();

		public IEnumerable<Square> GetAllSquare()
		{
			return _data.GetAllShape<Square>();
		}
	}
}