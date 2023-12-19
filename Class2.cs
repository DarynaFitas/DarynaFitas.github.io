using System;
using System.Linq;

class Program
{
	static void Main()
	{
		using (var dbKafedra = new Kafedra())
		{
			Console.WriteLine("Введіть значення параметра (surname):");
			string userInput = Console.ReadLine();

			var teacherBySurname = dbKafedra.Kafedra.FirstOrDefault(t => t.Surname == userInput);

			if (teacherBySurname != null)
			{
				Console.WriteLine($"Знайдено викладача: {teacherBySurname.FirstName} {teacherBySurname.LastName}");
			}
			else
			{
				Console.WriteLine("Викладача з таким прізвищем не знайдено.");
			}
		}
	}
}
