using NUnit.Framework;
using UITestPickerBackdoors.UITests.Pages;
using Xamarin.UITest;
using System;

namespace UITestPickerBackdoors.UITests
{

    public class Tests : BaseTestFixture
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

            p.SelectOrdinaryPickerValue("And here's the third one", true);

        }

        [Test]
        public void ICanSetADatePickerValue()
        {
            var p = new TestMainPage();

            p.SelectDatePickerValue(new DateTime(1982, 02, 05));
            AppManager.Screenshot("After selecting date");

            p.SelectDatePickerValue(new DateTime(1960, 11, 22), true);
            AppManager.Screenshot("After selecting date and showing picker");

        }

        [Test]
        public void ICanSetBothTypesOfPicker()
        {
            var p = new TestMainPage();

            p.SelectOrdinaryPickerValue("Second item");
            AppManager.Screenshot("After selecting second item");

            p.SelectOrdinaryPickerValue("And here's the third one", true);

            p.SelectDatePickerValue(new DateTime(1982, 02, 05));
            AppManager.Screenshot("After selecting date");

            p.SelectDatePickerValue(new DateTime(1960, 11, 22), true);
            AppManager.Screenshot("After selecting date and showing picker");

        }
    }
}
