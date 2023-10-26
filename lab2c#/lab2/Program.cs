using System;
using System.Collections.Generic;
using System.Linq;

public class AviaFlight
{
    public int FlightNumber { get; set; }
    public string DeparturePoint { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
}

public class Ticket
{
    public int TicketNumber { get; set; }
    public int FlightNumber { get; set; }
    public DateTime Date { get; set; }
    public string Seat { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<AviaFlight> flights = new List<AviaFlight>
        {
            new AviaFlight { FlightNumber = 1, DeparturePoint = "Kyiv", Destination = "Paris", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3), Price = 300 },
            new AviaFlight { FlightNumber = 2, DeparturePoint = "Prague", Destination = "London", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3), Price = 800 },
            new AviaFlight { FlightNumber = 3, DeparturePoint = "Kosice", Destination = "Bratislava", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3), Price = 500 },
            new AviaFlight { FlightNumber = 4, DeparturePoint = "Warshaw", Destination = "Pardubice", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3), Price = 750 },
            new AviaFlight { FlightNumber = 5, DeparturePoint = "Uzhhorod", Destination = "Antalia", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3), Price = 2300 }
        };

        List<Ticket> tickets = new List<Ticket>
        {
            new Ticket { TicketNumber = 1, FlightNumber = 1, Date = DateTime.Now, Seat = "A1" },
            new Ticket { TicketNumber = 2, FlightNumber = 2, Date = DateTime.Now, Seat = "C22" },
            new Ticket { TicketNumber = 3, FlightNumber = 3, Date = DateTime.Now, Seat = "B15" },
            new Ticket { TicketNumber = 4, FlightNumber = 4, Date = DateTime.Now, Seat = "A8" },
            new Ticket { TicketNumber = 5, FlightNumber = 5, Date = DateTime.Now, Seat = "C1" },
        };

        DateTime targetDate = DateTime.Now; 
        string targetSeat = "A1"; 

        var destinationsWithTickets = flights
            .Join(tickets, f => f.FlightNumber, t => t.FlightNumber, (f, t) => new { f.Destination, t.Date, t.Seat })
            .Where(ticketInfo => ticketInfo.Date.Date == targetDate.Date && ticketInfo.Seat == targetSeat)
            .Select(info => info.Destination)
            .Distinct();

        Console.WriteLine("Пункти призначення, у які придбано квитки у заданий день на задане місце:");
        foreach (var destination in destinationsWithTickets)
        {
            Console.WriteLine(destination);
        }

        DateTime oneYearAgo = DateTime.Now.AddYears(-1);

        var flightStats = flights
            .Where(f => f.DepartureTime >= oneYearAgo)
            .GroupJoin(tickets, f => f.FlightNumber, t => t.FlightNumber, (f, t) => new
            {
                f.FlightNumber,
                Duration = (f.ArrivalTime - f.DepartureTime).TotalHours,
                TotalTicketsSold = t.Count()
            })
            .OrderBy(f => f.Duration);

        Console.WriteLine("Номер рейсу | Тривалість (години) | Кількість проданих квитків");
        foreach (var flightStat in flightStats)
        {
            Console.WriteLine($"{flightStat.FlightNumber} | {flightStat.Duration} | {flightStat.TotalTicketsSold}");
        }

        var destinationTicketCounts = flights
            .GroupJoin(tickets, f => f.FlightNumber, t => t.FlightNumber, (f, t) => new
            {
                f.Destination,
                TotalTicketsSold = t.Count()
            })
            .OrderByDescending(f => f.TotalTicketsSold)
            .First();

        Console.WriteLine("Пункт призначення з найбільшою кількістю проданих квитків:");
        Console.WriteLine($"{destinationTicketCounts.Destination} ({destinationTicketCounts.TotalTicketsSold} квитків)");
    }
}
