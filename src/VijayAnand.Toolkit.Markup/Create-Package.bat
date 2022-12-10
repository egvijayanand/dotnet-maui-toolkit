:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (echo Project Id is not provided. & set inputReqd=1)

if [%2]==[] (echo Build configuration is not provided. & set inputReqd=1)

if [%3]==[] (echo Version # not provided. & set inputReqd=1)

if %inputReqd% == 1 goto end

set projId=%1

set config=%2

set packageVersion=%3

:: Package Name

if not exist PackageName.txt (echo Package name file not available. && goto end)

set /P packageName=<PackageName.txt

if [%packageName%]==[] (echo Package name not configured. && goto end)

:: Package Configuration

echo.
echo Creating %packageName% ver. %packageVersion% (%projId%) NuGet package in %config% mode ...

echo.
echo Delete existing package ...

if exist .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg del .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg

echo.
echo Creating NuGet package ...

dotnet build .\VijayAnand.Toolkit.Markup\VijayAnand.Toolkit.Markup.%projId%.csproj -c %config% -p:PackageVersion=%packageVersion%

echo.
if %errorlevel% == 0 (echo Process completed.) else (echo Failed to %projId% create package.)

:end
