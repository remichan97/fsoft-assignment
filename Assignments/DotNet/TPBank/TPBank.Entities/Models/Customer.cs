using System.ComponentModel.DataAnnotations;

namespace TPBank.Entities.Models
{
	public class Customer
	{
		public Guid CustomerId { get; set; } = Guid.NewGuid();
		private long customerCode;

		public long CustomerCode
		{
			get
			{
				return this.customerCode;
			}
			set
			{
				if (!value.IsCustomerCodeValid())
				{
					throw new ArgumentException("Customer Code must not be negative or zero");
				}
				this.customerCode = value;
			}
		}

		private string customerName;

		public string CustomerName
		{
			get
			{
				return this.customerName;
			}
			set
			{
				if (!value.IsCustomerNameValid())
				{
					throw new ArgumentException("Customer name must not be empty and need to be no more than 40 characters");
				}
				this.customerName = value;
			}
		}

		public string Address { get; set; }
		public string Landmark { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		private string phoneNumber;
		public string PhoneNumber {
			get { return this.phoneNumber; }
			set {
				if (!value.IsPhoneNumberValid())
				{
					throw new ArgumentException("Phone number format invalid");
				}
				phoneNumber = value;
			}
		}

		private string username;

		public string Username
		{
			get
			{
				return this.username;
			}
			set
			{
				if (!value.IsUsernameNull())
				{
					throw new ArgumentNullException("Username cannot be empty");
				}
				this.username = value;
			}
		}

		private string password;

		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				if (!value.IsPasswordValid())
				{
					throw new ArgumentException("Password must have at least 6 characters and have at least a lowercase, an uppercase and a numeric character.");
				}
				this.password = value;
			}
		}
	}
}