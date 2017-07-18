c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /inheritance:d 

c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /remove:g system
c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /grant:r system:RX  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /remove:g Administrators
c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /grant:r Administrators:RX  /T /L /C /Q

c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /remove:g hezy
c:\windows\system32\icacls.exe C:\Users\HEZY\AppData\Roaming\dragonfly\plugins\  /grant:r hezy:RX  /T /L /C /Q

