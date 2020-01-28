using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace PluralsightAudition.Test
{
    public class ConfigureInMemoryProviderTests
    {
        [Fact(DisplayName = "Install the In-Memory EF Database Provider")]
        public void InstallInMemoryDbProviderNugetPackageTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "PluralsightAudition" + Path.DirectorySeparatorChar + "PluralsightAudition.csproj";
            Assert.True(File.Exists(filePath), "`PluralsightAudition.csproj` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"<PackageReference Include=""Microsoft.EntityFrameworkCore.InMemory""";
            var rgx = new Regex(pattern);

            Assert.True(rgx.IsMatch(file), "The project doesn't have a reference to the `Microsoft.EntityFrameworkCore.InMemory` Nuget package.");
        }
        
        [Fact(DisplayName = "Add BookContext to the service layer by calling AddDbContext<BookContext>")]
        public void AddBookContextToTheServiceLayerTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "PluralsightAudition" + Path.DirectorySeparatorChar + "Startup.cs";
            Assert.True(File.Exists(filePath), "`Startup.cs` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"services\s*?[.]AddDbContext\s*?[<]\s*?BookContext\s*?[>]";
            var rgx = new Regex(pattern);
            
            Assert.True(rgx.IsMatch(file), "`Startup.ConfigureServices` didn't contain a call for `AddDbContext` on `services` with the type argument `BookContext`");
            Assert.True(file.Contains("options => options.UseInMemoryDatabase(\"Books\")"), @"`Startup.ConfigureServices` didn't provide `options => options.UseInMemoryDatabase(""Books"")` as an argument for `AddDbContext<BookContext>`");
        }
        
        [Fact(DisplayName = "Add using statement for the Microsoft.EntityFrameworkCore namespace")]
        public void IncludeUsingStatementForTheDbProviderTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "PluralsightAudition" + Path.DirectorySeparatorChar + "Startup.cs";
            Assert.True(File.Exists(filePath), "`Startup.cs` was not found. Did you rename, move, or delete it?");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("using Microsoft.EntityFrameworkCore"), @"`Startup.cs` doesn't contain a reference to the `Microsoft.EntityFrameworkCore` namespace.");
        }
    }
}