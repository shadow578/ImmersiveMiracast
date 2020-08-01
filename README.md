# Immersive Miracast
Easy immersive Casting for Windows 10.

## Usage
1. Start ImmersiveMiracast.exe
2. Right click tray icon to access more options
3. Connect to ImmersiveCast using WIN+K
4. ???
5. Profit

## Requirements
This app is written in __.Net Core 3.1__, so you'll need the correct runtime for this. But don't worry, you can download it [here](https://dotnet.microsoft.com/download/dotnet-core/current/runtime).</br>
Also, this app is 64 bit __only__. If you're still running 32 bit, you're out of luck.</br>
Additionally, this app uses XAML Islands (because creating a whole Miracast receiver from scratch would be fun - __not__). Because of this, you'll need Windows 10 1903 or higher. 
Also, you may need to install  [VS C++ Runtime 2019](https://support.microsoft.com/de-de/help/2977003/the-latest-supported-visual-c-downloads).<br/>
On the Hardware side of things, any Computer that is able to run __Windows 10 1903 x64__ should do. Also, you'll need a WiFi card or dongle (again, pretty much any dongle should do - I'm using a 2$ one)<br/>

TL;DR: You need
* [A 64 bit Computer](https://www.amazon.com/s?k=Computer+Windows+10+64+Bit)
* A WiFi card
* [Windows 10 1903 or higher](https://www.microsoft.com/de-de/software-download/windows10)
* [.Net Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/current/runtime)
* [Visual C++ Runtime 2019?](https://support.microsoft.com/help/2977003/the-latest-supported-visual-c-downloads)

## Why? Windows has such an app built in!
_bUt wINdOWs aLdreADy hAs ThIS fEatUrE_<br/>
<img src="/Assets/readme/shut-up-windows-connect-is-shit.jpg?raw=true" width="350">
<br/>
Yes, but Windows' builtin app is a shitty UWP app, so it can't (and will never) support running basic things as running in the background.<br/>
However, this app can do just that - and thus is better suited for non- interactive situations (like info displays).<br/>
Also, the Connect app's settings are literally a blank page ;)

## Troubleshooting
* If you get Unknown Error dialog, try to restart your computer (I know, but this really helps)
* When getting Miracast not supported dialog, check you have a wifi adapter. Also, check if Windows' Connect app works
* When a connection attempt times out, restarting explorer on the transmitting machine may be required - because Windows is really stable ;)
* Try resetting your configuration (using the script or configuration screen) 
* Currently, only receiving from Windows 10 is tested