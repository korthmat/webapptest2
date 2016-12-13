using System;
using System.Collections.Generic;
using System.Data;
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

        public Person findPerson(string name)
        {
            Person found = null;

            string commandString = String.Format("SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK WHERE NAME = '{0}'", name);

            using (SQLiteConnection connection = DatabaseUtil.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(commandString, connection))
                {
                    // TODO: Refactor this code - redundant.
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        int nameOrdinal = reader.GetOrdinal("NAME");
                        int phoneNumberOrdinal = reader.GetOrdinal("PHONENUMBER");
                        int addressOrdinal = reader.GetOrdinal("ADDRESS");

                        if (reader.Read())
                        {
                            found = new Person();
                            found.Address = reader.GetString(addressOrdinal);
                            found.Name = reader.GetString(nameOrdinal);
                            found.PhoneNumber = reader.GetString(phoneNumberOrdinal);
                        }
                    }
                }
            }

            return found;
        }

        public IEnumerable<Person> getAllPeople()
        {
            List<Person> allPeople = new List<Person>();

            using (SQLiteConnection connection = DatabaseUtil.GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK", connection))
                {
                    // TODO: Refactor this code - redundant.
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        int nameOrdinal = reader.GetOrdinal("NAME");
                        int phoneNumberOrdinal = reader.GetOrdinal("PHONENUMBER");
                        int addressOrdinal = reader.GetOrdinal("ADDRESS");

                        while (reader.Read())
                        {
                            Person newPerson = new Person();
                            newPerson.Address = reader.GetString(addressOrdinal);
                            newPerson.Name = reader.GetString(nameOrdinal);
                            newPerson.PhoneNumber = reader.GetString(phoneNumberOrdinal);

                            allPeople.Add(newPerson);
                        }
                    }
                }
            }

            return allPeople;
        }
    }
}