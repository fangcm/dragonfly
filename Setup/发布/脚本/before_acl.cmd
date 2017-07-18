set id=%USERNAME% 
taskkill /f /im simple.notify.exe
taskkill /f /im questions.notify.exe
taskkill /f /im dragonfly.plugin.task.notify.exe

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove system
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r system:F  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove Administrators
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r Administrators:F  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove %id% 
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r %id%:F  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /inheritance:e
