using AltTester.AltTesterUnitySDK.Driver;
using NUnit.Framework;

public class TestReversePortForwarding
{
    private AltDriver altDriver;

    [OneTimeSetUp]
    public void SetUp()
    {
        AltReversePortForwarding.ReversePortForwardingAndroid();
        altDriver = new AltDriver();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
        AltReversePortForwarding.RemoveReversePortForwardingAndroid();
    }

    [Test]
    [Ignore("No Android pipeline is set up yet")]
    public void TestStartGame()
    {
        altDriver.LoadScene("Scene 2 Draggable Panel");

        altDriver.FindObject(By.NAME, "Close Button").Tap();
        altDriver.FindObject(By.NAME, "Button").Tap();

        var panelElement = altDriver.WaitForObject(By.NAME, "Panel");
        Assert.IsTrue(panelElement.enabled);
    }
}