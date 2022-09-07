# OnlineSampleTest
A sample Xamarin.Android based application exhibiting MVVM pattern.
The samples in this repository demonstrate how to use CarouselView Layout of Xamarin.Forms to build cross-platform apps for iOS, Android,
and the Universal Windows Platform (UWP).

The sample we provide is a solution using four projects: one for Android, one for iOS, one for the native libraries and a shared one.

The shared one contains most of the UI stuff. It has an application and a default view that allow the user to register his SIP account to a proxy and make/receive calls.
It also includes the C# wrapper from the SDK.

The Android project contains the Android Manifest for the generated APK and an Activity that will load and display the application from the shared project.

The iOS project does the same thing that the Android one, but for iOS (obviously).

Finally, the Liblinphone project contains the native libraries built by linphone-sdk.
