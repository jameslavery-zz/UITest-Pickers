using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace UITestPickerBackdoors
{
    internal class MainPageModel : FreshBasePageModel
    {


        // Constructor
        public MainPageModel()
        {
            Title = "Main Page";

            SimpleItems = new string[] { "First item", "Second item", "And here's the third one" };
        }

        #region Bound Properties

        public string[] SimpleItems
        {
            get;
            set;
        }

        public string Title { get; set; }

        #endregion Bound Properties
    }
}