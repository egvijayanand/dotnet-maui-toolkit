:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (call Error "Project Id is not provided." & set inputReqd=1)

if [%2]==[] (call Error "Build configuration is not provided." & set inputReqd=1)

if [%3]==[] (call Error "Version # not provided." & set inputReqd=1)

if %inputReqd% == 1 (pause & goto end)

set projId=%1

set config=%2

set packageVersion=%3

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." && goto end)

set /P packageName=<PackageName.txt

if [%packageName%]==[] (call Error "Package name not configured." && goto end)

echo.
:: Check whether the context is git repository or not
git rev-parse --is-inside-work-tree

:: Retrieve the hash of the latest commit
if %errorlevel% == 0 (for /F "tokens=*" %%g in ('git rev-parse --short HEAD') do (set revisionId=+sha.%%g)) else (set revisionId=)

:: Package Configuration

echo.
call Info "Delete existing package ..."

if exist .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg del .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg

echo.
call Info "Creating %packageName% ver. %packageVersion% (%projId%) NuGet package in %config% mode ..."

echo.
dotnet build .\VijayAnand.Toolkit.Markup\VijayAnand.Toolkit.Markup.%projId%.csproj -c %config% -p:PackageVersion=%packageVersion%%revisionId%

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Failed to %projId% create package.")

:end
