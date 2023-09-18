:: Creates a new NuGet package from the project file in Release configuration
@echo off

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto process

echo Pass 0 to build for .NET 6, .NET 7, and .NET 8
echo Pass 1 to process only for .NET 6
echo Pass 2 to process only for .NET 7
echo Pass 3 to process only for .NET 8

goto end

:process

set projId=

set config=Release

title Building the toolkit in %config% config ...

if [%arg%] == [0] (goto dotnet6) else (if [%arg%] == [1] (goto dotnet6) else (if [%arg%] == [2] (goto dotnet7) else (if [%arg%] == [3] (goto dotnet8) else (call Error "Invalid input." && goto end))))

:: .NET 6 package version

:dotnet6

set projId=Net6

if exist .\global.json.net6.bak ren global.json.net6.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET 6 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET 6 version # not configured. & goto end)

call Create-Package-New.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net6.bak

if [%arg%] == [0] (echo.) else (if [%arg%] == [1] goto end)

:: .NET 7 package version

:dotnet7

set projId=Net7

if exist .\global.json.net7.bak ren global.json.net7.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET 7 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET 7 version # not configured. & goto end)

call Create-Package-New.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net7.bak

if [%arg%] == [0] (echo.) else (if [%arg%] == [2] goto end)

:: .NET 8 package version

:dotnet8

set projId=Net8

if exist .\global.json.net8.bak ren global.json.net8.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET 8 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET 8 version # not configured. & goto end)

call Create-Package-New.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net8.bak

:end
if [%1] == [] pause
