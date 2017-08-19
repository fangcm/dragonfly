taskkill /f /im simple.notify.exe
taskkill /f /im questions.notify.exe
taskkill /f /im dragonfly.plugin.task.notify.exe

icacls.exe "%APPDATA%\dragonfly\plugins\*" /grant:r system:(WDAC,F) Administrators:(WDAC,F) %USERNAME%:(WDAC,F) /T /L /C /Q
