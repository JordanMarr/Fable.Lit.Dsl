@echo off
setlocal

REM Clean and create output directory
if exist .build rmdir /s /q .build
mkdir .build

REM Pack projects
dotnet pack src\Fable.Lit.Dsl\Fable.Lit.Dsl.fsproj -c Release -o .build
dotnet pack src\Fable.Lit.Dsl.Shoelace\Fable.Lit.Dsl.Shoelace.fsproj -c Release -o .build

echo.
echo Done! NuGet packages are in the .build folder.
echo.
pause
