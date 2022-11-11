:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (call Error "Project Id is not provided." & set inputReqd=1)

if [%2]==[] (call Error "Build configuration is not provided." & set inputReqd=1)

if [%3]==[] (call Error "Version # not provided." & set inputReqd=1)

if %inputReqd% == 1 goto end

set projId=%1

set config=%2

set pkgVersion=%3

:: Package Name

if not exist CorePackageName.txt (call Error "Core package name file not available." & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (call Error "Core package name not configured." & goto end)

if not exist ToolkitPackageName.txt (call Error "Toolkit package name file not available." & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (call Error "Toolkit package name not configured." & goto end)

:: .NET SDK Version

dotnet --version

:: Package Configuration

call Info "Core Package: %corePkgName% ver. %pkgVersion%"
call Info "Toolkit Package: %toolkitPkgName% ver. %pkgVersion%"

call Info "Delete existing package ..."

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

call Info "Creating NuGet package ..."

dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

if not %errorlevel% == 0 (call Error "Core package creation failed." & goto end)

echo.

dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Toolkit package creation failed.")

:end
