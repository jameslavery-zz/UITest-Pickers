using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace UITestPickerBackdoors.iOS
{
    public static class UITestBackdoorMethods
    {
#if ENABLE_TEST_CLOUD
        static PickerRenderer foundPickerRenderer = null;
        static DatePickerRenderer foundDatePickerRenderer = null;

        #region Public Methods

    
        public static string SetFormsDatePickerValue(string automationId, DateTime value)
        {
            FindDatePickerRendererWithId(automationId);
            if (foundDatePickerRenderer != null)
            {
                foundDatePickerRenderer.Element.Date = value;
                return "OK";
            }
            return $"Could not find picker with AutomationId {automationId}";
        }

        public static string SetFormsPickerValue(string automationId, string value)
        {
            FindPickerRendererWithId(automationId);
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


        public static string SetFormsFirstPickerValue(string automationId)
        {
            FindPickerRendererWithId(automationId);
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


        private static void FindDatePickerRendererWithId(string automationId)
        {
            UIViewController currentViewController = topViewController();
            FindDatePickerRendererWithIdBelowView(currentViewController.View, automationId);
        }


        private static void FindDatePickerRendererWithIdBelowView(UIView view, string automationId)
        {
            if (view is DatePickerRenderer)
            {
                var p = (DatePickerRenderer)view;
                if (p.Element.AutomationId == automationId)
                {
                    foundDatePickerRenderer = p;
                }
            }
            else
            {
                foreach (UIView subView in view.Subviews)
                {
                    FindDatePickerRendererWithIdBelowView(subView, automationId);
                }
            }
        }

        private static void FindPickerRendererWithId(string automationId)
        {
            UIViewController currentViewController = topViewController();
            FindPickerRendererWithIdBelowView(currentViewController.View, automationId);
        }


        private static void FindPickerRendererWithIdBelowView(UIView view, string automationId)
        {
            if (view is PickerRenderer)
            {
                var p = (PickerRenderer)view;
                if (p.Element.AutomationId == automationId)
                {
                    foundPickerRenderer = p;
                }
            }
            else
            {
                foreach (UIView subView in view.Subviews)
                {
                    FindPickerRendererWithIdBelowView(subView, automationId);
                }
            }
        }

        static UIViewController topViewController()
        {
            return topViewControllerWithRootViewController(UIApplication.SharedApplication.KeyWindow.RootViewController);
        }

        static UIViewController topViewControllerWithRootViewController(UIViewController rootViewController)
        {
            if (rootViewController is UITabBarController)
            {
                UITabBarController tabbarController = (UITabBarController)rootViewController;
                return topViewControllerWithRootViewController(tabbarController.SelectedViewController);
            }
            else if (rootViewController is UINavigationController)
            {
                UINavigationController navigationController = (UINavigationController)rootViewController;
                return topViewControllerWithRootViewController(navigationController.VisibleViewController);
            }
            else if (rootViewController.PresentedViewController != null)
            {
                UIViewController presentedViewController = rootViewController.PresentedViewController;
                return topViewControllerWithRootViewController(presentedViewController);
            }
            return rootViewController;
        }

        #endregion Private Methods
#endif
    }
}

