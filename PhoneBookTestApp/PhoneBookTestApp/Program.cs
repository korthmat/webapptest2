using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                IPhoneBook phoneBook = new PhoneBook();

                /* TODO: create person objects and put them in the PhoneBook and database
                 * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                 * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                 */
                Console.WriteLine("Adding John Smith to the phone book...");
                phoneBook.addPerson(
                    new Person()
                    {
                        Name = "John Smith",
                        Address = "1234 Sand Hill Dr, Royal Oak, MI",
                        PhoneNumber = "(248) 123-4567"
                    });

                Console.WriteLine();
                Console.WriteLine("Adding Cynthia Smith to the phone book...");
                phoneBook.addPerson(
                    new Person()
                    {
                        Name = "Cynthia Smith",
                        Address = "875 Main St, Ann Arbor, MI",
                        PhoneNumber = "(824) 128-8758"
                    });

                // TODO: print the phone book out to System.out
                Console.WriteLine();
                Console.WriteLine("Printing the phone book to the console...");
                foreach (Person person in phoneBook.getAllPeople())
                {
                    Console.WriteLine(person);
                }

                // TODO: find Cynthia Smith and print out just her entry
                //Console.WriteLine("Finding Cynthia Smith in the phone book...");
                //Person cynthiaSmith = phoneBook.findPerson("Cynthia", "Smith");
                //if (cynthiaSmith == null)
                //    Console.WriteLine("\"Cynthia Smith\" is not in the phone book.");
                //else
                //{
                //    Console.WriteLine(cynthiaSmith.Name);
                //    Console.WriteLine(cynthiaSmith.Address);
                //    Console.WriteLine(cynthiaSmith.PhoneNumber);
                //}

                // TODO: insert the new person objects into the database
                // TODO: Didn't we already do that above?  The instructions say to "person objects and put them in the PhoneBook and database" above...

                Console.ReadLine();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
