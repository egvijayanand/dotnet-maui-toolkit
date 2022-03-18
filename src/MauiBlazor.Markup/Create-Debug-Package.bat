:: Creates a new NuGet package from the project file
@echo off

if not exist PackageVersion.txt (echo Version file not available && goto end)

set /P packageVersion=<PackageVersion.txt

if "%packageVersion%"=="" (echo Version # not configured && goto end)

@echo Version #: %packageVersion%

@echo Delete existing package
if exist .\MauiBlazor.Markup\bin\Debug\MauiBlazor.Markup.%packageVersion%.nupkg del .\MauiBlazor.Markup\bin\Debug\MauiBlazor.Markup.%packageVersion%.nupkg

echo Creating NuGet package ...
dotnet build .\MauiBlazor.Markup\MauiBlazor.Markup.csproj -c Debug -p:PackageVersion=%packageVersion% -p:ContinuousIntegrationBuild=true
echo Process completed.

:end
pause