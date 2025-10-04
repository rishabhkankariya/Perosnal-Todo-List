# Todo List Application Build and Run Script
Write-Host "Building Todo List Application..." -ForegroundColor Green
Write-Host ""

# Restore packages
Write-Host "Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to restore packages" -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit 1
}

# Build the solution
Write-Host "Building solution..." -ForegroundColor Yellow
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed" -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit 1
}

Write-Host ""
Write-Host "Build successful! Starting application..." -ForegroundColor Green
Write-Host ""

# Run the application
dotnet run --project TodoList.Presentation --configuration Release

Read-Host "Press Enter to exit"
