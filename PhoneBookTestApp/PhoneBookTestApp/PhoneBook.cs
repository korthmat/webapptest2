using System;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void addPerson(Person person)
        {
            throw new System.NotImplementedException();
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