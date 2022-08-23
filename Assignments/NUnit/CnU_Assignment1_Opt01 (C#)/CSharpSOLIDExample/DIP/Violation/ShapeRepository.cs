using System.Collections.Generic;

namespace CSharpSOLIDExample.DIP.Violation
{
	/// <summary>
	///  DIP tells you not to write any tightly coupled code
	///  because that is a nightmare to maintain when the application is growing bigger and bigger.
	///  If a class depends on another class, then we need to change one class
	///  if something changes in that dependent class.
	///  We should always try to write loosely coupled class.
	///  The solution to this issue is to use Dependency Injection or Service Locator...
	/// </summary>
	internal class ShapeRepository
	{
		private readonly Database database;

		public ShapeRepository()
		{
			database = new Database();
		}

		public IEnumerable<Square> GetAllSquares()
		{
			return database.GetAllData<Square>();
		}
	}
}