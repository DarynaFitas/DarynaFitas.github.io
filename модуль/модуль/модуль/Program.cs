//Варіант 9
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

public struct Employee
{
    public int EmployeeCode;
    public string LastName;
    public DateTime BirthDate;
    public string Gender;
    public int WorkshopNumber;
    public string Position;
    public int Experience;
    public double Salary;
}

public struct Bonus
{
    public int EmployeeCode;
    public double Amount;
}

public class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                EmployeeCode = 1,
                LastName = "Петрова",
                BirthDate = new DateTime(1980, 05, 15),
                Gender = "жінка",
                WorkshopNumber = 2,
                Position = "інженер",
                Experience = 10,
                Salary = 4000
            },

            new Employee
            {
                EmployeeCode = 2,
                LastName = "Сухович",
                BirthDate = new DateTime(1979, 02, 09),
                Gender = "чоловік",
                WorkshopNumber = 3,
                Position = "слесарь",
                Experience = 12,
                Salary = 3500
            },

            new Employee
            {
                EmployeeCode = 3,
                LastName = "Сидорчак",
                BirthDate = new DateTime(2003, 03, 09),
                Gender = "жінка",
                WorkshopNumber = 1,
                Position = "стажер",
                Experience = 1,
                Salary = 2000
            },

            new Employee
            {
                EmployeeCode = 4,
                LastName = "Перепів",
                BirthDate = new DateTime(1968, 05, 05),
                Gender = "чоловік",
                WorkshopNumber = 2,
                Position = "механік",
                Experience = 22,
                Salary = 5600
            },

            new Employee
            {
                EmployeeCode = 5,
                LastName = "Антремов",
                BirthDate = new DateTime(1980, 12, 12),
                Gender = "чоловік",
                WorkshopNumber = 1,
                Position = "головний управляючий",
                Experience = 13,
                Salary = 10500
            },

            new Employee
            {
                EmployeeCode = 6,
                LastName = "Любовславівненко",
                BirthDate = new DateTime(1999, 08, 01),
                Gender = "жінка",
                WorkshopNumber = 3,
                Position = "СММ",
                Experience = 5,
                Salary = 12600
            },

            new Employee
            {
                EmployeeCode = 7,
                LastName = "Кирлик",
                BirthDate = new DateTime(1951, 01, 09),
                Gender = "жінка",
                WorkshopNumber = 1,
                Position = "інструктор",
                Experience = 30,
                Salary = 12200
            },

            new Employee
            {
                EmployeeCode = 8,
                LastName = "Куруц",
                BirthDate = new DateTime(1952, 02, 18),
                Gender = "чоловік",
                WorkshopNumber = 2,
                Position = "головний інженер",
                Experience = 26,
                Salary = 7800
            },

            new Employee
            {
                EmployeeCode = 9,
                LastName = "Борок",
                BirthDate = new DateTime(1962, 07, 02),
                Gender = "жінка",
                WorkshopNumber = 3,
                Position = "СММ",
                Experience = 18,
                Salary = 3600
            },

            new Employee
            {
                EmployeeCode = 10,
                LastName = "Серенчак",
                BirthDate = new DateTime(1996, 02, 21),
                Gender = "чоловік",
                WorkshopNumber = 1,
                Position = "Дизайнер ВЕБ Сайту",
                Experience = 4,
                Salary = 10600
            }

        };

        List<Bonus> bonuses = new List<Bonus>
        {
            new Bonus
            {
                EmployeeCode = 1,
                Amount = 500
            },

            new Bonus
            {
                EmployeeCode = 2,
                Amount = 1000
            },

            new Bonus
            {
                EmployeeCode = 3,
                Amount = 750
            },

            new Bonus
            {
                EmployeeCode = 4,
                Amount = 1200
            },

            new Bonus
            {
                EmployeeCode = 5,
                Amount = 1500
            },

            new Bonus
            {
                EmployeeCode = 6,
                Amount = 2500
            },

            new Bonus
            {
                EmployeeCode = 7,
                Amount = 1200
            },

            new Bonus
            {
                EmployeeCode = 8,
                Amount = 300
            },

            new Bonus
            {
                EmployeeCode = 9,
                Amount = 5000
            },

            new Bonus
            {
                EmployeeCode = 10,
                Amount = 3500
            }
};


        int employeesWithBonus = bonuses.Select(bonus => bonus.EmployeeCode).Distinct().Count();
        Console.WriteLine($"Кількість працівників з премією: {employeesWithBonus}");

        var pensioners = employees.Where(employee => DateTime.Now.Year - employee.BirthDate.Year >= 60 && employee.Gender == "жінка").ToList();
        double averageSalaryPensioners = pensioners.Average(pensioner => pensioner.Salary);
        var highPaidWomen = pensioners.Where(pensioner => pensioner.Salary > averageSalaryPensioners).Select(pensioner => pensioner.LastName).ToArray();

        Console.WriteLine("Прізвища жінок-пенсіонерів із високою зарплатою:");
        foreach (var lastName in highPaidWomen)
        {
            Console.WriteLine(lastName);
        }

        SaveToXml(employees, "employees.xml");
        Console.WriteLine("Дані про працівників збережено у employees.xml");
    }

    public static void SaveToXml<T>(List<T> data, string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (FileStream fileStream = File.Create(filename))
        {
            serializer.Serialize(fileStream, data);
        }
    }
}