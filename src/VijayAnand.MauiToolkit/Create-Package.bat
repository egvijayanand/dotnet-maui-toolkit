:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (echo Version is not provided. & set inputReqd=1)

if [%2]==[] (echo Build configuration is not provided. & set inputReqd=1)

if [%3]==[] (echo Version # not provided. & set inputReqd=1)

if [%inputReqd%] == [1] (pause & goto end)

set version=%1

set projId=Net%1

set config=%2

set pkgVersion=%3

:: Package Name

if not exist CorePackageName.txt (echo Core package name file not available. & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (echo Core package name not configured. & goto end)

if not exist ToolkitPackageName.txt (echo Toolkit package name file not available. & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (echo Toolkit package name not configured. & goto end)

if not exist ProToolkitPackageName.txt (echo Pro toolkit package name file not available. & goto end)

set /P proToolkitPkgName=<ProToolkitPackageName.txt

if [%proToolkitPkgName%]==[] (echo Pro toolkit package name not configured. & goto end)

echo.
:: Check whether the context is git repository or not
git rev-parse --is-inside-work-tree

:: Retrieve the hash of the latest commit
if %errorlevel% == 0 (for /F "tokens=*" %%g in ('git rev-parse --short HEAD') do (set revisionId=+sha.%%g)) else (set revisionId=)

echo.
echo .NET SDK Version

dotnet --version

:: Package Configuration

echo.
echo Core Package: %corePkgName% ver. %pkgVersion%
echo Toolkit Package: %toolkitPkgName% ver. %pkgVersion%
echo Pro toolkit Package: %proToolkitPkgName% ver. %pkgVersion%

echo.
echo Delete existing package ...

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit.Pro\bin\%config%\%proToolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%proToolkitPkgName%.%pkgVersion%.nupkg

echo.
echo Creating NuGet package ...

echo.
dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId%

if not %errorlevel% == 0 (echo Core package creation failed. & goto end)

echo.
dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId% -p:PublishReadyToRun=false

echo.
if not %errorlevel% == 0 (echo Toolkit package creation failed.)

if [%version%] == [10] (goto confirm)

echo.
dotnet build .\VijayAnand.MauiToolkit.Pro\VijayAnand.MauiToolkit.Pro.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId% -p:PublishReadyToRun=false

echo.
if not %errorlevel% == 0 (echo Pro toolkit package creation failed.)

:confirm

echo.
if %errorlevel% == 0 (echo Process completed.)

:end
