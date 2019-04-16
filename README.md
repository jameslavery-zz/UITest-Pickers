# UITest-Pickers

# Overview

Driving iOS Pickers from UITest tests is painful - usually we end up coding gestures and scroll commands. All nasty and error-prone.

To get round this, I've created a set of Backdoor methods which can be called from UITest tests to directly select Picker values.

Supported Pickers are:

* Ordinary Pickers with a list of items
* Date Pickers.

_**Note**_ that these backdoors and supporting classes are only for iOS.

# Usage

1. Add [UITestBackdoorMethods.cs](UITestPickerBackdoors/UITestPickerBackdoors.iOS/UITestBackdoorMethods.cs) to your iOS project.
1. Amend [AppDelegate.cs](UITestPickerBackdoors/UITestPickerBackdoors.iOS/AppDelegate.cs) to add the actual backdoor methods which will be Invoked.
1. Invoke the backdoor methods from your UITests.

# Ancillary Architecture

The repo has other artefacts which are not directly concerned with the backdoors themselves, but make UITest management and debugging easier.

## MVVM Framework

The test app makes use of [FreshMvvm](https://github.com/rid00z/FreshMvvm) for its MVVM implementation. 

## UITestPickerBackdoors.UITests Project

This implements the Page Object Pattern and other concepts presented in this Xamarin Blog - [Best Practices and Tips for Using Xamarin.UITest](https://devblogs.microsoft.com/xamarin/best-practices-tips-xamarin-uitest/)

In addition, I use a wrapper [UIElement](UITestPickerBackdoors/UITestPickerBackdoors.UITests/UIElement.cs) class, which allows us to access either the underlying UI View or the AutomationId for the View. I've found this useful because we need to know the AutomationId and View for a visual element - for example, scrolling takes an AutomationId in some cases and the Element in others.

## Allowing Debugging Of Backdoors

Out of the box, it's not easy to debug a Backdoor, because when you're running the UITest, you can only debug the UITest project itself - the Backdoor is being Invoked.

To get round this, I've created an _IBackdoorRunner_ interface, which is implemented in the iOS project. This allows us run the app and run the underlying Backdoor code from the app itself.

Obviously, this Interface and its implementation are not needed in a project which makes use of the Backdoors - but is useful when developing and debugging them.
