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

        #region Commands

        private ICommand _SetOrdinaryPickerCommand;
        public ICommand SetOrdinaryPickerCommand
        {
            get
            {
                if (_SetOrdinaryPickerCommand == null)
                {
                    _SetOrdinaryPickerCommand = new Command(() => this.SetOrdinaryPicker());
                }
                return _SetOrdinaryPickerCommand;
            }
        }

        private ICommand _SetDatePickerCommand;
        public ICommand SetDatePickerCommand
        {
            get
            {
                if (_SetDatePickerCommand == null)
                {
                    _SetDatePickerCommand = new Command(() => this.SetDatePicker());
                }
                return _SetDatePickerCommand;
            }
        }

        #endregion Commands

        #region Private Methods
        private void SetOrdinaryPicker()
        {
            var runner = FreshIOC.Container.Resolve<IBackdoorRunner>();
            runner.SetFormsPickerValue("IdOrdinaryPicker", "Second item");
        }

        private void SetDatePicker()
        {
            var runner = FreshIOC.Container.Resolve<IBackdoorRunner>();
            runner.SetFormsDatePickerValue("IdDatePicker", new System.DateTime(1973,3,22));
        }

        #endregion Private Methods
    }
}