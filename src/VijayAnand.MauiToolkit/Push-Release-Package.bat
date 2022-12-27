:: Installs the NuGet package
@echo off

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

:: .NET 6 Package Version

if not exist PackageVersion-Net6.txt (call Error ".NET 6 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net6.txt

if [%pkgVersion%]==[] (call Error ".NET 6 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 6 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 6 Toolkit NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 6 Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 6 %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 6 %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 6 %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 6 %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 6 Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 6 Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 6 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET 6 Toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 6 Toolkit package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 6 %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET 6 Pro toolkit package folder push failed." & goto end)

nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 6 Pro toolkit package hosted push failed." & goto end)

:: .NET 7 Package Version

if not exist PackageVersion-Net7.txt (call Error ".NET 7 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net7.txt

if [%pkgVersion%]==[] (call Error ".NET 7 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 7 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 7 Toolkit NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 7 Pro toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

echo.
call Info "Validating .NET 7 %corePkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 7 %toolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 7 %proToolkitPkgName% ver. %pkgVersion% ..."

echo.
dotnet-validate package local .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 7 %corePkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 7 Core package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 7 Core package hosted push failed." & goto end)

echo.
call Info "Pushing .NET 7 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 7 Toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if not %errorlevel% == 0 (call Error ".NET 7 Toolkit package hosted push failed.")

call Info "Pushing .NET 7 %proToolkitPkgName% ver. %pkgVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%proToolkitPkgName%

if not %errorlevel% == 0 (call Error ".NET 7 Pro toolkit package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.MauiToolkit.Pro\bin\Release\%proToolkitPkgName%.%pkgVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 7 Pro toolkit package hosted push failed.")

:end
pause
