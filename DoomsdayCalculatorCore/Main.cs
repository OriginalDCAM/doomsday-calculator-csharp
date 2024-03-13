using DoomsdayCalculatorCore.Services;

class DoomsdayCalculator
{
    private enum weeksdays
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    private static int[] _doomsdays =
    {
        3,
        28,
        7,
        4,
        9,
        6,
        11,
        8,
        5,
        10,
        7,
        12
    };


    public static int Main()
    {
        Console.WriteLine("Enter a valid date to calculate on what day of the week it falls on:");

        if (!DateTime.TryParse(Console.ReadLine(), out var dateValue))
        {
            Console.WriteLine("Date is not in a valid format try DD-MM-YYYY");
            return 0;
        }

        var weekdayIndex = CalculateWeekdayIndex(dateValue);

        Console.WriteLine($"{dateValue:dd/MM/yyyy} falls on: {(weeksdays) weekdayIndex}");

        Console.ReadKey();
        return 1;
    }

    private static int CalculateWeekdayIndex(DateTime dateValue)
    {
        
        if ((dateValue.Year % 4 == 0 && dateValue.Year % 100 != 0) || dateValue.Year % 400 == 0)
        {
            Console.WriteLine($"{dateValue.Year} is a leap year");
            _doomsdays[1] = 29;
            _doomsdays[0] = 4;
        }

        var totalYearCorrection = CalculateTotalYearCorrection(dateValue.Year);

        var doomsdayDay = _doomsdays[dateValue.Month - 1];
        var remainingDays = doomsdayDay - dateValue.Day;

        // Checks for the remains of the remaining dates to dates input
        var calc5 = remainingDays % 7;

        var weekdayIndex = totalYearCorrection - calc5;

        weekdayIndex = weekdayIndex > 6 ? weekdayIndex - 7 : weekdayIndex;

        return weekdayIndex;
    }

    private static int CalculateTotalYearCorrection(int dateYear)
    {
        var lastTwoDigits = dateYear % 100;
        var centuryContribution = lastTwoDigits / 12;
        var remainingLastTwoDigits = lastTwoDigits - centuryContribution * 12;
        var leapYearCorrection = remainingLastTwoDigits / 4;
        var centuryAnchorDay = DoomsdayService.GetCenturyAnchorDate(dateYear);
        var totalYearCorrection = centuryContribution + remainingLastTwoDigits + leapYearCorrection + centuryAnchorDay;

        for (var i = 0; i < 4; i++)
            if (totalYearCorrection < 7 && totalYearCorrection >= 0)
                break;
            else
                totalYearCorrection -= 7;

        return totalYearCorrection;
    }
}
