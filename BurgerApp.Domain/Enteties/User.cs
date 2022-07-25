using System.Collections.Generic;

namespace BurgerApp.Domain.Enteties
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }

        public User(string firstName, string lastName, string adress, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }
    }
}