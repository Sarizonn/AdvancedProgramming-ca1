using System;
using System.Collections.Generic;

namespace ContactBookApp
{
    public class ContactBook
    {
        private List<Contact> contacts = new List<Contact>();

        // Add sample contacts (min. 20)
        public void SeedContacts()
        {
            for (int i = 1; i <= 20; i++)
            {
                contacts.Add(new Contact
                {
                    FirstName = "Person" + i,
                    LastName = "Sample" + i,
                    Company = "Company" + i,
                    MobileNumber = $"08{i:D7}",
                    Email = $"person{i}@example.com",
                    Birthdate = "01 Jan 1990"
                });
            }
        }

        // Add Contact
        public void AddContact()
        {
            try
            {
                Contact c = new Contact();

                Console.Write("Enter First Name: ");
                c.FirstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                c.LastName = Console.ReadLine();

                Console.Write("Enter Company: ");
                c.Company = Console.ReadLine();

                Console.Write("Enter Mobile Number (9 digits): ");
                c.MobileNumber = Console.ReadLine();

                Console.Write("Enter Email: ");
                c.Email = Console.ReadLine();

                Console.Write("Enter Birthdate: ");
                c.Birthdate = Console.ReadLine();

                contacts.Add(c);
                Console.WriteLine("Contact added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add contact: " + ex.Message);
            }
        }

        // Show all contacts (summary)
        public void ShowAllContacts()
        {
            Console.WriteLine("\n------ ALL CONTACTS ------");
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} - {c.MobileNumber}");
            }
        }

        // Show full details of one contact
        public void ShowContactDetails()
        {
            Console.Write("Enter Mobile Number to search: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("\n---- CONTACT DETAILS ----");
            Console.WriteLine($"Name: {c.FirstName} {c.LastName}");
            Console.WriteLine($"Company: {c.Company}");
            Console.WriteLine($"Mobile: {c.MobileNumber}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine($"Birthdate: {c.Birthdate}");
        }

        // Update Contact
        public void UpdateContact()
        {
            Console.Write("Enter mobile number of contact to update: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Update fields (leave blank to skip):");

            Console.Write("New First Name: ");
            string first = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(first)) c.FirstName = first;

            Console.Write("New Last Name: ");
            string last = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(last)) c.LastName = last;

            Console.Write("New Company: ");
            string company = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(company)) c.Company = company;

            Console.Write("New Email: ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) c.Email = email;

            Console.Write("New Birthdate: ");
            string dob = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dob)) c.Birthdate = dob;

            Console.WriteLine("Contact updated!");
        }

        // Delete Contact
        public void DeleteContact()
        {
            Console.Write("Enter mobile number to delete: ");
            string mobile = Console.ReadLine();

            Contact c = contacts.Find(x => x.MobileNumber == mobile);

            if (c == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(c);
            Console.WriteLine("Contact deleted successfully.");
        }
    }
}
