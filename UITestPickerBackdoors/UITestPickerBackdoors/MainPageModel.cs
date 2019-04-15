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

        private ICommand _SetOrdinaryPickerValueCommand;
        public ICommand SetOrdinaryPickerValueCommand
        {
            get
            {
                if (_SetOrdinaryPickerValueCommand == null)
                {
                    _SetOrdinaryPickerValueCommand = new Command(() => this.SetOrdinaryPickerValue());
                }
                return _SetOrdinaryPickerValueCommand;
            }
        }

        private ICommand _SetOrdinaryPickerIndexCommand;
        public ICommand SetOrdinaryPickerIndexCommand
        {
            get
            {
                if (_SetOrdinaryPickerIndexCommand == null)
                {
                    _SetOrdinaryPickerIndexCommand = new Command(() => this.SetOrdinaryPickerIndex());
                }
                return _SetOrdinaryPickerIndexCommand;
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
        private void SetOrdinaryPickerValue()
        {
            var runner = FreshIOC.Container.Resolve<IBackdoorRunner>();
            runner.SetFormsPickerValue("IdOrdinaryPicker", "Second item");
        }

        private void SetOrdinaryPickerIndex()
        {
            var runner = FreshIOC.Container.Resolve<IBackdoorRunner>();
            runner.SetFormsPickerIndex("IdOrdinaryPicker", 2);
        }

        private void SetDatePicker()
        {
            var runner = FreshIOC.Container.Resolve<IBackdoorRunner>();
            runner.SetFormsDatePickerValue("IdDatePicker", new System.DateTime(1973,3,22));
        }

        #endregion Private Methods
    }
}