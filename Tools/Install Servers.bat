SET mypath=%~dp0
"%mypath:~0,-1%\bin\srm.exe" install "%mypath:~0,-1%/../build/PowerExtension.dll" -codebase
pause
