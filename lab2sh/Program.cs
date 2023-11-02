using System;
using System.Collections.Generic;


public interface IComponent
{
    void Display(int depth);
}

public class Employee : IComponent
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public Employee(string fullName, string position)
    {
        FullName = fullName;
        Position = position;
    }

    public void Display(int depth)
    {
        string indentation = new string(' ', depth * 4);
        Console.WriteLine($"{indentation}- {Position}: {FullName}");
    }
}


public class Department : IComponent
{
    public string Name { get; set; }
    public List<IComponent> Components { get; set; }

    public Department(string name)
    {
        Name = name;
        Components = new List<IComponent>();
    }

    public void AddComponent(IComponent component)
    {
        Components.Add(component);
    }

    public void Display(int depth)
    {
        string indentation = new string(' ', depth * 4);
        Console.WriteLine($"{indentation}{Name}");

        foreach (var component in Components)
        {
            component.Display(depth + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Department university = new Department("Університет");

       
        Department faculty1 = new Department("Факультет 1");
        Department faculty2 = new Department("Факультет 2");

        university.AddComponent(faculty1);
        university.AddComponent(faculty2);

       
        Employee employee1 = new Employee("ПІБ1", "Викладач");
        Employee employee2 = new Employee("ПІБ2", "Асистент");

        faculty1.AddComponent(employee1);
        faculty2.AddComponent(employee2);

        university.Display(0);
    }
}
