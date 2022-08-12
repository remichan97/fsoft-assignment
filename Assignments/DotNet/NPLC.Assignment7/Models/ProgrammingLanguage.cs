using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPLC.Assignment7.Models
{
	public class ProgrammingLanguage
	{
		public int LanguageId { get; set; }
		private string languageName;
		public string LanguageName
		{
			get
			{
				return this.languageName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(this.languageName)) throw new ArgumentNullException("Language name canoot be empty. Aborted");
			}
		}
	}
}