using Company.Repositories;

namespace Company;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{

}
