namespace DoomsdayCalculatorTest;

[TestClass]
public class CenturyAnchorDateTest
{
    [TestMethod]
    public void GetCenturyAnchorDate_Returns2_ForYear2005()
    {
        int year = 2005;

        int result = DoomsdayService.GetCenturyAnchorDate(year);
        
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void GetCenturyAnchorDate_Returns5_ForYear1818()
    {
        
        int year = 1818;

        int result = DoomsdayService.GetCenturyAnchorDate(year);
        
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void GetCenturyAnchorDate_Returns0_ForYear2105()
    {
        
        int year = 2105;

        int result = DoomsdayService.GetCenturyAnchorDate(year);
        
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetCenturyAnchorDate_Returns3_ForYear300()
    {
        int year = 300;

        int result = DoomsdayService.GetCenturyAnchorDate(year);
        
        Assert.AreEqual(3, result);
    }
}