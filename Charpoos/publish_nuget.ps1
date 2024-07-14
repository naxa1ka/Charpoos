# Path to the project
$projectPath = "P:\Projects\Charpoos\Charpoos\Charpoos.csproj"
$outputDirectory = "P:\Projects\Charpoos\Charpoos\bin\Release"
$nugetSource = "github"

# Get API key from environment variable
$apiKey = $env:NUGET_API_KEY

if (-not $apiKey) {
    Write-Host "Error: API key is not set. Please set the environment variable NUGET_API_KEY." -ForegroundColor Red
    exit 1
}

# Path to the configuration file
$configFilePath = "P:\Projects\Charpoos\Charpoos\nuget.config"

# Generate configuration file
$configContent = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="github" value="https://nuget.pkg.github.com/naxa1ka/index.json" />
    </packageSources>
    <packageSourceCredentials>
        <github>
            <add key="Username" value="naxa1ka" />
            <add key="ClearTextPassword" value="$apiKey" />
        </github>
    </packageSourceCredentials>
</configuration>
"@

# Save the configuration file
Set-Content -Path $configFilePath -Value $configContent

Write-Host "Configuration file successfully created at $configFilePath"

# Build the project in Release mode
Write-Host "Building the project in Release mode..."
dotnet build $projectPath -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host "Error: Project build failed." -ForegroundColor Red
    exit 1
}

# Pack the project
Write-Host "Packing the project..."
dotnet pack $projectPath -c Release -o $outputDirectory

# Path to the created package (.nupkg file)
$packageFile = Get-ChildItem -Path $outputDirectory -Filter *.nupkg | Sort-Object LastWriteTime -Descending | Select-Object -First 1

if (-not $packageFile) {
    Write-Host "Error: Failed to find the packed file." -ForegroundColor Red
    exit 1
}

# Push the package
Write-Host "Pushing the package..."
dotnet nuget push $packageFile.FullName --source $nugetSource --api-key $apiKey

if ($LASTEXITCODE -ne 0) {
    Write-Host "Error: Package push failed." -ForegroundColor Red
    exit 1
}

Write-Host "Package push completed successfully."
