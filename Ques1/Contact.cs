using System;

namespace ContactBookApp
{
    public class Contact
    {
        // Private fields (Encapsulation)
        private string _firstName;
        private string _lastName;
        private string _company;
        private string _email;
        private string _birthdate;
        private string _mobileNumber;

        // Public Properties
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string Company
        {
            get => _company;
            set => _company = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Birthdate
        {
            get => _birthdate;
            set => _birthdate = value;
        }

        public string MobileNumber
        {
            get => _mobileNumber;
            set
            {
                if (IsValidMobile(value))
                    _mobileNumber = value;
                else
                    throw new Exception("Invalid mobile number. Must be 9 digits and non-zero.");
            }
        }

        // Constructor (Method Overloading)
        public Contact() { }

        public Contact(string first, string last, string mobile)
        {
            FirstName = first;
            LastName = last;
            MobileNumber = mobile;
        }

        // Validation method
        private bool IsValidMobile(string mobile)
        {
            return mobile.Length == 9 && long.TryParse(mobile, out long num) && num > 0;
        }
    }
}
