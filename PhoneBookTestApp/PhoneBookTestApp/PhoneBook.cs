using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void addPerson(Person person)
        {
            using (SQLiteConnection connection = DatabaseUtil.GetConnection())
            {
                string commandString =
                    String.Format(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES ('{0}', '{1}', '{2}')",
                        person.Name,
                        person.PhoneNumber,
                        person.Address);

                using (SQLiteCommand command = new SQLiteCommand(commandString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public Person findPerson(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> getAllPeople()
        {
            throw new NotImplementedException();
        }
    }
}