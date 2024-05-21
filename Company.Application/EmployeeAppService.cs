using AutoMapper;

namespace Company;

public class EmployeeAppService : IEmployeeAppService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeAppService(
        IEmployeeRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> GetAsync(Guid id)
    {
        var employee = await _repository.GetAsync(id);
        return _mapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task<List<EmployeeDto>> GetListAsync(GetEmployeeListDto input)
    {
        var employees = await _repository.GetListAsync();
        return _mapper.Map<List<Employee>, List<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> CreateAsync(CreateUpdateEmployeeDto input)
    {
        var personalInfo = new PersonalInformation(
            input.PersonalInfo.FirstName,
            input.PersonalInfo.LastName,
            input.PersonalInfo.Patronymic,
            input.PersonalInfo.BirthDate);

        var employee = new Employee(
            Guid.NewGuid(),
            personalInfo,
            input.EmploymentDate,
            input.Department,
            input.MonthlySalary);

        employee = await _repository.InsertAsync(employee);

        return _mapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task UpdateAsync(Guid id, CreateUpdateEmployeeDto input)
    {
        var employee = await _repository.GetAsync(id);

        if (employee.EmploymentDate != input.EmploymentDate)
        {
            employee.CorrectEmploymentDate(input.EmploymentDate);
        }

        if (employee.Department != input.Department)
        {
            employee.TransferToAnotherDepartment(input.Department);
        }

        if (employee.MonthlySalary != input.MonthlySalary)
        {
            employee.SetNewMonthlySalary(input.MonthlySalary);
        }

        var inputPrsInfo = input.PersonalInfo;
        var prsInfo = employee.PersonalInformation;

        if (prsInfo.FirstName != inputPrsInfo.FirstName ||
            prsInfo.LastName != inputPrsInfo.LastName || 
            prsInfo.FirstName != inputPrsInfo.FirstName)
        {
            employee.PersonalInformation.ChangeFullName(
                inputPrsInfo.FirstName,
                inputPrsInfo.LastName,
                inputPrsInfo.Patronymic);
        }

        await _repository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}