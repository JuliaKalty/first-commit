namespace Spw4.Exploration;

public interface IPersonService
{
    void Register(string name, int age);
    double GetAverageAge();
    Person? FindPerson(string name);
}