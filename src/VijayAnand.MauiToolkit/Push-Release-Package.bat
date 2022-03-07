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

:: Package Version

if not exist PackageVersion.txt (call Error "Package version file not available." & goto end)

set /P pkgVersion=<PackageVersion.txt

if [%pkgVersion%]==[] (call Error "Package version # not configured." & goto end)

:: Existence Check

if not exist .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg call Error "Core NuGet package not avilable ..." & goto end

if not exist .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg call Error "Toolkit NuGet package not avilable ..." & goto end

:: Validate the Package

call Info "Validating %corePkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg

call Info "Validating %toolkitPkgName% ver. %pkgVersion% ..."

dotnet-validate package local .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg

:: Directory Check

if not exist "%nugetSource%\%corePkgName%\" mkdir "%nugetSource%\%corePkgName%"

if not exist "%nugetSource%\%toolkitPkgName%\" mkdir "%nugetSource%\%toolkitPkgName%"

:: Push the Package

call Info "Pushing %corePkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit.Core\bin\Release\%corePkgName%.%pkgVersion%.nupkg --source %nugetSource%\%corePkgName%

if not %errorlevel% == 0 (call Error "Core package push failed." & goto end)

echo.
call Info "Pushing %toolkitPkgName% ver. %pkgVersion% to My NuGet ..."

dotnet nuget push .\VijayAnand.MauiToolkit\bin\Release\%toolkitPkgName%.%pkgVersion%.nupkg --source %nugetSource%\%toolkitPkgName%

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Toolkit package push failed.")

:end
pause
