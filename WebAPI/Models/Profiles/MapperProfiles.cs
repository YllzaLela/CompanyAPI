using AutoMapper;
using CompanyAPI.Models.DTO;
namespace CompanyAPI.Models.Profiles
{
	public class MapperProfiles : Profile
	{
		public MapperProfiles()
		{
			CreateMap<Employee, EmployeeDTO>().ReverseMap();
			CreateMap<Company, CompanyDTO>().ReverseMap();
		}
	}
}
