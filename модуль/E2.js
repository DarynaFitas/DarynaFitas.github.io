//2.Створити функцію, яка за назвою дня тижня повертає список пар на цей день.
console.log("Write day of the week");
function getPairsByDayOfWeek(dayOfWeek) 
{
    switch (dayOfWeek) 
    {
      case "Monday":
        return ["Math Analise", "Web", "Programing"];
      case "Tuesday":
        return ["Algebra", "Geometry", "Web"];
      case "Wednesday":
        return ["Physics", "Math Analise", "English"];
      case "Thursday":
        return ["English", "Discrent Math", "Math Analise"];
      case "Friday":
        return ["Programing", "Math Analise", "Web"];
      case "Saturday":
        return ["No classes"];
      case "Sunday":
        return ["No classes"];
      default:
        return [];
    }
}