namespace Spw4.Exploration;

public interface IPersonRepository
{
    void CreatePerson(Person p);
    Person? ReadPersonById(int id);
    Person? ReadPersonByName(string name);
    IEnumerable<Person> ReadAllPersons();
    bool UpdatePerson(Person p);
    bool DeletePerson(int id);
}