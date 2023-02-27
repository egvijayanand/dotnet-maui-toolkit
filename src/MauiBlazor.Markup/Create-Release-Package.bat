:: Creates a new NuGet package from the project file
@echo off

set projId=

set config=Release

:: Package Version
:: .NET 6

set projId=Net6

if exist .\global.json.net6.bak ren global.json.net6.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 6 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 6 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net6.bak

:: .NET 7

echo.
set projId=Net7

if exist .\global.json.net7.bak ren global.json.net7.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 7 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 7 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net7.bak

:: .NET 8

echo.
set projId=Net8

if exist .\global.json.net8.bak ren global.json.net8.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 8 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 8 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net8.bak

:end
echo.
pause
