:: Creates a new NuGet package from the project file
@echo off

set inputReqd=0

if [%1]==[] (call Error "Project Id is not provided." & set inputReqd=1)

if [%1]==[] (call Error "Build configuration is not provided." & set inputReqd=1)

if [%2]==[] (call Error "Version # is not provided." & set inputReqd=1)

if [%inputReqd%] == [1] (pause & goto end)

set projId=%1

set config=%2

set pkgVersion=%3

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." & goto end)

set /P pkgName=<PackageName.txt

if [%pkgName%]==[] (call Error "Package name not configured." & goto end)

:: Check whether the context is git repository or not
git rev-parse --is-inside-work-tree

:: Retrieve the hash of the latest commit
if %errorlevel% == 0 (for /F "tokens=*" %%g in ('git rev-parse --short HEAD') do (set revisionId=+sha.%%g)) else (set revisionId=)

echo.
call Info ".NET SDK Version"

dotnet --version

if not exist .\MauiBlazor.Markup\bin\%config%\%pkgName%.%pkgVersion%.nupkg goto build

echo.
call Info "Delete existing package ..."

del .\MauiBlazor.Markup\bin\%config%\%pkgName%.%pkgVersion%.nupkg

:build

echo.
call Info "Creating %pkgName% ver. %pkgVersion% NuGet package in %config% mode ..."

echo.
dotnet build .\MauiBlazor.Markup\MauiBlazor.Markup.%projId%.csproj -c %config% -p:PackageVersion=%pkgVersion%%revisionId%

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Failed to create package.")

:end
