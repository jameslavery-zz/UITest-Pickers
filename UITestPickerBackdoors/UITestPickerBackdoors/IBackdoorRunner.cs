using System;
namespace UITestPickerBackdoors
{
    /// <summary>
    /// This interface is only used so that we can call the BackDoorRunner from the core project.
    /// </summary>
    public interface IBackdoorRunner
    {
        void SetFormsPickerValue(string automationId, string value);
        void SetFormsDatePickerValue(string automationId, DateTime value);
    }
}
