using CdvAzure.Functions;
using Lab1.Database.Entities;

namespace Lab1
{
    public interface IPeopleService
    {
        Person FindPerson(int id);

        IEnumerable<Person> GetPerson();

        Person AddPerson(Person person);
    }
}