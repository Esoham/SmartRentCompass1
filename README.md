# SmartRentCompass1 — Historical .NET / Blazor Experiment

**Status:** An older learning prototype, **not** a live rental-listing application or a verified production service. It explores property models, search helpers, database configuration, and an experimental Blazor UI.

## Where to look
- `SmartRentCompass/` — console/domain classes, apartment data models and service experiments.
- `SmartRentCompass.BlazorApp/` — Blazor web-host experiment.
- `SmartRentCompass.sln` — historical solution file.

## Build status and prerequisites
Both project files target **.NET 7**, which is no longer supported. The console project references several historical ASP.NET/Entity Framework and MySQL packages. No build, automated tests, data-source integration or deployment has been verified during this portfolio cleanup.

For local exploration only, with a compatible SDK:
```bash
dotnet restore SmartRentCompass.sln
dotnet build SmartRentCompass.sln
```
Treat build failures as modernization tasks rather than evidence of a working application. Do not configure a production database or publish personal renter information.

## Relationship to the other rental projects
This is an earlier iteration, not a second independently shipped rental product. See [SmartRentCompass](https://github.com/Esoham/SmartRentCompass) for the more clearly documented prototype and [ApartmentFinder](https://github.com/Esoham/ApartmentFinder) for a separate console exercise.

## QA opportunities
A future modernization could add tests for rent filters, invalid budgets, missing listings, duplicate results and SQL configuration. Those tests are proposals, not implemented claims.

**Portfolio guidance:** Preserve for learning history; don't feature ahead of working, tested projects such as [Meridian ERP](https://github.com/Esoham/Meridian-ERP).
