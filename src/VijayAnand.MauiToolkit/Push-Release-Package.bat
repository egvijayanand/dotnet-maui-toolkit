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

title Publishing the NuGet packages to MyGet ...

if defined MyGetSource (set "nugetSource=%MyGetSource%") else (call Error "MyGet folder source path is not defined." & goto end)

if defined MyGetServer (set "nugetServer=%MyGetServer%") else (call Error "MyGet hosted source path is not defined." & goto end)

:: Package Name

if not exist CorePackageName.txt (call Error "Core package name file not available." & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (call Error "Core package name not configured." & goto end)

if not exist ToolkitPackageName.txt (call Error "Toolkit package name file not available." & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (call Error "Toolkit package name not configured." & goto end)

if not exist ProToolkitPackageName.txt (call Error "Pro toolkit package name file not available." & goto end)

set /P proToolkitPkgName=<ProToolkitPackageName.txt

if [%proToolkitPkgName%]==[] (call Error "Pro toolkit package name not configured." & goto end)

:: Directory Check

if not exist "%nugetSource%\%corePkgName%\" mkdir "%nugetSource%\%corePkgName%"

if not exist "%nugetSource%\%toolkitPkgName%\" mkdir "%nugetSource%\%toolkitPkgName%"

if not exist "%nugetSource%\%proToolkitPkgName%\" mkdir "%nugetSource%\%proToolkitPkgName%"

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

if not exist PackageVersion-%projId%.txt (call Error ".NET %version% package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET %version% package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET %version% Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET %version% Toolkit NuGet package not avilable ..." & goto end

if [%version%] == [10] (goto validate)

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET %version% Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

:validate

call Info "Validating .NET %version% %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET %version% %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

if [%version%] == [10] (goto push)

call Info "Validating .NET %version% %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

:push

call Info "Pushing .NET %version% %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET %version% Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET %version% Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET %version% %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET %version% Toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET %version% Toolkit package hosted push failed." & goto end)

if [%version%] == [10] (goto confirm)

echo.
call Info "Pushing .NET %version% %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET %version% Pro toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET %version% Pro toolkit package hosted push failed." & goto end)

:confirm

echo.
if %errorlevel% == 0 (call Success "Process completed.")

exit /b
