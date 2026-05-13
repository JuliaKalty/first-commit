namespace Spw4.Exploration;

public class Person(int id, string name, int age)
{
    public int Id { get; private set; } = id;
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;

    public Person(string name, int age) : this(-1, name, age)
    {
    }

    public Person(string name) : this(-1, name, -1)
    {
    }
}