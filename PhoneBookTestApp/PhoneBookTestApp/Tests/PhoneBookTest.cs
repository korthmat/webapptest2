using NUnit.Framework;
using PhoneBookTestApp;
using System.Data.SQLite;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
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
            Assert.Fail();
        }
    }

    // ReSharper restore InconsistentNaming 
}