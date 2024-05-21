using Microsoft.VisualBasic.CompilerServices;

namespace Company;

public static class EmployeeDataSeedGenerator
{
    public static List<Employee> GenerateEmployees(int count, int seed = 1111)
    {
        var employees = new List<Employee>();
        var rand = new Random(seed);

        for (int i = 0; i < count; i++)
        {
            var id = Guid.NewGuid();
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Daniel", "Jessica", "Matthew", "Lauren" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };
            string[] patronymics = { "James", "Elizabeth", "Christopher", "Amanda", "William", "Ashley", "Joseph", "Jennifer", "Andrew", "Michelle" };

            string[] departments = { "HR", "IT", "Finance", "Marketing", "Operations" };

            var firstName = firstNames[rand.Next(firstNames.Length)];
            var lastName = lastNames[rand.Next(lastNames.Length)];
            var patronymic = rand.Next(5) < 3 
                ? patronymics[rand.Next(patronymics.Length)]
                : null;
            var birthDate = new DateOnly(rand.Next(1930, 2000), rand.Next(1, 13), rand.Next(1, 29));
            var personalInfo = new PersonalInformation(firstName, lastName, patronymic, birthDate);

            var department = departments[rand.Next(departments.Length)];
            var employmentDate = new DateOnly(rand.Next(2010, 2023), rand.Next(1, 13), rand.Next(1, 29));
            var monthlySalary = rand.NextDouble() * 20000 + 5000; // Random salary between 3000 and 20000

            employees.Add(new Employee(id, personalInfo, employmentDate, department, monthlySalary));
        }

        return employees;
    }
}