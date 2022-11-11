:: Installs the NuGet package
@echo off

if defined MyGetSource (set "nugetSource=%MyGetSource%") else (set nugetSource=E:\Tasks\Projects\Templates\Release\NuGet\Packages)

:: Package Name

if not exist CorePackageName.txt (call Error "Core package name file not available." & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (call Error "Core package name not configured." & goto end)

if not exist ToolkitPackageName.txt (call Error "Maui package name file not available." & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (call Error "Maui package name not configured." & goto end)

:: Directory Check

if not exist "%nugetSource%\%corePkgName%\" mkdir "%nugetSource%\%corePkgName%"

if not exist "%nugetSource%\%toolkitPkgName%\" mkdir "%nugetSource%\%toolkitPkgName%"

:: .NET 6 Package Version

if not exist PackageVersion-Net6.txt (call Error ".NET 6 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net6.txt

if [%pkgVersion%]==[] (call Error ".NET 6 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 6 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 6 Toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 6 %corePkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 6 %toolkitPkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 6 %corePkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 6 Core package push failed." & goto end)

echo.
call Info "Pushing .NET 6 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if not %errorlevel% == 0 (call Error ".NET 6 Toolkit package push failed." & goto end)

:: .NET 7 Package Version

if not exist PackageVersion-Net7.txt (call Error ".NET 7 package version file not available." & goto end)

set /P pkgVersion=<PackageVersion-Net7.txt

if [%pkgVersion%]==[] (call Error ".NET 7 package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error ".NET 7 Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error ".NET 7 Toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating .NET 7 %corePkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating .NET 7 %toolkitPkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 7 %corePkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error ".NET 7 Core package push failed." & goto end)

echo.
call Info "Pushing .NET 7 %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 7 Toolkit package push failed.")

:end
pause
