:: Creates a new NuGet package from the project file
@echo off

if [%1]==[] (call Error "Build configuration input is not provided." & pause & goto end)

set config=%1

:: Package Name

if not exist PackageName.txt (call Error "Package name file not available." && goto end)

set /P packageName=<PackageName.txt

if [%packageName%]==[] (call Error "Package name not configured." && goto end)

:: Package Version

if not exist PackageVersion.txt (call Error "Version file not available" && goto end)

set /P packageVersion=<PackageVersion.txt

if [%packageVersion%]==[] (call Error "Version # not configured" && goto end)

call Info "Creating %packageName% ver. %packageVersion% NuGet package in %config% mode ..."

call Info "Delete existing package ..."

if exist .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg del .\VijayAnand.Toolkit.Markup\bin\%config%\%packageName%.%packageVersion%.nupkg

call Info "Creating NuGet package ..."

dotnet build .\VijayAnand.Toolkit.Markup\VijayAnand.Toolkit.Markup.csproj -c %config% -p:PackageVersion=%packageVersion%

if %errorlevel% == 0 (call Success "Process completed.") else (call Error "Failed to create package.")

:end
