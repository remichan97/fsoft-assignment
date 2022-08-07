using System.ComponentModel.DataAnnotations;
namespace NPL.M.A005.Exercise2
{
	public class Program
	{
        private static bool IsValidEmailAddress(string email)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrEmpty(email))
            {
				throw new ArgumentException("Email Address cannot be empty");
			}

			return new EmailAddressAttribute().IsValid(email);
		}

		public static void Main(string[] args)
		{
            Console.WriteLine("Enter an email address to check its validity: ");
			string email = Console.ReadLine()!;

		}
	}
}