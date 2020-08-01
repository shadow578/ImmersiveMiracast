::
:: ImmersiveCast Configuration removal 
::
:: ImmersiveCast stores its config file in %LOCALAPPDATA%\ImmersiveCast\ImmersiveCast\config.xml
:: This script removes the whole config directory and thus resets the app to its original configuration on next launch.
:: To fully uninstall ImmersiveCast, do the following:
:: - Remove Registry Key HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run\ImmersiveCast (or run ImmersiveCast with autostart off)
:: - Remove config file (using this script)
:: - Remove Program files

@echo off
rmdir "%LOCALAPPDATA%\ImmersiveMiracast\" /s /q