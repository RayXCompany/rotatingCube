@echo off
xcopy /s /y "C:\Users\novarayX\Documents\MyScreensaver" "%APPDATA%\MyScreensaver"
copy /b "%APPDATA%\MyScreensaver\*" "%APPDATA%\MyScreensaver\YourScreensaver.scr" > nul
exit