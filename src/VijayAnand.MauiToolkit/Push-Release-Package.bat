:: Installs the NuGet package
@echo off

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto process

echo Pass 0 to build for .NET 8, .NET 9, and .NET 10
echo Pass 1 to process only for .NET 8
echo Pass 2 to process only for .NET 9
echo Pass 3 to process only for .NET 10

goto end

:process

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

if not exist PackageVersion-Net8.txt (call Error ".NET 8 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net8.txt

if [%pkgVersion%]==[] (call Error ".NET 8 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 8 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 8 Toolkit NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 8 Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 8 %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 8 %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 8 %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 8 %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 8 Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 8 Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 8 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET 8 Toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 8 Toolkit package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 8 %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET 8 Pro toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 8 Pro toolkit package hosted push failed." & goto end)

if [%arg%] == [0] (echo.) else (if [%arg%] == [1] goto end)

:: .NET 9 Package Version

:dotnet9

if not exist PackageVersion-Net9.txt (call Error ".NET 9 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net9.txt

if [%pkgVersion%]==[] (call Error ".NET 9 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 9 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 9 Toolkit NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 9 Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 9 %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 9 %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 9 %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 9 %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 9 Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 9 Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 9 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 9 Toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if not %errorlevel% == 0 (call Error ".NET 9 Toolkit package hosted push failed.")

call Info "Pushing .NET 9 %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 9 Pro toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 9 Pro toolkit package hosted push failed.")

if [%arg%] == [0] (echo.) else (if [%arg%] == [2] goto end)

:: .NET 10 Package Version

:dotnet10

if not exist PackageVersion-Net10.txt (call Error ".NET 10 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net10.txt

if [%pkgVersion%]==[] (call Error ".NET 10 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 10 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 10 Toolkit NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 10 Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 10 %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 10 %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 10 %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 10 %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 10 Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 10 Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 10 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 10 Toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if not %errorlevel% == 0 (call Error ".NET 10 Toolkit package hosted push failed.")

call Info "Pushing .NET 10 %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 10 Pro toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 10 Pro toolkit package hosted push failed.")

:end
if [%1] == [] pause
