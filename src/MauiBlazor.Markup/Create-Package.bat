:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (call Error "Project Id is not provided." & set inputReqd=1)

if [%1]==[] (call Error "Build configuration is not provided." & set inputReqd=1)

if [%2]==[] (call Error "Version # is not provided." & set inputReqd=1)

if %inputReqd% == 1 goto end

set projId=%1

set config=%2

set pkgVersion=%3

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." & goto end)

set /P pkgName=<PackageName.txt

if [%pkgName%]==[] (call Error "Package name not configured." & goto end)

call Info "Delete existing package"

if exist .\MauiBlazor.Markup\bin\%config%\%pkgName%.%pkgVersion%.nupkg del .\MauiBlazor.Markup\bin\%config%\%pkgName%.%pkgVersion%.nupkg

call Info "Creating %pkgName% ver. %pkgVersion% NuGet package in %config% mode ..."

dotnet build .\MauiBlazor.Markup\MauiBlazor.Markup.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Failed to create package.")

:end
