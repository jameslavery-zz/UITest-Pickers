using NUnit.Framework;
using UITestPickerBackdoors.UITests.Pages;
using Xamarin.UITest;

namespace UITestPickerBackdoors.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests :BaseTestFixture
    {
        public Tests(Platform platform)
              : base(platform) { }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void ICanSetAnOrdinaryPickerValue()
        {
            var p = new TestMainPage();
            p.SelectOrdinaryPickerValue("Second item");
            AppManager.Screenshot("After selecting second item");
        }
    }
}
