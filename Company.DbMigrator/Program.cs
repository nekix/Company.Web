using Company.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company.DbMigrator;
class Program
{
    static async Task Main(string[] args)
    { 
        Console.WriteLine("Start init...");
        var factory = new EmployeesDbContextFactory();
        var dbContext = factory.CreateDbContext(Array.Empty<string>());
        Console.WriteLine("Init completed!");

        Console.WriteLine("Start migration...");
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Migration completed! ");

        if (dbContext.Set().Any())
        {
            Console.WriteLine("All completed!");
            return;
        }

        Console.WriteLine("Init data seeding!");
        var repository = new EfCoreEmployeeRepository(dbContext);

        var employees = EmployeeDataSeedGenerator.GenerateEmployees(20);

        foreach (var employee in employees)
        {
            await repository.InsertAsync(employee);
        }
        Console.WriteLine("Completed data seeding!");
        Console.WriteLine("All completed!");
    }
}
