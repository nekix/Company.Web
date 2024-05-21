namespace Company;

public static partial class EmployeeConsts
{
    public const int MaxDepartmentLength = 100;
    public const int MinDepartmentLength = 1;

    public const double MinMonthlySalary = 0;

    public static class MinEmploymentDate
    {
        public const int Year = 1950;

        public const int Mounth = 1;

        public const int Day = 1;
    }

    public static readonly DateOnly MaxEmploymentDate = DateOnly.FromDateTime(DateTime.Now);
}
