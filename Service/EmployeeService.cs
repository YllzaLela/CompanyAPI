using AutoMapper;
using CompanyAPI.Repositories.Interfaces;
using CompanyAPI.Service.Interfaces;
using CompanyAPI.WebAPI.Models;
using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.Service
{
    public class EmployeeService : IEmployeeService	
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) 
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}

		public IEnumerable<EmployeeDTO> GetEmployees()
		{
			IEnumerable<Employee> employees = _employeeRepository.GetEmployees();
			IEnumerable<EmployeeDTO> employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
			return employeesDTO;
		}

		public EmployeeDTO GetEmployee(int id)
		{
			Employee employee = _employeeRepository.GetEmployee(id);
			EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);
			return employeeDTO;
		}

		public void AddEmployee(EmployeeDTO employeeDTO)
		{
			Employee employee = _mapper.Map<Employee>(employeeDTO);
			_employeeRepository.AddEmployee(employee);
		}

		public void UpdateEmployee(EmployeeDTO employeeDTO)
		{
			Employee employee = _mapper.Map<Employee>(employeeDTO);
			_employeeRepository.UpdateEmployee(employee);
		}

		public void DeleteEmployeeById(int id)
		{
			_employeeRepository.DeleteEmployeeById(id);
		}
	}
}
