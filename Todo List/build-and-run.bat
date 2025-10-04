@echo off
echo Building Todo List Application...
echo.

REM Restore packages
echo Restoring NuGet packages...
dotnet restore
if %ERRORLEVEL% neq 0 (
    echo Failed to restore packages
    pause
    exit /b 1
)

REM Build the solution
echo Building solution...
dotnet build --configuration Release
if %ERRORLEVEL% neq 0 (
    echo Build failed
    pause
    exit /b 1
)

echo.
echo Build successful! Starting application...
echo.

REM Run the application
dotnet run --project TodoList.Presentation --configuration Release

pause
