:: Installs the NuGet package
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

set projId=
set version=

title Publishing the NuGet packages to MyGet ...

set dirName=VijayAnand.Toolkit.Markup

if defined MyGetSource (set "nugetSource=%MyGetSource%") else (call Error "MyGet folder source path is not defined." & goto end)

if defined MyGetServer (set "nugetServer=%MyGetServer%") else (call Error "MyGet hosted source path is not defined." & goto end)

:: Package Name

if not exist PackageName.txt call Error "Package name file not available." & goto end

set /P packageName=<PackageName.txt

if [%packageName%]==[] call Error "Package name not configured." & goto end

:: Directory Check

if not exist "%nugetSource%\%packageName%\" mkdir "%nugetSource%\%packageName%"

if [%arg%] == [0] (goto dotnet8) else (if [%arg%] == [1] (goto dotnet8) else (if [%arg%] == [2] (goto dotnet9) else (if [%arg%] == [3] (goto dotnet10) else (call Error "Invalid input." && goto end))))

:: .NET 8 Package Version

:dotnet8

call :process 8

if [%arg%] == [0] (echo.) else (goto end)

:: .NET 9 Package Version

:dotnet9

call :process 9

if [%arg%] == [0] (echo.) else (goto end)

:: .NET 10 Package Version

:dotnet10

call :process 10

:end

if [%1] == [] pause

goto :eof

:process

set projId=Net%1
set version=%1

if not exist PackageVersion-%projId%.txt call Error ".NET %version% package version file not available." & goto end

set /P packageVersion=<PackageVersion-%projId%.txt

if [%packageVersion%]==[] call Error ".NET %version% package version # not configured." & goto end

:: Existence Check

if not exist .\%dirName%\bin\Release\%packageName%.%packageVersion%.nupkg call Error ".NET %version% NuGet package not avilable." & goto end

:: Validate the Package

echo.
call Info "Validating .NET %version% %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet-validate package local .\%dirName%\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

call Info "Pushing .NET %version% %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet nuget push .\%dirName%\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error ".NET %version% package folder push failed." & goto end)

echo.
nuget add .\%dirName%\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET %version% package hosted push failed." & goto end)

exit /b
