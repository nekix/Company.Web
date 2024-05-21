using Company.Entity;

namespace Company;

public class EmployeeDto : EntityDto<Guid>
{
    public PersonalInfoDto PersonalInfo { get; set; }

    public string Department { get; set; }

    public DateOnly EmploymentDate { get; set; }

    public decimal MonthlySalary { get; set; }
}