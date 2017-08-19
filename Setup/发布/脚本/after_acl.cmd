icacls.exe "%APPDATA%\dragonfly\plugins\*" /setowner %USERNAME% /T /L /C /Q
icacls.exe "%APPDATA%\dragonfly\plugins\*" /inheritance:r /grant:r system:(WDAC,RX) Administrators:(WDAC,RX) %USERNAME%:(WDAC,RX) /T /L /C /Q

icacls.exe "%ProgramFiles%\dragonfly\*" /setowner %USERNAME% /T /L /C /Q
icacls.exe "%ProgramFiles%\dragonfly\*" /inheritance:r /grant:r system:(WDAC,RX) Administrators:(WDAC,RX) %USERNAME%:(WDAC,RX) /T /L /C /Q

