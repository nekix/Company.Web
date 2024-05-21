using System.ComponentModel.DataAnnotations;

namespace Company;

public class CreateUpdateEmployeeDto
{
    [Required]
    public CreateUpdatePersonalInfoDto PersonalInfo { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(
        maximumLength: EmployeeConsts.MaxDepartmentLength,
        MinimumLength = EmployeeConsts.MinDepartmentLength)]
    public string Department { get; set; }

    // TODO: Аттрибут для валидации даты
    public DateOnly EmploymentDate { get; set; }

    [Required]
    [Range(EmployeeConsts.MinMonthlySalary, double.MaxValue)]
    public double MonthlySalary { get; set; }
}