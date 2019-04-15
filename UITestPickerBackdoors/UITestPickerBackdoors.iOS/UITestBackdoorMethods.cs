using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace UITestPickerBackdoors.iOS
{
    public static class UITestBackdoorMethods
    {
#if ENABLE_TEST_CLOUD

        #region Public Methods

        /// <summary>
        /// Sets a DatePicker to the value provided.
        /// </summary>
        /// <returns>"OK" on success, or a simple message on failure.</returns>
        /// <param name="automationId">The AutomationId of the Picker to update.</param>
        /// <param name="value">The DateTime value to which to set the Picker</param>
        public static string SetFormsDatePickerValue(string automationId, DateTime value)
        {
            var foundPickerRenderer = FindRendererOfTypeWithAutomationId<DatePickerRenderer>(automationId);
            if (foundPickerRenderer != null)
            {
                foundPickerRenderer.Element.Date = value;
                return "OK";
            }
            return $"Could not find picker with AutomationId {automationId}";
        }

        /// <summary>
        /// Sets a Picker to the value provided.
        /// </summary>
        /// <returns>"OK" on success, or a simple message on failure.</returns>
        /// <param name="automationId">The AutomationId of the Picker to update.</param>
        /// <param name="value">The value to which to set the Picker. This must exist in the list of values for the Picker.</param>
        public static string SetFormsPickerValue(string automationId, string value)
        {
            var foundPickerRenderer = FindRendererOfTypeWithAutomationId<PickerRenderer>(automationId);
            if (foundPickerRenderer != null)
            {
                // For some reason setting SelectedItem doesn't work reliably (probably when the Picker is bound to a non-simple object list).
                // So we use SelectedIndex instead
                for (int index = 0; index < foundPickerRenderer.Element.Items.Count; index++)
                {
                    if (foundPickerRenderer.Element.Items[index] == value)
                    {
                        foundPickerRenderer.Element.SelectedIndex = index;
                        return "OK";
                    }
                }
                return $"Could not find value '{value}' in items for picker with AutomationId {automationId}";
            }
            else
            {
                return $"Could not find picker with AutomationId {automationId}";
            }
        }

        /// <summary>
        /// Sets a Picker to the first available item in its list of values.
        /// </summary>
        /// <returns>"OK" on success, or a simple message on failure.</returns>
        /// <param name="automationId">The AutomationId of the Picker whose value is to be set.</param>
        public static string SetFormsFirstPickerValue(string automationId)
        {
            var foundPickerRenderer = FindRendererOfTypeWithAutomationId<PickerRenderer>(automationId);
            if (foundPickerRenderer != null)
            {
                foundPickerRenderer.Element.SelectedItem = 0;
                return "OK";
            }
            else
            {
                return $"Could not find picker with AutomationId {automationId}";
            }
        }

        #endregion Public Methods


        #region Private Methods

        private static T FindRendererOfTypeWithAutomationId<T>(string automationId)
        {
            UIViewController currentViewController = GetTopViewController();
            return FindRendererOfTypeBelowViewWithAutomationId<T>(currentViewController.View, automationId);
        }


        /// <summary>
        /// Finds the picker renderer with the given AutomationId, below the given View.
        /// </summary>
        /// <returns>The picker renderer with identifier below view.</returns>
        /// <param name="view">The top-level View</param>
        /// <param name="automationId">The AutomationId being sought.</param>
        /// <typeparam name="T">The type being sought</typeparam>
        private static T FindRendererOfTypeBelowViewWithAutomationId<T>(object view, string automationId)
        {
            if (view is T)
            {
                // There is probably a more elegant way to to this. But we need the Element property, and then need to get the
                // AutomationId of the Element.
                var elementProperty = view.GetType().GetProperty("Element");
                if (elementProperty != null)
                {
                    var element = elementProperty.GetValue(view);

                    var automationIdProperty = element.GetType().GetProperty("AutomationId");
                    if (automationIdProperty != null)
                    {
                        var automationIdValue = automationIdProperty.GetValue(element);
                        if ((string)automationIdValue == automationId)
                        {
                            return (T)view;
                        }
                    }
                }
            }
            else
            {
                foreach (UIView subView in (view as UIView).Subviews)
                {
                    var r = FindRendererOfTypeBelowViewWithAutomationId<T>(subView, automationId);
                    if (r != null)
                    {
                        return r;
                    }
                }
            }

            return default(T);
        }

        static UIViewController GetTopViewController()
        {
            return GetTopViewControllerWithRootViewController(UIApplication.SharedApplication.KeyWindow.RootViewController);
        }

        static UIViewController GetTopViewControllerWithRootViewController(UIViewController rootViewController)
        {
            if (rootViewController is UITabBarController)
            {
                UITabBarController tabbarController = (UITabBarController)rootViewController;
                return GetTopViewControllerWithRootViewController(tabbarController.SelectedViewController);
            }
            else if (rootViewController is UINavigationController)
            {
                UINavigationController navigationController = (UINavigationController)rootViewController;
                return GetTopViewControllerWithRootViewController(navigationController.VisibleViewController);
            }
            else if (rootViewController.PresentedViewController != null)
            {
                UIViewController presentedViewController = rootViewController.PresentedViewController;
                return GetTopViewControllerWithRootViewController(presentedViewController);
            }
            return rootViewController;
        }

        #endregion Private Methods
#endif
    }
}

