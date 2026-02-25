# TipCalc

[![Azure Static Web Apps CI/CD](https://github.com/jeremyknight-me/tip-calc/actions/workflows/azure-static-web-apps-icy-island-081870110.yml/badge.svg)](https://github.com/jeremyknight-me/tip-calc/actions/workflows/azure-static-web-apps-icy-island-081870110.yml)

TipCalc is a small Blazor Progressive Web App (PWA) for calculating tips and managing tip history. It is implemented in C# (Blazor) with a minimal JavaScript interop layer and is configured for deployment to Azure Static Web Apps.

## Features
- Calculate tip amounts from a bill and percentage
- Progressive Web App support (installable / offline caching)

## Tech Stack
- .NET / Blazor (C#)
- JavaScript (small helper scripts)
- xUnit for unit tests
- Azure Static Web Apps (deployment)

## Development

### Prerequisites
- .NET SDK (match project target framework; see project files)
- Optional: Visual Studio or Visual Studio Code

Verify .NET is installed:
```bash
dotnet --version
```

### Quick Start (local)
From the repository root:

1. Restore and build:
```bash
dotnet restore ./src/TipCalc.slnx
dotnet build ./src/TipCalc.slnx
```

2. Run the app locally:
```bash
dotnet run --project ./src/TipCalc/TipCalc.csproj
```
Open the URL printed by `dotnet run` (usually https://localhost:5001).

### Tests
Run unit tests:
```bash
dotnet test ./src/TipCalc.Tests
```

### Deployment
Build for production:
```bash
dotnet publish -c Release -o ./publish ./src/TipCalc/TipCalc.csproj
```

This repository includes `staticwebapp.config.json` and a GitHub Actions workflow for Azure Static Web Apps. See Azure Static Web Apps docs for full CI/CD setup.

## Contributing
- Fork the repo and create a branch: `feat/<name>` or `fix/<name>`.
- Write tests for new features or bug fixes.
- Run `dotnet test` and `dotnet build` locally.
- Run `dotnet format` or follow the project's `.editorconfig` (add one if missing).
- Submit a pull request with a description, testing steps, and related issue links.

## License
This project is licensed under the terms in [LICENSE](LICENSE).