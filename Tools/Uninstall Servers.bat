SET mypath=%~dp0
"%mypath:~0,-1%\bin\srm.exe" uninstall "%mypath:~0,-1%/../build/PowerExtension.dll" -codebase
"%mypath:~0,-1%\bin\srm.exe" uninstall "%mypath:~0,-1%/../build/PowerExtension.dll"
pause
