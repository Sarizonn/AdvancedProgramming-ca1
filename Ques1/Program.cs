using System;
using System.Collections.Generic;

namespace ContactBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactBook contactBook = new ContactBook();
            contactBook.SeedContacts();   

            int choice;

            do
            {
                Console.WriteLine("\n------ CONTACT BOOK MENU ------");
                Console.WriteLine("1: Add Contact");
                Console.WriteLine("2: Show All Contacts");
                Console.WriteLine("3: Show Contact Details");
                Console.WriteLine("4: Update Contact");
                Console.WriteLine("5: Delete Contact");
                Console.WriteLine("0: Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        contactBook.AddContact();
                        break;

                    case 2:
                        contactBook.ShowAllContacts();
                        break;

                    case 3:
                        contactBook.ShowContactDetails();
                        break;

                    case 4:
                        contactBook.UpdateContact();
                        break;

                    case 5:
                        contactBook.DeleteContact();
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
