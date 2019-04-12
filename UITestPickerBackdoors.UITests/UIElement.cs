using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITestPickerBackdoors.UITests
{
    /// <summary>
    /// This class allows us to access either the AutomationId or the actual Element when running tests.
    /// </summary>
    /// <remarks>
    /// This is needed because sometimes we need the actual AutomationId, sometimes the element itself.
    /// </remarks>
    public class UIElement
    {
        public string AutomationId
        {
            get;
            set;
        }

        public Query Element
        {
            get;
            set;
        }

        public UIElement(string automationId)
        {
            AutomationId = automationId;
            Element = x => x.Marked(automationId);
        }
    }
}