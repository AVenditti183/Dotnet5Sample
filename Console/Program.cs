using System;

var person = new Person("Antonio", "Venditti");

//person.Name = "Mario";

var otherPerson = new Person { Name = "Antonio", Surname = "Venditti" };


Console.WriteLine($"{person.Name} {person.Surname}");
Console.WriteLine($"{otherPerson.Name} {otherPerson.Surname}");

Console.WriteLine(person.Equals(otherPerson));

Console.WriteLine(person == otherPerson);

var (name, surname) = person;

Console.WriteLine($"{name} {surname}");

var personRecord = new PersonRecord("Mario", "Rossi");
var otherPersonRecord = personRecord with { Surname = "Verdi" };
Console.ReadKey();

public class Person :IEquatable<Person>
{
    public string Name { get; init; }
    public string Surname { get; init; }

    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public Person()
    {

    }

    public bool Equals(Person other)
    {
        return this.Name == other.Name
            && this.Surname == other.Surname;
    }

    public static  bool operator ==(Person person1,Person person2)
    {
        return person1.Name == person2.Name
            && person1.Surname == person2.Surname;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return person1.Name != person2.Name
            || person1.Surname != person2.Surname;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
       return base.GetHashCode();
    }

    public void Deconstruct(out string name,out string surname)
    {
        name = this.Name;
        surname = this.Surname;
    }
}

public record PersonRecord(string Name,String Surname);