using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.EntityFrameworkCore;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        ConfigureEmployee(builder);
    }

    private static void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Department)
            .IsRequired();

        builder.Property(x => x.EmploymentDate)
            .HasConversion<DateOnlyConverter>()
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.MonthlySalary)
            .IsRequired();

        builder.OwnsOne(x => x.PersonalInformation,
            ConfigurePersonalInformation)
            .Navigation(x => x.PersonalInformation).IsRequired();
    }

    private static void ConfigurePersonalInformation (
        OwnedNavigationBuilder<Employee, PersonalInformation> builder)
    {
        builder.Property(z => z.FirstName)
            .HasColumnName("FirstName")
            .IsRequired();

        builder.Property(z => z.LastName)
            .HasColumnName("LastName")
            .IsRequired();

        builder.Property(z => z.Patronymic)
            .HasColumnName("Patronymic");

        builder.Property(z => z.BirthDate)
            .HasColumnName("BirthDate")
            .HasConversion<DateOnlyConverter>()
            .HasColumnType("date")
            .IsRequired();

        builder.Ignore(z => z.FullName);

        builder.WithOwner();
    }

}
