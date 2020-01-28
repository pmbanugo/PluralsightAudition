## Purpose of the project

This project will guide you in configuring Entity Framework to use the In-Memory database provider in ASP.NET Core. The In-Memory database provider allows Entity Framework Core to be used with an in-memory database. This can be useful for testing or quick demo purposes.

## Verify your work in your local environment

To verify your work on your local environment, you'll need to run the unit tests. Open the solution file `PluralsightAudition.sln` in Visual Studio or Jetbrains Rider and follow one of these instructions:

- To run tests locally in Visual Studio for Windows click "Run All" in the `Test Explorer` window. (If Test Explorer is closed you can reopen it by going to `Test` then `Windows` then `Test Explorer`)
- To run tests locally in Visual Studio for macOS click "Run All" in the `Unit Tests` window. (If Unit Tests is closed you can reopen it by going to `View` then `Pads` then `Unit Tests`)
- To run the tests on Jetbrains Rider, go to the `Tests` menu and select "Run All Tests from Solution".

### Running from the command line

To run the tests from the command line, navigate to the folder **PluralsightAudition.Test** in your command-line application and run `dotnet test` command.

## Task 1: Install the EF In-Memory Database Provider

Install the Nuget package for the database provider that allows Entity Framework Core to be used with an in-memory database. The name of the package is `Microsoft.EntityFrameworkCore.InMemory`.

## Task 2: Add `BookContext` to the Services layer

In the `ConfigureServices` method in `Startup.cs`, call `AddDbContext<BookContext>` on `services` with the argument `options => options.UseInMemoryDatabase("Books")` to point EntityFramework to the application's DbContext.

## Task 3: Add using statement to the `Microsoft.EntityFrameworkCore` namespace

Add a using statement to the `Microsoft.EntityFrameworkCore` namespace in `Startup.cs`
