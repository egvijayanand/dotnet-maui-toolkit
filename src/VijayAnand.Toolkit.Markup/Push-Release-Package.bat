:: Installs the NuGet package
@echo off

if defined MyGetSource (set "nugetSource=%MyGetSource%") else (echo MyGet folder source path is not defined. & goto end)

if defined MyGetServer (set "nugetServer=%MyGetServer%") else (echo MyGet hosted source path is not defined. & goto end)

:: Package Name

if not exist PackageName.txt echo Package name file not available. & goto end

set /P packageName=<PackageName.txt

if [%packageName%]==[] echo Package name not configured. & goto end

:: Directory Check

if not exist "%nugetSource%\%packageName%\" mkdir "%nugetSource%\%packageName%"

:: .NET 6 Package Version

if not exist PackageVersion-Net6.txt echo .NET 6 package version file not available. & goto end

set /P packageVersion=<PackageVersion-Net6.txt

if [%packageVersion%]==[] echo .NET 6 package version # not configured. & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg echo .NET 6 NuGet package not avilable. & goto end

:: Validate the Package

echo.
echo Validating .NET 6 %packageName% ver. %packageVersion% to My NuGet ...

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

echo Pushing .NET 6 %packageName% ver. %packageVersion% to My NuGet ...

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (echo .NET 6 folder package push failed. & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (echo .NET 6 hosted package push failed. & goto end)

:: .NET 7 Package Version

if not exist PackageVersion-Net7.txt echo .NET 7 package version file not available. & goto end

set /P packageVersion=<PackageVersion-Net7.txt

if [%packageVersion%]==[] echo .NET 7 package version # not configured. & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg echo .NET 7 NuGet package not avilable. & goto end

:: Validate the Package

echo.
echo Validating .NET 7 %packageName% ver. %packageVersion% to My NuGet ...

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

echo Pushing .NET 7 %packageName% ver. %packageVersion% to My NuGet ...

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (echo .NET 7 folder package push failed. & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (echo Process completed.) else (echo .NET 7 hosted package push failed.)

:end
pause
