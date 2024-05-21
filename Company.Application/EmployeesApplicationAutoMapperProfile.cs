using AutoMapper;

namespace Company;

public class EmployeesApplicationAutoMapperProfile : Profile
{
    public EmployeesApplicationAutoMapperProfile()
    {
        CreateMap<PersonalInformation, PersonalInfoDto>();

        CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.PersonalInfo,
                o => 
                    o.MapFrom(src => src.PersonalInformation));
    }
}