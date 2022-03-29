using System;
using System.Threading;
using Altom.AltUnityDriver;
using NUnit.Framework;

public class TestForNIS
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    string scene7 = "Assets/AltUnityTester/Examples/Scenes/Scene 7 Drag And Drop NIS";
    string scene8 = "Assets/AltUnityTester/Examples/Scenes/Scene 8 Draggable Panel NIP.unity";
    string scene9 = "Assets/AltUnityTester/Examples/Scenes/scene 9 NIS.unity";
    string scene10 = "Assets/AltUnityTester/Examples/Scenes/Scene 10 Sample NIS.unity";
    string scene11 = "Assets/AltUnityTester/Examples/Scenes/Scene 7 New Input System Actions.unity";

    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver = new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestScroll()
    {
        altUnityDriver.LoadScene(scene10);
        var player = altUnityDriver.FindObject(By.NAME, "Player");
        Assert.False(player.GetComponentProperty<bool>("AltUnityNIPDebugScript", "wasScrolled", "Assembly-CSharp"));
        altUnityDriver.Scroll(300, 1, true);
        Assert.True(player.GetComponentProperty<bool>("AltUnityNIPDebugScript", "wasScrolled", "Assembly-CSharp"));
    }

    //TODO Test with scroll on an UI element
    /*
    I checked already and it's working with the current implementation but to write a test for it I need to move the mouse to the UI element
    */

    
        [Test]
        public void TestClickObject()
        {
            altUnityDriver.LoadScene(scene11);
            var capsule = altUnityDriver.FindObject(By.NAME, "Capsule");
            capsule.Click();
            Assert.True(capsule.GetComponentProperty<bool>("AltUnityExampleNewInputSystem", "wasClicked", "Assembly-CSharp"));
            
        }

        [Test]
        public void TestClickCoordinates()
        {
            altUnityDriver.LoadScene(scene11);
            var capsule = altUnityDriver.FindObject(By.NAME, "Capsule");
            altUnityDriver.Click(new AltUnityVector2(capsule.x, capsule.y));
            Assert.True(capsule.GetComponentProperty<bool>("AltUnityExampleNewInputSystem", "wasClicked", "Assembly-CSharp"));

        }
       

}