//8. Дано список будинків. Нехай будинок - це об'єкт.  Якщо це приватний будинок, то він містить список мешканців будинку, якщо ж це багатоквартирний будинок - він містить список квартир, кожна із яких містить список мешканців. Мешканець - це  об'єкт, що містить такі дані: ПІБ, стать і дату народження. Передбачити, що здійснювати обхід будинків можуть різні служби: 
//а.Військкомат виводить в консоль список дані всіх призовників (чоловіків віком від 18 до 27 років).
//б.Служба перепису населення підраховує загальну кількість мешканців.

using System;
using System.Collections.Generic;


class Resident
{
    public string FullName { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }

    public Resident(string fullName, string gender, DateTime birthDate)
    {
        FullName = fullName;
        Gender = gender;
        BirthDate = birthDate;
    }
}


interface IVisitor
{
    void VisitPrivateHouse(PrivateHouse privateHouse);
    void VisitApartmentBuilding(ApartmentBuilding apartmentBuilding);
}


class PrivateHouse
{
    public List<Resident> Residents { get; set; }

    public PrivateHouse()
    {
        Residents = new List<Resident>();
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitPrivateHouse(this);
    }
}


class ApartmentBuilding
{
    public List<List<Resident>> Apartments { get; set; }

    public ApartmentBuilding()
    {
        Apartments = new List<List<Resident>>();
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitApartmentBuilding(this);
    }
}

class MilitaryService : IVisitor
{
   

    public void VisitApartmentBuilding(ApartmentBuilding apartmentBuilding)
    {
        Console.WriteLine("Список призовників у багатоквартирному будинку:");
        foreach (var apartment in apartmentBuilding.Apartments)
        {
            foreach (var resident in apartment)
            {
                
                if (resident.Gender == "Male" && (DateTime.Now.Year - resident.BirthDate.Year) >= 18 && (DateTime.Now.Year - resident.BirthDate.Year) <= 27)
                {
                    Console.WriteLine($"ПІБ: {resident.FullName}, Вік: {DateTime.Now.Year - resident.BirthDate.Year}");
                }
            }
        }
    }
}


class CensusService : IVisitor
{
    public void VisitPrivateHouse(PrivateHouse privateHouse)
    {
        Console.WriteLine($"Приватний будинок має {privateHouse.Residents.Count} мешканців.");
    }

    public void VisitApartmentBuilding(ApartmentBuilding apartmentBuilding)
    {
        int totalResidents = 0;
        foreach (var apartment in apartmentBuilding.Apartments)
        {
            totalResidents += apartment.Count;
        }
        Console.WriteLine($"Багатоквартирний будинок має {totalResidents} мешканців.");
    }
}

class Program
{
    static void Main()
    {

        var privateHouse = new PrivateHouse();
        privateHouse.Residents.Add(new Resident("Іванов Іван", "Male", new DateTime(1990, 1, 1)));
        privateHouse.Residents.Add(new Resident("Петрова Марія", "Female", new DateTime(1995, 5, 5)));

        var apartmentBuilding = new ApartmentBuilding();
        apartmentBuilding.Apartments.Add(new List<Resident>
        {
            new Resident("Сидоров Олег", "Male", new DateTime(1985, 10, 10)),
            new Resident("Коваленко Ольга", "Female", new DateTime(1992, 2, 15))
        });
        apartmentBuilding.Apartments.Add(new List<Resident>
        {
            new Resident("Петренко Андрій", "Male", new DateTime(1988, 3, 20)),
            new Resident("Сергієнко Наталія", "Female", new DateTime(1990, 8, 25))
        });


        var militaryService = new MilitaryService();
        var censusService = new CensusService();


        privateHouse.Accept(militaryService);
        privateHouse.Accept(censusService);

        apartmentBuilding.Accept(militaryService);
        apartmentBuilding.Accept(censusService);
    }
}