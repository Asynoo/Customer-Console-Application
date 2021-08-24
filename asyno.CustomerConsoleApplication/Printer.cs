using System;
using System.Collections.Generic;

namespace asyno.CustomerConsoleApplication
{
    public class Printer
    {
        private static int id = 1;
        private static List<Customer> customers = new List<Customer>();

        readonly string[] menuItems = {
                "List All Customers",
                "Add Customer",
                "Edit Customer",
                "Delete Customer",
                "Exit"
            };

        public Printer() {

            customers.Add(new Customer()
            {
                Id = id++,
                FirstName  = "Marco",
              LastName = "Gabel",
              Address = new Address(){Street = "Gellerupvej 121", City = "Varde"}
            });

            var selection = ShowMenu();

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        ListAllCustomers();
                        break;
                    case 2:
                        Console.Clear();
                        AddCustomer();
                        break;
                    case 3:
                        Console.Clear();
                        EditCustomer();
                        break;
                    case 4:
                        Console.Clear();
                        DeleteCustomer();
                        break;
                }
                selection = ShowMenu();
            }
            Console.Clear();
            Console.ReadLine();
        }

        private static Customer FindCustomerById()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please Enter Id of Account you want removed: ");
            }

            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }   
            }

            return null;
        }

        private void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                customers.Remove(customerFound);
            }
        }

        private void EditCustomer()
        {
            Console.WriteLine("Please Enter Id of User you want to Edit: ");
            var customer = FindCustomerById();
            Console.WriteLine("Please Enter New Name: ");
            customer.FirstName = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter New Last Name: ");
            customer.LastName = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter New Street: ");
            customer.Address.Street = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter New City: ");
            customer.Address.City = Console.ReadLine();
            Console.Clear();
        }

        private void AddCustomer()
        {
            Console.WriteLine("Please Enter Name: ");
            var firstname = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter Last Name: ");
            var lastname = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter Street: ");
            var street = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Please Enter City: ");
            var city = Console.ReadLine();
            Console.Clear();
            
            customers.Add(new Customer()
            {
                Id = id++,
                FirstName = firstname,
                LastName = lastname,
                Address = new Address(){Street = street, City = city}
            });
        }

        private void ListAllCustomers()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.Id} \nName: {customer.FirstName} {customer.LastName} \nAddress: {customer.Address.Street}, {customer.Address.City} \n");
            }
        }

        int ShowMenu()
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection is < 1 or > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}