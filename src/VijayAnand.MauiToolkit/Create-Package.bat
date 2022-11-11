:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (echo Project Id is not provided. & set inputReqd=1)

if [%1]==[] (echo Build configuration is not provided. & set inputReqd=1)

if [%2]==[] (echo Version # not provided. & set inputReqd=1)

if %inputReqd% == 1 goto end

set projId=%1

set config=%2

set pkgVersion=%3

:: Package Name

if not exist CorePackageName.txt (echo Core package name file not available. & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (echo Core package name not configured. & goto end)

if not exist ToolkitPackageName.txt (echo Toolkit package name file not available. & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (echo Toolkit package name not configured. & goto end)

:: .NET SDK Version

dotnet --version

:: Package Configuration

echo Core Package: %corePkgName% ver. %pkgVersion%
echo Toolkit Package: %toolkitPkgName% ver. %pkgVersion%

echo Delete existing package ...

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

echo Creating NuGet package ...

dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

if not %errorlevel% == 0 (echo Core package creation failed. & goto end)

echo.

dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

echo.
if %errorlevel% == 0 (echo Process completed.) else (echo Toolkit package creation failed.)

:end
