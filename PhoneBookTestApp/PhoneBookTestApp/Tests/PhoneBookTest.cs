using NUnit.Framework;
using PhoneBookTestApp;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        // TODO: Should check to make sure the person being added in this test, can be found.
        [Test]
        public void addPerson()
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                int initialNumPeople = GetNumPeopleInDatabase();

                IPhoneBook phoneBook = new PhoneBook();
                phoneBook.addPerson(
                    new Person()
                    {
                        Name = "Elwood Blues",
                        Address = "1060 West Addison, Chicago, IL",
                        PhoneNumber = "(888) THE-BAND"
                    });

                int numPeopleAfterAdd = GetNumPeopleInDatabase();

                Assert.AreEqual(initialNumPeople + 1, numPeopleAfterAdd);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        private int GetNumPeopleInDatabase()
        {
            int numPeople = -1;

            using (SQLiteConnection connection = DatabaseUtil.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM PHONEBOOK"))
                {
                    numPeople = (int)command.ExecuteScalar();
                }
            }

            return numPeople;
        }

        [Test]
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

        [Test]
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

    // ReSharper restore InconsistentNaming 
}