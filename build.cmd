@echo off

if "%1"=="" goto usage

set PROJECT_NAME=Stugo.Logging
set FULL_VERSION=%1

msbuild /p:Configuration=net40 /m
msbuild /p:Configuration=net45 /m
mkdir %PROJECT_NAME%\bin\nupkg
nuget pack %PROJECT_NAME%\%PROJECT_NAME%.nuspec -OutputDirectory %PROJECT_NAME%\bin\nupkg\ -Version "%FULL_VERSION%"
goto :eof

:usage
echo "build.cmd <version>"