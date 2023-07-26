using Console_App.Services;

var weekdays =
    new[]
    {
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"
    };

var doomsdays = new int[]
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

Console.WriteLine(@"
 _______   ______     ______   .___  ___.      _______. _______       ___   ____    ____                   
|       \ /  __  \   /  __  \  |   \/   |     /       ||       \     /   \  \   \  /   /                   
|  .--.  |  |  |  | |  |  |  | |  \  /  |    |   (----`|  .--.  |   /  ^  \  \   \/   /                    
|  |  |  |  |  |  | |  |  |  | |  |\/|  |     \   \    |  |  |  |  /  /_\  \  \_    _/                     
|  '--'  |  `--'  | |  `--'  | |  |  |  | .----)   |   |  '--'  | /  _____  \   |  |                       
|_______/ \______/   \______/  |__|  |__| |_______/    |_______/ /__/     \__\  |__|                       
                                                                                                           
  ______     ___       __        ______  __    __   __          ___   .___________.  ______   .______      
 /      |   /   \     |  |      /      ||  |  |  | |  |        /   \  |           | /  __  \  |   _  \     
|  ,----'  /  ^  \    |  |     |  ,----'|  |  |  | |  |       /  ^  \ `---|  |----`|  |  |  | |  |_)  |    
|  |      /  /_\  \   |  |     |  |     |  |  |  | |  |      /  /_\  \    |  |     |  |  |  | |      /     
|  `----./  _____  \  |  `----.|  `----.|  `--'  | |  `----./  _____  \   |  |     |  `--'  | |  |\  \----.
 \______/__/     \__\ |_______| \______| \______/  |_______/__/     \__\  |__|      \______/  | _| `._____|
                                                                                                           
            ");
Console.WriteLine("Enter a valid date to calculate on what day of the week it falls on:");

try
{
    var date = Convert.ToDateTime(Console.ReadLine());
    
    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
    {
        Console.WriteLine($"{date.Year} is a leap day");
        doomsdays[1] = 29;
        doomsdays[0] = 4;
    }

    var lastTwoDigits = date.Year % 100;

    var centuryContribution = lastTwoDigits / 12;

    var remainingLastTwoDigits = lastTwoDigits - centuryContribution * 12;

    var leapYearCorrection = remainingLastTwoDigits / 4;

// Checks for the century's anchor day

    var centuryAnchorDay = DoomsdayService.GetCenturyAnchorDate(Convert.ToInt32(date.Year));

    var totalYearCorrection = centuryContribution + remainingLastTwoDigits + leapYearCorrection + centuryAnchorDay;

    for (var i = 0; i < 4; i++)
        if (totalYearCorrection <= 6 && totalYearCorrection >= 0)
            i = 4;
        else
            totalYearCorrection -= 7;

    var doomsdayDay = doomsdays[date.Month - 1];
    var remainingDays = doomsdayDay - date.Day;

// Checks for the remains of the remaining dates to dates input
    var calc5 = remainingDays % 7;

    var weekdayIndex = totalYearCorrection - calc5;


// // Checks if result is above 6
     if (weekdayIndex > 6)
     {
         weekdayIndex -= 7;
     }

    var weekday = weekdays[weekdayIndex];

    Console.WriteLine($"{date:MM/dd/yyyy} falls on: {weekday}");
    Console.ReadKey();
}
catch (FormatException)
{
    Console.WriteLine("Date is not in a valid format try DD-MM-YYYY");
}
