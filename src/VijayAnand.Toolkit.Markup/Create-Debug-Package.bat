:: Creates a new NuGet package from the project file in Debug configuration
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

set config=Debug

title Building the toolkit in %config% config ...

if [%arg%] == [0] (goto dotnet8) else (if [%arg%] == [1] (goto dotnet8) else (if [%arg%] == [2] (goto dotnet9) else (if [%arg%] == [3] (goto dotnet10) else (call Error "Invalid input." && goto end))))

:dotnet8

call :process 8

if [%arg%] == [0] (echo.) else (goto end)

:dotnet9

call :process 9

if [%arg%] == [0] (echo.) else (goto end)

:dotnet10

call :process 10

:end

if [%1] == [] pause

goto :eof

:process

set fileId=net%1
set projId=Net%1
set version=%1

if not exist PackageVersion-%projId%.txt (call Error ".NET %version% version file not available." & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET %version% version # not configured." & goto end)

call Info ".NET SDK Version"

ren global.json.%fileId%.bak global.json

dotnet --version

call Create-Package.bat %projId% %config% %pkgVersion%

ren global.json global.json.%fileId%.bak

exit /b
