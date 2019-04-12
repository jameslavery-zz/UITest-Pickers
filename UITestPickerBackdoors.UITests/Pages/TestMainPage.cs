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

 
        public void SelectOrdinaryPickerValue(string value)
        {
            AppManager.App.SelectPickerValue(AppManager.Platform, OrdinaryPicker.AutomationId, value);
        }


    }
}
