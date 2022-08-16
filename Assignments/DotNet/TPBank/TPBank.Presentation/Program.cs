using TPBank.Presentation;

Console.WriteLine($"Please sign-in to the app using the form below:");
Console.WriteLine($"Username:");
string username = Console.ReadLine();
Console.WriteLine("Password:");
string password = Console.ReadLine();
while (!CustomerManage.SignIn(username, password))
{
	Console.WriteLine($"Incorrect sign-in credential, please try again!");
	Console.WriteLine($"Username:");
	username = Console.ReadLine();
	Console.WriteLine("Password:");
	password = Console.ReadLine();
}

while (true)
{
	CustomerManage.menu();
	int opt = Convert.ToInt32(Console.ReadLine());
	switch (opt)
	{
		case 1:
			CustomerManage.AddCustomer();
			break;

		case 2:
			CustomerManage.ListCustomer();
			break;

		case 3:
			Console.WriteLine($"Enter a keyword to perform a search. Leaving this empty will cancel the search:");
			string keyword = Console.ReadLine();

			if (string.IsNullOrEmpty(keyword)) break;

			CustomerManage.ListByCondition(keyword);
			break;

		case 4:
			Console.WriteLine($"Type in a customer username you wish to update information. Leaving this empty will cancel the update:");
			string usernameUpdate = Console.ReadLine();
			if (string.IsNullOrEmpty(usernameUpdate)) break;
			CustomerManage.UpdateCustomer(usernameUpdate);
			break;

		case 5:
			Console.WriteLine($"Enter a username to delete. Leaving this empty will cancel this operation:");
			string usernameToDelete = Console.ReadLine();
			if (string.IsNullOrEmpty(usernameToDelete)) break;
			CustomerManage.DeleteCustomer(usernameToDelete);
			break;

		case 0:
			Environment.Exit(0);
			break;
	}
}