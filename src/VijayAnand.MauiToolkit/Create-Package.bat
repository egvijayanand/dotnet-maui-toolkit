:: Creates a new NuGet package from the project file
@echo off

if [%1]==[] (echo Build configuration input is not provided. & goto end)

set config=%1

if not [%2]==[] (set pkgVersion=%2)

:: Package Name

if not exist CorePackageName.txt (echo Core package name file not available. & goto end)

set /P corePkgName=<CorePackageName.txt

if [%corePkgName%]==[] (echo Core package name not configured. & goto end)

if not exist ToolkitPackageName.txt (echo Toolkit package name file not available. & goto end)

set /P toolkitPkgName=<ToolkitPackageName.txt

if [%toolkitPkgName%]==[] (echo Toolkit package name not configured. & goto end)

:: Package Version

if not exist PackageVersion.txt (echo Version file not available. & goto end)

:: If value of pkgVersion is still blank, attempt to read from the PackageVersion file
if [%pkgVersion%]==[] (set /P pkgVersion=<PackageVersion.txt)

if [%pkgVersion%]==[] (echo Version # not configured. & goto end)

:: .NET SDK Version

dotnet --version

:: Package Configuration

echo Core Package: %corePkgName% ver. %pkgVersion%
echo Toolkit Package: %toolkitPkgName% ver. %pkgVersion%

echo Delete existing package ...

if exist .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit.Core\bin\%config%\%corePkgName%.%pkgVersion%.nupkg

if exist .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg del .\VijayAnand.MauiToolkit\bin\%config%\%toolkitPkgName%.%pkgVersion%.nupkg

echo Creating NuGet package ...

dotnet build .\VijayAnand.MauiToolkit.Core\VijayAnand.MauiToolkit.Core.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

if not %errorlevel% == 0 (echo Core package creation failed. & goto end)

echo.
:: Adding NuGet reference
::dotnet add .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.csproj package %corePkgName% --version %pkgVersion%

dotnet build .\VijayAnand.MauiToolkit\VijayAnand.MauiToolkit.csproj -c %config% -p:PackageVersion=%pkgVersion% -p:ContinuousIntegrationBuild=true

echo.
if %errorlevel% == 0 (echo Process completed.) else (echo Toolkit package creation failed.)

:end
