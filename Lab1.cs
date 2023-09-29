Output users = new Output();
Person pers = new Person("John");


users.get_name_age();
users.print_data();
pers.print_names();


class Output
{
    string name = null;
    int age = 0;

    public void get_name_age()
    {
        Console.WriteLine("Please enter your name:\t");
        name = Console.ReadLine();
        Console.WriteLine("Please enter your age:\t");
        age = int.Parse(Console.ReadLine());
    }

    public void print_data()
    {
        Console.WriteLine($"Hi {name}, we welcome you to our bar.");
        if (age >= 18)
        {
            Console.WriteLine($"What would you like to drink {name}?");
        }
        else
        {
            Console.WriteLine($"{name} you are too young to drink yet.");
        }
    }
}



class Person
{
    public string name = "Ben";
    public int age = 18;
    public string email = "ben@gmail.com";
    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age) : this(name)
    {
        this.age = age;
    }
    public Person(string name, int age, string email) :
   this("Bob", age)
    {
        this.email = email;
    }

    public void print_names()
    {
        Console.WriteLine("\n");
        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(email);
    }

}

