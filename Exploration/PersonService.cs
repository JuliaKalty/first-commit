namespace Spw4.Exploration;

public class PersonService(IPersonRepository repo) : IPersonService
{
    public void Register(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("invalid name");
        if (age < 16)
            throw new ArgumentException("person too young");

        var p = new Person(name, age);
        repo.CreatePerson(p);
    }

    public double GetAverageAge()
    {
        return repo.ReadAllPersons().Average(p => p.Age);
    }
    
    public Person? FindPerson(string name)
    {
        return repo.ReadPersonByName(name);
    }
}
