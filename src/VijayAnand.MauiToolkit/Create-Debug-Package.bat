:: Creates a new NuGet package from the project file in Debug configuration
@echo off

title Building the toolkit in Debug config ...

:: .NET 6 package version

if exist .\global.json.net6.bak ren global.json.net6.bak global.json

if not exist PackageVersion-Net6.txt (echo .NET 6 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-Net6.txt

if [%pkgVersion%]==[] (echo .NET 6 version # not configured. & goto end)

call Create-Package-New.bat Net6 Debug %pkgVersion%

if exist .\global.json ren global.json global.json.net6.bak

:: .NET 7 package version

if exist .\global.json.net7.bak ren global.json.net7.bak global.json

if not exist PackageVersion-Net7.txt (echo .NET 7 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-Net7.txt

if [%pkgVersion%]==[] (echo .NET 7 version # not configured. & goto end)

call Create-Package-New.bat Net7 Debug %pkgVersion%

if exist .\global.json ren global.json global.json.net7.bak

:: .NET 8 package version

if exist .\global.json.net8.bak ren global.json.net8.bak global.json

if not exist PackageVersion-Net8.txt (echo .NET 8 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-Net8.txt

if [%pkgVersion%]==[] (echo .NET 8 version # not configured. & goto end)

call Create-Package-New.bat Net8 Debug %pkgVersion%

if exist .\global.json ren global.json global.json.net8.bak

pause
