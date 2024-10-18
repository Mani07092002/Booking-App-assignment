using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEntity
{
    public class Customer
    {
        public string Name { get; set; } 
        public string EmailAddress { get; set; } 
        public string PhoneNumber { get; set; }

        public Customer(string name, string email, string phone)
        {
            Name = name;
            EmailAddress = email;
            PhoneNumber = phone;
        }
    }
}
