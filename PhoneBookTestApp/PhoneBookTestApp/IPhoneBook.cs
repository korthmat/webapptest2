using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person findPerson(string name);
        void addPerson(Person newPerson);
        IEnumerable<Person> getAllPeople();
    }
}