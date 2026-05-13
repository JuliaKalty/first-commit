namespace Spw4.Exploration;

public class PersonRepository : IPersonRepository
{
    private readonly Dictionary<int, Person> _persons = new();
    private int _nextId = 0;

    public void CreatePerson(Person p)
    {
        var newPerson = new Person(_nextId, p.Name, p.Age);
        _persons[newPerson.Id] = newPerson;
        _nextId++;
    }

    public Person? ReadPersonById(int id)
    {
        _persons.TryGetValue(id, out var person);
        return person;
    }

    public Person? ReadPersonByName(string name)
    {
        return _persons.Values.FirstOrDefault(p => p.Name == name);
    }

    public IEnumerable<Person> ReadAllPersons()
    {
        return _persons.Values;
    }

    public bool UpdatePerson(Person p)
    {
        if (!_persons.ContainsKey(p.Id)) return false;
        _persons[p.Id] = p;
        return true;
    }

    public bool DeletePerson(int id)
    {
        return _persons.Remove(id);
    }
}
