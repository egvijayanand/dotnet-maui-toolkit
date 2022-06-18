:: Creates a new NuGet package from the project file
@echo off

if [%1]==[] (call Error "Build configuration input is not provided." & goto end)

set config=%1

:: Package Name

if not exist CorePackageName.txt (call Error "Core package name file not available." & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (call Error "Core package name not configured." & goto end)

if not exist ToolkitPackageName.txt (call Error "Toolkit package name file not available." & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (call Error "Toolkit package name not configured." & goto end)

:: Package Version

if not exist PackageVersion.txt (call Error "Version file not available." & goto end)

set /P pkgVersion=<PackageVersion.txt

if [%pkgVersion%]==[] (call Error "Version # not configured." & goto end)

:: .NET SDK Version

dotnet --version

:: Package Configuration

call Info "Core Package: %corePkgName% ver. %pkgVersion%"
call Info "Toolkit Package: %toolkitPkgName% ver. %pkgVersion%"

call Info "Delete existing package ..."

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Creating NuGet package ..."

dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

if not %errorlevel% == 0 (call Error "Core package creation failed." & goto end)

echo.
:: Adding NuGet reference
::dotnet add .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.csproj package %corePkgName% --version %pkgVersion%

dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Toolkit package creation failed.")

:end
