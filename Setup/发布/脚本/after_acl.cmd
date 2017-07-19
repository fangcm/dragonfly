icacls.exe %APPDATA%\dragonfly\plugins\  /inheritance:d 

icacls.exe %APPDATA%\dragonfly\plugins\  /remove:g system
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r system:RX  /T /L /C /Q

icacls.exe %APPDATA%\dragonfly\plugins\  /remove:g Administrators
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r Administrators:RX  /T /L /C /Q

icacls.exe %APPDATA%\dragonfly\plugins\  /remove:g %USERNAME%
icacls.exe %APPDATA%\dragonfly\plugins\  /grant:r %USERNAME%:RX  /T /L /C /Q

 
icacls.exe %ProgramFiles%\dragonfly\  /inheritance:d

icacls.exe %ProgramFiles%\dragonfly\  /remove:g system
icacls.exe %ProgramFiles%\dragonfly\  /grant:r system:RX  /T /L /C /Q

icacls.exe %ProgramFiles%\dragonfly\  /remove:g Administrators
icacls.exe %ProgramFiles%\dragonfly\  /grant:r Administrators:RX  /T /L /C /Q

icacls.exe %ProgramFiles%\dragonfly\  /remove:g %id%
icacls.exe %ProgramFiles%\dragonfly\  /grant:r %id%:RX  /T /L /C /Q


