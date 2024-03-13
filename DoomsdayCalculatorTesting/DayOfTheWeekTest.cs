namespace DoomsdayCalculatorTest;

[TestClass]
public class DayOfTheWeekTest 
{
    [TestMethod]
    public void CalculateWeekdayIndex_Returns2_ForDate2005_03_01()
    {
        DateTime dateValue = new DateTime(2005, 3, 1);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(2, result);
    }
    [TestMethod]
    public void CalculateWeekdayIndex_Returns0_ForDate2022_08_07() // Sunday
    {
        DateTime dateValue = new DateTime(2022, 8, 7);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns1_ForDate2022_08_08() // Monday
    {
        DateTime dateValue = new DateTime(2022, 8, 8);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns2_ForDate2022_08_09() // Tuesday
    {
        DateTime dateValue = new DateTime(2022, 8, 9);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns3_ForDate2022_08_10() // Wednesday
    {
        DateTime dateValue = new DateTime(2022, 8, 10);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns4_ForDate2022_08_11() // Thursday
    {
        DateTime dateValue = new DateTime(2022, 8, 11);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns5_ForDate2022_08_12() // Friday
    {
        DateTime dateValue = new DateTime(2022, 8, 12);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void CalculateWeekdayIndex_Returns6_ForDate2022_08_13() // Saturday
    {
        DateTime dateValue = new DateTime(2022, 8, 13);
        int result = DoomsdayCalculator.CalculateWeekdayIndex(dateValue);
        Assert.AreEqual(6, result);
    }
}