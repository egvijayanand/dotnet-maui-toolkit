:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (call Error "Project Id is not provided." & set inputReqd=1)

if [%2]==[] (call Error "Build configuration is not provided." & set inputReqd=1)

if [%3]==[] (call Error "Version # not provided." & set inputReqd=1)

if %inputReqd% == 1 (pause & goto end)

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

if not exist ProToolkitPackageName.txt (call Error "Pro toolkit package name file not available." & goto end)

set /P proToolkitPkgName=<ProToolkitPackageName.txt

if [%proToolkitPkgName%]==[] (call Error "Pro toolkit package name not configured." & goto end)

echo.
:: Check whether the context is git repository or not
git rev-parse --is-inside-work-tree

:: Retrieve the hash of the latest commit
if %errorlevel% == 0 (for /F "tokens=*" %%g in ('git rev-parse --short HEAD') do (set revisionId=+sha.%%g)) else (set revisionId=)

echo.
call Info ".NET SDK Version"

dotnet --version

:: Package Configuration

echo.
call Info "Core Package: %corePkgName% ver. %pkgVersion%"
call Info "Toolkit Package: %toolkitPkgName% ver. %pkgVersion%"
call Info "Pro toolkit Package: %proToolkitPkgName% ver. %pkgVersion%"

echo.
call Info "Delete existing package ..."

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit.Pro\bin\%config%\%proToolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%proToolkitPkgName%.%pkgVersion%.nupkg

echo.
call Info "Creating NuGet package ..."

echo.
call Info "Building Core package ..."

echo.
dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId%

if not %errorlevel% == 0 (call Error "Core package creation failed." & goto end)

echo.
call Info "Building Toolkit package ..."

echo.
dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId% -p:PublishReadyToRun=false

echo.
if not %errorlevel% == 0 (call Error "Toolkit package creation failed.")

echo.
call Info "Building Pro package ..."

echo.
dotnet build .\VijayAnand.MauiToolkit.Pro\VijayAnand.MauiToolkit.Pro.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId% -p:PublishReadyToRun=false

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Pro toolkit package creation failed.")

:end
