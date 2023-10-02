namespace DoomsdayCalculatorCore.Services;

public class DoomsdayService
{
    public static int GetCenturyAnchorDate(int year)
    {
        var anchorYears = new int[4, 3]
        {
            {1800, 1899, 5}, // Friday
            {1900, 1999, 3}, // Wednesday
            {2000, 2099, 2}, // Tuesday
            {2100, 2199, 0} // Sunday
        };
        while (year < anchorYears[0, 0])
        {
            year += 400;
        }

        while (year > anchorYears[3, 1])
        {
            year -= 400;
        }

        var centuryAnchorDate = 0;
        // Implement a solution for if the anchor year is not in the array
        for (var i = 0; i < anchorYears.GetLength(0); i++)
        {
            if (year >= anchorYears[i, 0] && year <= anchorYears[i, 1])
            {
                centuryAnchorDate = anchorYears[i, 2];
            }
        }

        return centuryAnchorDate;
    }
}