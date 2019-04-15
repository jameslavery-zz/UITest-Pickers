# UITest-Pickers

## Overview

Driving iOS Pickers from UITest tests is painful - usually we end up coding gestures and scroll commands. All nasty and error-prone.

To get round this, I've created a set of Backdoor methods which can be called from UITest tests to directly select Picker values.

Supported Pickers are:

* Ordinary Pickers with a list of items
* Date Pickers.

## Usage

1. Add [UIBackDoorMethods.cs](UIBackDoorMethods.cs) to your iOS project.
1. Amend [AppDelegate.cs](AppDelegate.cs) to add the actual backdoor methods which will be Invoked.
1. Invoke the backdoor methods from your UITests.
