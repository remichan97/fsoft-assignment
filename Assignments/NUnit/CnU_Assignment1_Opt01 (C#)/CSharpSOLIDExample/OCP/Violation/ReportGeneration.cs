namespace CSharpSOLIDExample.OCP.Violation
{
	internal class ReportGeneration
	{
		/// <summary>
		/// Report type
		/// </summary>
		public string ReportType { get; set; }

		/// <summary>
		/// Method to generate report
		/// </summary>
		/// <param name="customer">Customer object</param>
		public void GenerateReport(Customer customer)
		{
			// What issue here ?
			//  ‘If’ clauses are here and if we want to add another new report type
			// like ‘Word’, then you need to write another ‘if’.
			// This class should be open for extension but closed for modification.
			// But how to do that ?

			if (ReportType == "XLS")
			{
				// Report generation with customer data in Excel format.
			}
			if (ReportType == "PDF")
			{
				// Report generation with customer data in PDF format.
			}
		}
	}
}