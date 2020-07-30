# Immersive Miracast
Easy immersive Casting for Windows 10.

## Usage
1. Start the exe
2. Right click the tray icon to access more options
3. Connect to the Miracast receiver
4. ?
5. Profit

## Why? Windows has such a app built- in
But Windows app is shitty UWP, and as such can't (and probably will never) support running in the background.<br/>
This app however can do so, and as such is better suited for non- interactive situations (like info displays or whatever).

## Requirements
This app uses XAML Islands (because I was too _lazy_ to create a whole Miracast receiver by myself...).
Because of this, the following requirements exist:
* You'll need Windows 10 1903 or higher
* You'll need to install [VS C++ Runtime 2019](https://support.microsoft.com/de-de/help/2977003/the-latest-supported-visual-c-downloads)
	* Not really sure, but I think you need to. Please let me know if this is not required.
* Idk, probably some other stuff too :P