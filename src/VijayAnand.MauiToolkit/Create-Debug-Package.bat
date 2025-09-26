:: Creates a new NuGet package from the project file in Debug configuration
@echo off

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto process

echo Pass 0 to build for .NET 8, .NET 9, and .NET 10
echo Pass 1 to process only for .NET 8
echo Pass 2 to process only for .NET 9
echo Pass 3 to process only for .NET 10

goto end

:process

set projId=

set config=Debug

title Building the toolkit in %config% config ...

if [%arg%] == [0] (goto dotnet8) else (if [%arg%] == [1] (goto dotnet8) else (if [%arg%] == [2] (goto dotnet9) else (if [%arg%] == [3] (goto dotnet10) else (call Error "Invalid input." && goto end))))

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

if [%arg%] == [0] (echo.) else (if [%arg%] == [1] goto end)

:: .NET 9 package version

:dotnet9

set projId=Net9

if exist .\global.json.net9.bak ren global.json.net9.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET 9 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET 9 version # not configured. & goto end)

call Create-Package-New.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net9.bak

if [%arg%] == [0] (echo.) else (if [%arg%] == [2] goto end)

:: .NET 8 package version

:dotnet10

set projId=Net10

if exist .\global.json.net10.bak ren global.json.net10.bak global.json

if not exist PackageVersion-%projId%.txt (echo .NET 10 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (echo .NET 10 version # not configured. & goto end)

call Create-Package-New.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net10.bak

:end
if [%1] == [] pause
