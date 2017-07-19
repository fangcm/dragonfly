taskkill /f /im simple.notify.exe
taskkill /f /im questions.notify.exe
taskkill /f /im dragonfly.plugin.task.notify.exe

icacls.exe %APPDATA%\dragonfly\plugins\  /remove system
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r system:F  /T /L /C /Q

icacls.exe %APPDATA%\dragonfly\plugins\  /remove Administrators
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r Administrators:F  /T /L /C /Q

icacls.exe %APPDATA%\dragonfly\plugins\  /remove %USERNAME%
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r %USERNAME%:F  /T /L /C /Q

icacls.exe %APPDATA%\dragonfly\plugins\  /inheritance:e
