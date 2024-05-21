using Company.Entity;
using Company.Exceptions;
using Company.Shared.Utilities;

namespace Company;

/// <summary>
/// Информация о сотруднике компании.
/// </summary>
public sealed class Employee : IEntity<Guid>
{
    public Guid Id { get; private set; }

    public PersonalInformation PersonalInformation { get; private set; }

    public string Department { get; private set; }

    public DateOnly EmploymentDate { get; private set; }

    public double MonthlySalary { get; private set; }

    #region Protected сonstructor only for ORM
    // Поле, не допускающее значения NULL, должно содержать значение,
    // отличное от NULL, при выходе из конструктора.
    // Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618
    // Новый защищенный элемент объявлен в запечатанном типе
#pragma warning disable CS0628
    protected Employee()
    {
        // Only for ORM
    }
#pragma warning restore CS0628
#pragma warning restore CS8618
    #endregion

    public Employee(
        Guid id,
        PersonalInformation personalInformation,
        DateOnly employmentDate,
        string department,
        double monthlySalary)
    {
        Id = id;
        SetPersonalInformation(personalInformation);
        SetEmploymentDate(employmentDate);
        SetDepartment(department);
        SetMonthlySalary(monthlySalary);
    }

    #region Internal actions
    public DateOnly CorrectEmploymentDate(DateOnly employmentDate)
    {
        if(employmentDate.CompareTo(EmploymentDate) == 0)
        {
            throw new BusinessException(DomainErrorCodes.ChangeToTheSameEmploymentDate);
        }

        SetEmploymentDate(employmentDate);
        return EmploymentDate;
    }

    public string TransferToAnotherDepartment(string department)
    {
        if (department == Department)
        {
            throw new BusinessException(DomainErrorCodes.TransferToTheSameDepartment);
        }

        SetDepartment(department);
        return Department;
    }

    public double SetNewMonthlySalary(double monthlySalary)
    {
        if (monthlySalary == MonthlySalary)
        {
            throw new BusinessException(DomainErrorCodes.ChangeOfSalaryToTheSame);
        }

        SetMonthlySalary(monthlySalary);
        return MonthlySalary;
    }
    #endregion

    #region Private methods
    private void SetPersonalInformation(PersonalInformation personalInformation)
    {
        PersonalInformation = Check
            .NotNull(personalInformation, nameof(personalInformation));
    }

    private void SetEmploymentDate(DateOnly employmentDate)
    {
        EmploymentDate = Check.Range(
            employmentDate,
            nameof(employmentDate),
            new DateOnly(
                EmployeeConsts.MinEmploymentDate.Year,
                EmployeeConsts.MinEmploymentDate.Mounth,
                EmployeeConsts.MinEmploymentDate.Day),
            EmployeeConsts.MaxEmploymentDate);
    }

    private void SetDepartment(string department)
    {
        Department = Check.NotNullOrWhiteSpace(
            department,
            nameof(department),
            minLength: EmployeeConsts.MinDepartmentLength,
            maxLength: EmployeeConsts.MaxDepartmentLength);
    }

    private void SetMonthlySalary(double monthlySalary)
    {
        MonthlySalary = Check.Range(
            monthlySalary,
            nameof(monthlySalary),
            minimumValue: EmployeeConsts.MinMonthlySalary);
    }
    #endregion
}
