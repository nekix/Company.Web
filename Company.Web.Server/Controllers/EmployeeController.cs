using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Get))]
        public async Task<List<EmployeeDto>> Get()
        {
            var employees = await _employeeAppService
                .GetListAsync(new GetEmployeeListDto());

            return employees;
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Get))]
        public async Task<EmployeeDto> Get(Guid id)
        {
            var employee = await _employeeAppService
                .GetAsync(id);

            return employee;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Create))]
        public async Task<EmployeeDto> Create([FromBody] CreateUpdateEmployeeDto input)
        {
            var employee = await _employeeAppService
                .CreateAsync(input);

            return employee;
        }

        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Put))]
        public async Task<EmployeeDto> Edit(Guid id, [FromBody] CreateUpdateEmployeeDto input)
        {
            await _employeeAppService
                .UpdateAsync(id, input);

            return await _employeeAppService.GetAsync(id);
        }

        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Delete))]
        public async Task Delete(Guid id)
        {
            await _employeeAppService.DeleteAsync(id);
        }
    }
}
