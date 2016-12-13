using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookTestApp;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace PhoneBookTestAppTests
{
    [TestClass]
    public class PhoneBookTests
    {
        [TestMethod]
        public void addPerson()
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                long initialNumPeople = GetNumPeopleInDatabase();

                IPhoneBook phoneBook = new PhoneBook();
                phoneBook.addPerson(
                    new Person()
                    {
                        Name = "Elwood Blues",
                        Address = "1060 West Addison, Chicago, IL",
                        PhoneNumber = "(888) THE-BAND"
                    });

                long numPeopleAfterAdd = GetNumPeopleInDatabase();

                Assert.AreEqual(initialNumPeople + 1, numPeopleAfterAdd);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        private long GetNumPeopleInDatabase()
        {
            long numPeople = -1;

            using (SQLiteConnection connection = DatabaseUtil.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM PHONEBOOK", connection))
                {
                    numPeople = (long)command.ExecuteScalar();
                }
            }

            return numPeople;
        }

        [TestMethod]
        public void findPerson()
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                IPhoneBook phoneBook = new PhoneBook();

                // "Chris Johnson" is added by the DatabaseUtil.initializeDatabase call.
                Assert.IsNotNull(phoneBook.findPerson("Chris Johnson"));

                // "Jake Blues", however, is not.
                Assert.IsNull(phoneBook.findPerson("Jake Blues"));
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        [TestMethod]
        public void getAllPeople()
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                IPhoneBook phoneBook = new PhoneBook();
                IEnumerable<Person> people = phoneBook.getAllPeople();

                Assert.AreEqual(2, people.Count());
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

    }
}
