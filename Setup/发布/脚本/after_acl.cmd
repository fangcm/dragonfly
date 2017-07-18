set id=%USERNAME%
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /inheritance:d

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove:g system
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r system:RX  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove:g Administrators
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r Administrators:RX  /T /L /C /Q
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /remove:g %id%
c:\windows\system32\icacls.exe C:\Users\%id%\AppData\Roaming\dragonfly\plugins\  /grant:r %id%:RX  /T /L /C /Q

c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /inheritance:d

c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /remove:g system
c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /grant:r system:RX  /T /L /C /Q

c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /remove:g Administrators
c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /grant:r Administrators:RX  /T /L /C /Q

c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /remove:g %id%
c:\windows\system32\icacls.exe "C:\Program Files\dragonfly\"  /grant:r %id%:RX  /T /L /C /Q


