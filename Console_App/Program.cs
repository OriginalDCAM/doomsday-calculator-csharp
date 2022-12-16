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
var anchorYears = new int[4, 3]
{
    {1800, 1899, 5}, // Friday
    {1900, 1999, 3}, // Wednesday
    {2000, 2099, 2}, // Tuesday
    {2100, 2199, 6} // Sunday
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
var date = Convert.ToDateTime(Console.ReadLine());

if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
{
    Console.WriteLine($"{date.Year} is a leap day");
    doomsdays[1] = 29;
    doomsdays[0] = 4;
}

var lastTwoDigits = Convert.ToInt32(date.Year) % 100;

var calc1 = lastTwoDigits / 12;

var calc2 = lastTwoDigits - calc1 * 12;

var calc3 = calc2 / 4;

var centuryAnchorDay = 0;
// Checks for the century's anchor day
for (var i = 0; i < 4; i++)
    if (Convert.ToInt32(date.Year) >= anchorYears[i, 0] && Convert.ToInt32(date.Year) <= anchorYears[i, 1])
        centuryAnchorDay = anchorYears[i, 2];

var calc4 = calc1 + calc2 + calc3 + centuryAnchorDay;

for (var i = 0; i < 4; i++)
    if (calc4 <= 6 && calc4 >= 0)
        i = 4;
    else
        calc4 =- 7;

var doomsdayDay = doomsdays[Convert.ToInt32(date.Month) - 1];
var remainingDays = Convert.ToInt32(doomsdayDay - date.Day);

// Checks for the remains of the remaining dates to dates input
var calc5 = remainingDays % 7;

var result = Convert.ToDouble(calc4 - calc5);

// Checks if result is negative
if (double.IsNegative(result)) result += 7;

// Checks if result is above 6
if (result > 6) result -= 7;
Console.WriteLine(weekdays[Convert.ToInt32(result)]);
Console.ReadKey();