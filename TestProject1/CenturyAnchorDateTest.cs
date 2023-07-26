
namespace TestProject1;

[TestClass]
public class CenturyAnchorDateTest
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(2,DoomsdayService.GetCenturyAnchorDate(2005));
        Assert.AreEqual(5,DoomsdayService.GetCenturyAnchorDate(1818));
        Assert.AreEqual(3,DoomsdayService.GetCenturyAnchorDate(1955));
        Assert.AreEqual(0,DoomsdayService.GetCenturyAnchorDate(2105));
        Assert.AreEqual(3, DoomsdayService.GetCenturyAnchorDate(300));
    }
}