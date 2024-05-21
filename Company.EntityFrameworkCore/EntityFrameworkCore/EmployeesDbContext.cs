using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Company.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class EmployeesDbContext : DbContext, IEfCoreDbContext<Employee, Guid>
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
        : base(options)
    {

    }

    public DbSet<Employee> Set()
        => Employees;

    public EntityEntry<Employee> Update(Employee entity)
        => base.Update(entity);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }
}
