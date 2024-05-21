using Company.EntityFrameworkCore;

namespace Company;

public class EfCoreEmployeeRepository :
    EfCoreRepository<EmployeesDbContext, Employee, Guid>,
    IEmployeeRepository
{
    public EfCoreEmployeeRepository(EmployeesDbContext context) : base(context)
    {
    }
}