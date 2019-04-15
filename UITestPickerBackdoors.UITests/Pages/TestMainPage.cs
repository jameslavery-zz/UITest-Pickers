using System;
using UITestPickerBackdoors.UITests.Extensions;
namespace UITestPickerBackdoors.UITests.Pages
{
    public class TestMainPage: BaseTestPage
    {
        readonly UIElement OrdinaryPicker;
        readonly UIElement DatePicker;

        public TestMainPage()
        {

            OrdinaryPicker = new UIElement("IdOrdinaryPicker");
            DatePicker = new UIElement("IdDatePicker");
        }

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("IdMainPage"),
            iOS = x => x.Marked("IdMainPage")
        };


        public void SetOrdinaryPickerValue(string value, bool showPicker = false)
        {
            AppManager.App.SetFormsPickerValue(AppManager.Platform, OrdinaryPicker.AutomationId, value,showPicker);
        }

        public void SetOrdinaryPickerIndex(string index, bool showPicker = false)
        {
            AppManager.App.SetFormsPickerIndex(AppManager.Platform, OrdinaryPicker.AutomationId, index, showPicker);
        }

        public void SetDatePickerValue(DateTime dateValue, bool showPicker = false)
        {
            AppManager.App.SetFormsDatePickerValue(AppManager.Platform, DatePicker.AutomationId, dateValue , showPicker);
        }
    }
}
