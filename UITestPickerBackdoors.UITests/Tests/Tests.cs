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
            p.SetOrdinaryPickerValue("Second item");
            AppManager.Screenshot("After selecting second item");

            p.SetOrdinaryPickerValue("And here's the third one", true);

        }

        [Test]
        public void ICanSetAnOrdinaryPickerIndex()
        {
            var p = new TestMainPage();
            p.SetOrdinaryPickerIndex("2");
            AppManager.Screenshot("After selecting index 2");
        }

        [Test]
        public void ICanSetAnOrdinaryPickerToFirstItem()
        {
            var p = new TestMainPage();
            p.SetOrdinaryPickerValue("Second item");
            AppManager.Screenshot("After selecting first item");


        }

        [Test]
        public void ICanSetADatePickerValue()
        {
            var p = new TestMainPage();

            p.SetDatePickerValue(new DateTime(1982, 02, 05));
            AppManager.Screenshot("After selecting date");

            p.SetDatePickerValue(new DateTime(1960, 11, 22), true);
            AppManager.Screenshot("After selecting date and showing picker");

        }

        [Test]
        public void ICanSetBothTypesOfPicker()
        {
            var p = new TestMainPage();

            p.SetOrdinaryPickerValue("Second item");
            AppManager.Screenshot("After selecting second item");

            p.SetOrdinaryPickerValue("And here's the third one", true);

            p.SetDatePickerValue(new DateTime(1982, 02, 05));
            AppManager.Screenshot("After selecting date");

            p.SetDatePickerValue(new DateTime(1960, 11, 22), true);
            AppManager.Screenshot("After selecting date and showing picker");

        }
    }
}
