:: Installs the NuGet package
@echo off

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto process

echo Pass 0 to build for .NET 6, .NET 7, .NET 8, and .NET 9
echo Pass 1 to process only for .NET 6
echo Pass 2 to process only for .NET 7
echo Pass 3 to process only for .NET 8
echo Pass 4 to process only for .NET 9

goto end

:process

title Publishing the NuGet packages to MyGet ...

if defined MyGetSource (set "nugetSource=%MyGetSource%") else (call Error "MyGet folder source path is not defined." & goto end)

if defined MyGetServer (set "nugetServer=%MyGetServer%") else (call Error "MyGet hosted source path is not defined." & goto end)

:: Package Name

if not exist PackageName.txt call Error "Package name file not available." & goto end

set /P packageName=<PackageName.txt

if [%packageName%]==[] call Error "Package name not configured." & goto end

:: Directory Check

if not exist "%nugetSource%\%packageName%\" mkdir "%nugetSource%\%packageName%"

if [%arg%] == [0] (goto dotnet6) else (if [%arg%] == [1] (goto dotnet6) else (if [%arg%] == [2] (goto dotnet7) else (if [%arg%] == [3] (goto dotnet8) else (if [%arg%] == [4] (goto dotnet9) else (call Error "Invalid input." && goto end)))))

:: .NET 6 Package Version

:dotnet6

if not exist PackageVersion-Net6.txt call Error ".NET 6 package version file not available." & goto end

set /P packageVersion=<PackageVersion-Net6.txt

if [%packageVersion%]==[] call Error ".NET 6 package version # not configured." & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg call Error ".NET 6 NuGet package not avilable." & goto end

:: Validate the Package

echo.
call Info "Validating .NET 6 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 6 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error ".NET 6 package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

if not %errorlevel% == 0 (call Error ".NET 6 package hosted push failed." & goto end)

if [%arg%] == [0] (echo.) else (if [%arg%] == [1] goto end)

:: .NET 7 Package Version

:dotnet7

if not exist PackageVersion-Net7.txt call Error ".NET 7 package version file not available." & goto end

set /P packageVersion=<PackageVersion-Net7.txt

if [%packageVersion%]==[] call Error ".NET 7 package version # not configured." & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg call Error ".NET 7 NuGet package not avilable." & goto end

:: Validate the Package

echo.
call Info "Validating .NET 7 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 7 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error ".NET 7 package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 7 package hosted push failed.")

if [%arg%] == [0] (echo.) else (if [%arg%] == [2] goto end)

:: .NET 8 Package Version

:dotnet8

if not exist PackageVersion-Net8.txt call Error ".NET 8 package version file not available." & goto end

set /P packageVersion=<PackageVersion-Net8.txt

if [%packageVersion%]==[] call Error ".NET 8 package version # not configured." & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg call Error ".NET 8 NuGet package not avilable." & goto end

:: Validate the Package

echo.
call Info "Validating .NET 8 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 8 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error ".NET 8 package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 8 package hosted push failed.")

if [%arg%] == [0] (echo.) else (if [%arg%] == [3] goto end)

:: .NET 9 Package Version

:dotnet9

if not exist PackageVersion-Net9.txt call Error ".NET 9 package version file not available." & goto end

set /P packageVersion=<PackageVersion-Net9.txt

if [%packageVersion%]==[] call Error ".NET 9 package version # not configured." & goto end

:: Existence Check

if not exist .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg call Error ".NET 9 NuGet package not avilable." & goto end

:: Validate the Package

echo.
call Info "Validating .NET 9 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet-validate package local .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg

:: Push the Package

call Info "Pushing .NET 9 %packageName% ver. %packageVersion% to My NuGet ..."

echo.
dotnet nuget push .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg --source %nugetSource%\%packageName%

if not %errorlevel% == 0 (call Error ".NET 9 package folder push failed." & goto end)

echo.
nuget add .\VijayAnand.Toolkit.Markup\bin\Release\%packageName%.%packageVersion%.nupkg -Source %nugetServer%\

echo.
if %errorlevel% == 0 (call Success "Process completed.") else (call Error ".NET 9 package hosted push failed.")

:end
if [%1] == [] pause
