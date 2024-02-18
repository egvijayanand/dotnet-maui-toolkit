:: Creates a new NuGet package from the project file
@echo off

if [%1] == [] (set arg=0) else (set arg=%1)

if not [%arg%] == [-h] goto process

echo Pass 0 to process for .NET 7, .NET 8, and .NET 9
echo Pass 1 to process only for .NET 7
echo Pass 2 to process only for .NET 8
echo Pass 3 to process only for .NET 9

goto end

:process

set projId=

set config=Debug

if [%arg%] == [0] (goto dotnet7) else (if [%arg%] == [1] (goto dotnet7) else (if [%arg%] == [2] (goto dotnet8) else (if [%arg%] == [3] (goto dotnet9) else (call Error "Invalid input." && goto end))))

:: Package Version
:: .NET 6

::set projId=Net6

::if exist .\global.json.net6.bak ren global.json.net6.bak global.json

::if not exist PackageVersion-%projId%.txt (call Error ".NET 6 version file not available." & goto end)

::set /P pkgVersion=<PackageVersion-%projId%.txt

::if [%pkgVersion%]==[] (call Error ".NET 6 version # not configured." & goto end)

::call Create-Package.bat %projId% %config% %pkgVersion%

::if exist .\global.json ren global.json global.json.net6.bak

:: .NET 7

:dotnet7
set projId=Net7

if exist .\global.json.net7.bak ren global.json.net7.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 7 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 7 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net7.bak

if [%arg%] == [0] (echo.) else (if [%arg%] == [1] goto end)

:: .NET 8

:dotnet8
set projId=Net8

if exist .\global.json.net8.bak ren global.json.net8.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 8 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 8 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net8.bak

if [%arg%] == [0] (echo.) else (if [%arg%] == [2] goto end)

:: .NET 9

:dotnet9
set projId=Net9

if exist .\global.json.net9.bak ren global.json.net9.bak global.json

if not exist PackageVersion-%projId%.txt (call Error ".NET 9 version file not available." & goto end)

set /P pkgVersion=<PackageVersion-%projId%.txt

if [%pkgVersion%]==[] (call Error ".NET 9 version # not configured." & goto end)

call Create-Package.bat %projId% %config% %pkgVersion%

if exist .\global.json ren global.json global.json.net9.bak

:end
if [%1] == [] pause
