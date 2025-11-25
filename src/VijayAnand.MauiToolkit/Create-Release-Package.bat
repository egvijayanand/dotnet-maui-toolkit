:: Creates a new NuGet package from the project file in Release configuration
@echo off

setlocal EnableDelayedExpansion

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto start

echo Pass 0 to build for .NET 8, .NET 9, and .NET 10
echo Pass 1 to process only for .NET 8
echo Pass 2 to process only for .NET 9
echo Pass 3 to process only for .NET 10

goto end

:start

set config=Release

title Building the toolkit in %config% config ...

if [%arg%] == [0] (goto dotnet8) else (if [%arg%] == [1] (goto dotnet8) else (if [%arg%] == [2] (goto dotnet9) else (if [%arg%] == [3] (goto dotnet10) else (call Error "Invalid input." && goto end))))

:: .NET 8 package version

:dotnet8

call :process 8

if [%arg%] == [0] (echo.) else (goto end)

:: .NET 9 package version

:dotnet9

call :process 9

if [%arg%] == [0] (echo.) else (goto end)

:: .NET 10 package version

:dotnet10

call :process 10

:end

if [%1] == [] pause

goto :eof

:process

set fileVer=net%1
set projId=Net%1
set version=%1

if exist .\global.json.%fileVer%.bak ren global.json.%fileVer%.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET %version% version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET %version% version # not configured. & goto end)

call Create-Package-New.bat %version% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.%fileVer%.bak

exit /b
