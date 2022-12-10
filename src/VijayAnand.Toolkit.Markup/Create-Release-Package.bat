:: Creates a new NuGet package from the project file
@echo off

:: .NET SDK Version

dotnet --version

:: .NET 6 package version

if not exist PackageVersion-Net6.txt (echo .NET 6 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-Net6.txt

if [%pkgVersion%]==[] (echo .NET 6 version # not configured. & goto end)

call Create-Package.bat Net6 Release %pkgVersion%

:: .NET 7 package version

if not exist PackageVersion-Net7.txt (echo .NET 6 version file not available. & goto end)

:: Read the value of pkgVersion from the PackageVersion file
set /P pkgVersion=<PackageVersion-Net7.txt

if [%pkgVersion%]==[] (echo .NET 6 version # not configured. & goto end)

call Create-Package.bat Net7 Release %pkgVersion%
pause
