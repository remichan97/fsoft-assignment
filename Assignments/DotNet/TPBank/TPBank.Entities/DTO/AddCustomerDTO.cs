using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPBank.Entities.DTO
{
    public class AddCustomerDTO
    {
        public long CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
	}
}