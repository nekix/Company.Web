namespace Company;

public interface IEmployeeAppService
{
    Task<EmployeeDto> GetAsync(Guid id);

    Task<List<EmployeeDto>> GetListAsync(GetEmployeeListDto input);

    Task<EmployeeDto> CreateAsync(CreateUpdateEmployeeDto input);

    Task UpdateAsync(Guid id, CreateUpdateEmployeeDto input);

    Task DeleteAsync(Guid id);
}