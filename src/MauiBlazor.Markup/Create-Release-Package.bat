:: Creates a new NuGet package from the project file
@echo off

set projId=

set config=Release

:: Package Version
:: .NET 6

set projId=Net6

if not exist PackageVersion-%projId%.txt (call Error ".NET 6 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 6 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

:: .NET 7

echo.
set projId=Net7

if not exist PackageVersion-%projId%.txt (call Error ".NET 7 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 7 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

:end
pause
