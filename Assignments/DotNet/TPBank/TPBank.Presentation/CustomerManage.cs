using TPBank.BusinessLogicLayer;
using TPBank.Entities.DTO;
using TPBank.Entities.Models;

namespace TPBank.Presentation
{
	public class CustomerManage
	{
		private static CustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

		internal static bool SignIn(string username, string password)
		{
			return username.Equals("system") && password.Equals("manager");
		}

		internal static void menu()
		{
			Console.WriteLine($"Choose an option below:");
			Console.WriteLine($"1. Add Customer");
			Console.WriteLine($"2. List all Customer");
			Console.WriteLine($"3. Find Customer");
			Console.WriteLine($"4. Update Customer");
			Console.WriteLine($"5. Delete Customer");
			Console.WriteLine($"0. Exit");
			Console.Write($"Your choice: ");
		}

		internal static void ListCustomer()
		{
			var query = customerBusinessLogicLayer.GetCustomer();

			if (query.Result is null)
			{
				Console.WriteLine($"Your query returns no results");
			}
			else
			{
				query.Result.ForEach(it => it.ToString());
			}
		}

		internal static void ListByCondition(string keyword)
		{
			Console.WriteLine($"Which data you wish to find by?");
			Console.WriteLine($"1. Username");
			Console.WriteLine($"2. Address");
			Console.WriteLine($"3. City");
			Console.WriteLine($"4. Phone number");
			Console.WriteLine($"0. Go back");
			Console.WriteLine("Your choice:");
			int choice = Convert.ToInt32(Console.ReadLine());

			while (choice < 0 || choice > 4)
			{
				Console.WriteLine($"Invalid option. Please try again!");
				Console.WriteLine("Your choice:");
				choice = Convert.ToInt32(Console.ReadLine());
			}

			switch (choice)
			{
				case 1:
					var queryUsername = customerBusinessLogicLayer.GetCustomersByCondition(it => it.Username.Equals(keyword));
					if (queryUsername.Result is null)
					{
						Console.WriteLine($"Your query returns no result.");
					}
					else
					{
						Console.WriteLine($"Below is the customer matches the query:");

						queryUsername.Result.ForEach(it => it.ToString());
					}
					break;

				case 2:
					var queryAddress = customerBusinessLogicLayer.GetCustomersByCondition(it => it.Address.Equals(keyword));
					if (queryAddress.Result is null)
					{
						Console.WriteLine($"Your query returns no results");
					}
					else
					{
						Console.WriteLine($"Below is the customer matches the query:");
						queryAddress.Result.ForEach(it => it.ToString());
					}
					break;

				case 3:
					var queryCity = customerBusinessLogicLayer.GetCustomersByCondition(it => it.City.Equals(keyword));
					if (queryCity.Result is null)
					{
						Console.WriteLine($"Your query returns no results");
					}
					else
					{
						Console.WriteLine($"Below is the customer matches the query:");
						queryCity.Result.ForEach(it => it.ToString());
					}
					break;

				case 4:
					var queryMobile = customerBusinessLogicLayer.GetCustomersByCondition(it => it.PhoneNumber.Equals(keyword));
					if (queryMobile.Result is null)
					{
						Console.WriteLine($"Yoour query returns no results");
					}
					else
					{
						Console.WriteLine($"Below is the customer matches the query:");
						queryMobile.Result.ForEach(it => it.ToString());
					}
					break;

				case 0:
					break;
			}
		}

		internal static void AddCustomer()
		{
			Console.WriteLine($"Enter Customer code:");
			long customerCode = long.Parse(Console.ReadLine());
			Console.WriteLine($"Enter Customer name:");
			string customerName = Console.ReadLine();
			Console.WriteLine($"Enter Cuustomer Address:");
			string address = Console.ReadLine();
			Console.WriteLine($"Enter Customer landmark:");
			string landmark = Console.ReadLine();
			Console.WriteLine($"Enter Customer City:");
			string city = Console.ReadLine();
			Console.WriteLine($"Enter Customer Country:");
			string country = Console.ReadLine();
			Console.WriteLine($"Enter Customer Phone number:");
			string phone = Console.ReadLine();
			Console.WriteLine($"Enter Customer Username:");
			string username = Console.ReadLine();
			Console.WriteLine($"Enter Acccount Password:");
			string password = Console.ReadLine();

			Customer check = new Customer() { PhoneNumber = phone, Username = username };

			var query = customerBusinessLogicLayer.CheckUnique(check);

			if (query is not null)
			{
				Console.WriteLine($"The provided Phone number and/or Username already in use by a Customer. Aborted");
				return;
			}

			AddCustomerDTO customer = new AddCustomerDTO() { CustomerCode = customerCode, CustomerName = customerName, Address = address, Landmark = landmark, City = city, Country = country, PhoneNumber = phone, Username = username, Password = password };

			var result = customerBusinessLogicLayer.AddCustomer(customer);

			if (result.Result is null)
			{
				Console.WriteLine($"Something went wrong. Please try again");
			}
			else
			{
				Console.WriteLine($"Customer info added successfully");
			}
		}

		internal static void UpdateCustomer(string username)
		{
			var query = customerBusinessLogicLayer.GetCustomer().Result.Where(it => it.Username.Equals(username)).FirstOrDefault();

			if (query is null)
			{
				Console.WriteLine($"No such customer found with username {username}. Aborted");
				return;
			}

			Console.WriteLine($"Below is the current Customer information");
			Console.WriteLine(query.ToString());

			Console.WriteLine($"Enter the information you need to update below. Leave any field empty to keep their related information intact:");

			Console.WriteLine($"Address:");
			string address = Console.ReadLine();
			Console.WriteLine($"Landmark:");
			string landmark = Console.ReadLine();
			Console.WriteLine($"City:");
			string city = Console.ReadLine();
			Console.WriteLine($"Country:");
			string country = Console.ReadLine();
			Console.WriteLine($"Phone number:");
			string phone = Console.ReadLine();
			Console.WriteLine($"Password:");
			string password = Console.ReadLine();

			if (string.IsNullOrEmpty(address)) address = query.Address;

			if (string.IsNullOrEmpty(landmark)) landmark = query.Landmark;

			if (string.IsNullOrEmpty(city)) city = query.City;

			if (string.IsNullOrEmpty(country)) country = query.Country;

			if (string.IsNullOrEmpty(phone)) phone = query.PhoneNumber;

			if (string.IsNullOrEmpty(password)) password = query.Password;

			Customer customer = new Customer() { CustomerId = query.CustomerId, CustomerCode = query.CustomerCode, CustomerName = query.CustomerName, Address = address, Landmark = landmark, City = city, Country = country, PhoneNumber = phone, Username = query.Username, Password = password };

			var result = customerBusinessLogicLayer.UpdateCustomer(customer);

			if (result)
			{
				Console.WriteLine($"Successfully updated Customer information: Below are the new information:");
				Console.WriteLine(customer.ToString());
			}
			else
			{
				Console.WriteLine($"New password does not meet the requirement. Password must have at least 6 characters, have aan uppercase, lowercase and a numerical character.");
			}
		}

		internal static void DeleteCustomer(string username)
		{
			var query = customerBusinessLogicLayer.GetCustomerByUsername(username);

			if (query.Result is null)
			{
				Console.WriteLine($"No such customer with the username {username} exists");
			}
			else
			{
				var result = customerBusinessLogicLayer.DeleteCustomer(query.Result.CustomerId);
				Console.WriteLine($"The operation completed successfully");
			}
		}
	}
}