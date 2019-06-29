using System.Collections.Generic;

public class Person
{
    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public string Name { get; set; }

    public string Birthday { get; set; }

    public List<Person> Parents { get; set; }

    public List<Person> Children { get; set; }

    private static bool IsBirthday(string input)
    {
        return char.IsDigit(input[0]);
    }

    public static Person CreatePerson(string personInput)
    {
        Person person = new Person();

        if (IsBirthday(personInput))
        {
            person.Birthday = personInput;
        }
        else
        {
            person.Name = personInput;
        }

        return person;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
